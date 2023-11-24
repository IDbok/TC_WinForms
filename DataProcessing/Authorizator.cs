namespace TC_WinForms.DataProcessing
{
    internal static class Authorizator
    {
        private static User authUser = null;
        public static string AuthUserName() => authUser.Name();

        private static Dictionary<int, User> Operators = new Dictionary<int, User>()
        {
            {1, new User("newuser@mail.com", "password","Александр", "Кузнецов")},
            {2, new User("bokarev.fic@gmail.com","pass", "Игорь", "Бокарев")},
            {3, new User("anpa@tavrida.com","pass","Павел", "Анохин")}
        };

        public static bool IsUserExust(string login, string password)
        {
            
            foreach (var user in Operators.Values)
            {
                if (user.Login().ToLower() == login.ToLower() && user.Password() == password)
                {
                    // return an link to the authed user
                    authUser = user;
                    return true;
                }
            }
            return false;
        }

        public class User
        {
            private string? name;
            private string? surname;

            private string login;
            private string password;

            public string Login() => login;
            public string Password() => password;
            public string Name() => name != null ? name : "no information";
            public string Surname() => surname != null ? surname : "no information";
            public User(string login, string password,string name, string surname)
            {
                this.login = login;
                this.password = password;
                this.name = name;
                this.surname = surname;
            }
            public User(string login, string password)
            {
                this.login = login;
                this.password = password;
                this.name = null;
                this.surname = null;
            }
            public User Copy()
            {
                return (User)this.MemberwiseClone();
            }
        }
    }
}
