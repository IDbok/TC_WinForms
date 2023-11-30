namespace TC_WinForms.DataProcessing
{
    internal static class Authorizator
    {
        private static User authUser = null;
        public static string AuthUserName() => authUser.Name();
        public static string AuthUserSurname() => authUser.Surname();
        public static string AuthUserFullName() => authUser.Name() + " " + authUser.Surname();
        public static string AuthUserEmail() => authUser.Login();

        private static Dictionary<string, User> Users = new Dictionary<string, User>();

        private static Dictionary<string, string> Passwords = new Dictionary<string, string>();

        public static bool IsUserExust(string login, string password)
        {
            try
            {

                Users.Clear();
                Passwords.Clear();
                // creatin new user
                Users = new Dictionary<string, User>()
                {
                    {"newuser@mail.com", new User("newuser@mail.com", "password", "Александр", "Кузнецов")},
                    {"bokarev.fic@gmail.com", new User("bokarev.fic@gmail.com", "pass", "Игорь", "Бокарев")},
                    {"anpa@tavrida.com", new User("anpa@tavrida.com", "pass","Павел", "Анохин")}
                };

            
                if (Passwords[login.ToLower()] == password) 
                { 
                    authUser = Users[login.ToLower()].Copy();
                    return true;
                }
            }
            catch (Exception e) {
                MessageBox.Show("Error auth"/*e.Message*/); }
            return false;
        }

        public class User
        {
            private string? name;
            private string? surname;

            private string login;

            public string Login() => login;
            //public string Password() => password;
            public string Name() => name != null ? name : "no information";
            public string Surname() => surname != null ? surname : "no information";
            public User(string login, string password, string name, string surname)
            {
                this.login = login;
                Passwords.Add(login, password);
                this.name = name;
                this.surname = surname;
            }
            public User(string login, string password): this(login, password, name: null, surname: null)
            { }
            public User Copy()
            {
                return (User)this.MemberwiseClone();
            }
        }
    }
}
