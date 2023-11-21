namespace TC_WinForms.DataProcessing
{
    internal static class Authorizator
    {
        private static Dictionary<int, User> Operators = new Dictionary<int, User>()
        {
            {1, new User("Александр", "Кузнецов")},
            {2, new User("Игорь", "Бокарев")},
            {3, new User("Павел", "Анохин")}
        };

        public static bool IsUserExust(string name, string surname)
        {
            return Operators.Values.Any(
                user => user.Name().ToLower() == name.ToLower() && 
                user.Surname().ToLower() == surname.ToLower()
                );
        }

        private class User
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
        }
    }
}
