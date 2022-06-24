
namespace AutoGTP2Tests
{
    public class LoginData
    {
        private string username;
        private string password;        

        public LoginData(string username, string password)
        {
            Username = username;
            Password = password;            
        }

        public string Username { get { return username; } set { username = value; } }
        public string Password { get { return password; } set { password = value; } }
    }
}
