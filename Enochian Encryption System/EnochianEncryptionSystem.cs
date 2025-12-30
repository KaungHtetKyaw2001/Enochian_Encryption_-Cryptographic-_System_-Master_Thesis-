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
    }
}
