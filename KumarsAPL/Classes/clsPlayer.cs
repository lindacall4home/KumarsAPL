using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KumarsAPL.Classes
{


    public class clsPlayer
    {
        private int playerID;
        public int PlayerID
        {
            get { return playerID; }
            set { playerID = value; }
        }

        private bool active = true;
        public bool Active
        {
            get { return active; }
            set { active = value; }
        }


        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string FullName
        {
            get { return lastName + ", " + firstName + " (" + rank.ToString("n0") + ")"; }
        }

        private int grade;
        public int Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        private DateTime birthday;
        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        public int Age
        {
            get { return (int)Decimal.Floor(DateTime.Today.Subtract(birthday).Days / 365); }
        }

        private string tShirtSize;
        public string TShirtSize
        {
            get { return tShirtSize; }
            set { tShirtSize = value; }
        }

        private string gender;
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        private bool turnedInForm = false;
        public bool TurnedInForm
        {
            get { return turnedInForm; }
            set { turnedInForm = value; }
        }

        private bool paid = false;
        public bool Paid
        {
            get { return paid; }
            set { paid = value; }
        }

        private int rank;
        public int Rank
        {
            get { return rank; }
            set { rank = value; }
        }
    }
    public class clsComparePlayersByBirthday : IComparer<clsPlayer>
    {
        public int Compare(clsPlayer x, clsPlayer y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    if (x.Birthday == y.Birthday)
                        return 0;

                    return x.Birthday.CompareTo(y.Birthday); //sort decending;
                }
            }
        }
    }

    public class clsComparePlayersByAge : IComparer<clsPlayer>
    {
        public int Compare(clsPlayer x, clsPlayer y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    if (x.Age == y.Age)
                        return 0;

                    return x.Age.CompareTo(y.Age) * -1; //sort decending;
                }
            }
        }
    }
    public class clsComparePlayersByRank : IComparer<clsPlayer>
    {
        public int Compare(clsPlayer x, clsPlayer y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    return x.Rank.CompareTo(y.Rank);
                }
            }
        }
    }
}

