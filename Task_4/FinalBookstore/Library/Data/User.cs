using System.Threading;

namespace BookstoreLogic.Data
{
    public class User
    {
        public static int UserIDCounter = -1;

        public int ID { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BooksNumber { get; set; }

        /* Creating user */
        public User(string firstName, string lastName)
        {
            ID = Interlocked.Increment(ref UserIDCounter);
            FirstName = firstName;
            LastName = lastName;
            BooksNumber = 0;
        }

        /* Editing user */
        public void UpdateUser(UserUpdateData data)
        {
            FirstName = data.name;
            LastName = data.surname;
        }



        public void AddBook ()
        {
            BooksNumber++;
        }

        public void RemoveBook ()
        {
            BooksNumber--;
        }

        public string GetUserName()
        {
            return FirstName + ' ' + LastName;
        }

        public override string ToString()
        {
            return "[ID: " + ID + "],  Name: " + GetUserName() + ",    Amount of sold books: " + BooksNumber;
        }
    }




    public class UserUpdateData
    {
        public int userId;
        public string name;
        public string surname;

        public UserUpdateData(int userId, string name, string surname)
        {
            this.userId = userId;
            this.name = name;
            this.surname = surname;
        }
    }
}
