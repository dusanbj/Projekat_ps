using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace Common.Communication
{
    public class JsonNetworkSerializer
    {
        private readonly Socket socket;
        private readonly NetworkStream stream;
        private readonly StreamReader reader;
        private readonly StreamWriter writer;
        private readonly JsonSerializerOptions jsonOptions;

        public Action<string> TransportError { get; set; }
        public bool IsBroken { get; private set; }

        public JsonNetworkSerializer(Socket s, JsonSerializerOptions options = null)
        {
            socket = s ?? throw new ArgumentNullException(nameof(s));
            stream = new NetworkStream(socket, ownsSocket: false);
            reader = new StreamReader(stream, Encoding.UTF8, detectEncodingFromByteOrderMarks: true, bufferSize: 1024, leaveOpen: true);
            writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true, NewLine = "\n" };
            jsonOptions = options ?? new JsonSerializerOptions { WriteIndented = false };
        }

        public void Send(object payload)
        {
            if (IsBroken) return;
            try
            {
                writer.WriteLine(JsonSerializer.Serialize(payload, jsonOptions));
            }
            catch (IOException) { MarkBroken(); }
            catch (SocketException) { MarkBroken(); }
            catch (ObjectDisposedException) { MarkBroken(); }
        }

        public T Receive<T>()
        {
            if (IsBroken) return default;
            try
            {
                var json = reader.ReadLine();
                if (json == null) { MarkBroken(); return default; }
                return JsonSerializer.Deserialize<T>(json, jsonOptions);
            }
            catch (IOException) { MarkBroken(); return default; }
            catch (SocketException) { MarkBroken(); return default; }
            catch (ObjectDisposedException) { MarkBroken(); return default; }
            catch (JsonException) { Notify("Nevažeći format poruke."); return default; }
        }

        public T ReadType<T>(object data) where T : class
        {
            if (data == null) return null;
            try
            {
                if (data is JsonElement je) return JsonSerializer.Deserialize<T>(je, jsonOptions);
                if (data is string js) return JsonSerializer.Deserialize<T>(js, jsonOptions);
                var json = JsonSerializer.Serialize(data, jsonOptions);
                return JsonSerializer.Deserialize<T>(json, jsonOptions);
            }
            catch (JsonException) { return null; }
        }

        public void Close()
        {
            try { writer?.Flush(); } catch { }
            try { writer?.Dispose(); } catch { }
            try { reader?.Dispose(); } catch { }
            try { stream?.Dispose(); } catch { }
            try { if (socket?.Connected == true) socket.Shutdown(SocketShutdown.Both); } catch { }
            try { socket?.Close(); } catch { }
            IsBroken = true;
        }

        private void MarkBroken()
        {
            IsBroken = true;
            Notify("Veza sa serverom je prekinuta.");
        }

        private void Notify(string msg)
        {
            try { TransportError?.Invoke(msg); } catch { }
        }
    }
}
