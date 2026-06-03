namespace Enochian_Encryption_System
{
    public partial class EnochianEncryptionSystem : Form
    {
        public EnochianEncryptionSystem()
        {
            InitializeComponent();
        }
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            EncryptForm encryptForm = new EncryptForm();
            encryptForm.ShowDialog();
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            DecryptForm decryptForm = new DecryptForm();
            decryptForm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRSA_Click(object sender, EventArgs e)
        {
            FrmRSA rsaForm = new FrmRSA();
            rsaForm.ShowDialog();
        }

        private void btnECC_Click(object sender, EventArgs e)
        {
            FrmECC ECCForm = new FrmECC();
            ECCForm.ShowDialog();
        }

        private void btnKyber_Click(object sender, EventArgs e)
        {
            FrmKyber kyberForm = new FrmKyber();
            kyberForm.ShowDialog();
        }
    }
}
