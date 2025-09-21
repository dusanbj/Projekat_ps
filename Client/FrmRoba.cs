using System.Windows.Forms;

namespace Client
{
    public partial class FrmRoba : Form
    {
        public FrmRoba()
        {
            InitializeComponent();

            // Samo UI podesavanje
            dgvRoba.AllowUserToAddRows = false;
            dgvRoba.AllowUserToDeleteRows = false;
            dgvRoba.MultiSelect = false;
            dgvRoba.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRoba.ReadOnly = true;
        }
    }
}