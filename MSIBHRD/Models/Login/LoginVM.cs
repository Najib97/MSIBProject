namespace MSIBHRD.Models.Login
{
    public class LoginVM
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string PesanError { get; set; }
        public LoginVM()
        {

        }
        public LoginVM(string username, string password, string pesanError)
        {
            this.Username = username;
            this.Password = password;
            this.PesanError = pesanError;
        }
    }
}
