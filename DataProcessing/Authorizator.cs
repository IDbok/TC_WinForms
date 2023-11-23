namespace TC_WinForms.DataProcessing
{
    internal static class Authorizator
    {
        private static User authUser = null;
        public static string AuthUserName() => authUser.Name();

        private static Dictionary<int, User> Operators = new Dictionary<int, User>()
        {
            {1, new User("Александр", "Кузнецов")},
            {2, new User("Игорь", "Бокарев")},
            {3, new User("Павел", "Анохин")}
        };

        public static bool IsUserExust(string name, string surname)
        {
            
            foreach (var user in Operators.Values)
            {
                if (user.Name().ToLower() == name.ToLower() && user.Surname().ToLower() == surname.ToLower())
                {
                    // return an link to the user
                    authUser = user;
                    return true;
                }
            }
            return false;
            //return Operators.Values.Any(
            //    user => user.Name().ToLower() == name.ToLower() && 
            //    user.Surname().ToLower() == surname.ToLower()
            //    );
        }

        public class User
        {
            private string name;
            private string surname;
            public string Name() => name;
            public string Surname() => surname;
            public User(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
            }
            public User Copy()
            {
                return (User)this.MemberwiseClone();
            }
        }
    }
}
