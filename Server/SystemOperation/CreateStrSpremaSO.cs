using Domen;
using System.Linq;

namespace Server.SystemOperation
{
    public class CreateStrSpremaSO : SystemOperationBase
    {
        private readonly StrSprema _input;
        public CreateStrSpremaSO(StrSprema input) { _input = input; }

        protected override void ExecuteConcreteOperation()
        {
            // 1) Validacija
            var naziv = (_input.Naziv ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(naziv))
                throw new System.Exception("Naziv stručne spreme je obavezan.");

            // 2) Provera duplikata po nazivu (case-insensitive)
            //    Domen.StrSprema.TableName = "strSprema", kolona je 'naziv'
            var safeNaziv = naziv.Replace("'", "''"); // escape za SQL literal
            var postoji = broker
                .GetByCondition(new StrSprema(), $"LOWER(naziv) = LOWER('{safeNaziv}')")
                .Cast<StrSprema>()
                .Any();

            if (postoji)
                throw new System.Exception("Stručna sprema sa datim nazivom već postoji.");

            // 3) Upis
            _input.Naziv = naziv;  // normalizuj pre snimanja (trim)
            broker.Add(_input);
        }
    }
}
