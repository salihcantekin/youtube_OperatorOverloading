using System;

namespace OperatorOverloading
{
    public class Program
    {
        static void Main(string[] args)
        {
            User userDb = new User() { Id = 1, FullName = "" };

            User userApi = new User() { Id = 1, FullName = "Salih Cantekin" };

            if (userDb)
            {
                System.Console.WriteLine("User db not empty");
            }
            else
                System.Console.WriteLine("User db empty");

            //System.Console.WriteLine(userDb == userApi);


        }




        private static void SampleDecimalNumber()
        {
            DecimalNumber number1 = new DecimalNumber(0);
            DecimalNumber number2 = new DecimalNumber(10);

            // System.Console.WriteLine(number1 != 65);

            var newNumber = number1 + 25;

            //System.Console.WriteLine(newNumber.Value);

            if (number1)
                System.Console.WriteLine("Greater than zero");
            else
                System.Console.WriteLine("NOT Greater than zero");
        }

        private static void Sample()
        {
            /*
                    + - * /
                    == =! < > <= >=
                    true false
                    && || ?? ? += -= *= /=
                */

            int number1 = 1;
            int number2 = 2;

            int newNumber = number1 + number2;
            newNumber = number1 / number2;
            newNumber = number1 * number2;
            newNumber = number1 - number2;

            var eq = number2 == number1;
            eq = number2 != number1;
            eq = number2 < number1;
            eq = number2 >= number1;

            if (eq)
            {

            }
        }
    }


    public class User
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public static bool operator ==(User u1, User u2) => u1.Id == u2.Id;
        public static bool operator !=(User u1, User u2) => u1.Id != u2.Id;

        public static bool operator true(User user) => user.Id > 0 && !string.IsNullOrEmpty(user.FullName);
        public static bool operator false(User user) => user.Id <= 0 || string.IsNullOrEmpty(user.FullName);
    }


    public class DecimalNumber
    {
        public decimal Value { get; set; }
        public int Precision { get; set; }

        public DecimalNumber(decimal value)
        {
            this.Value = value;
        }

        public static DecimalNumber operator +(DecimalNumber number1, DecimalNumber number2)
        {
            return new DecimalNumber(number1.Value + number2.Value);
        }

        public static DecimalNumber operator +(DecimalNumber number1, int number2)
        {
            return new DecimalNumber(number1.Value + number2);
        }

        public static bool operator ==(DecimalNumber number1, DecimalNumber number2)
        {
            return number1.Value == number2.Value && number1.Precision == number2.Precision;
        }

        public static bool operator ==(DecimalNumber number1, int number2)
        {
            return number1.Value == number2;
        }

        public static bool operator !=(DecimalNumber number1, int number2)
        {
            return number1.Value != number2;
        }

        public static bool operator !=(DecimalNumber number1, DecimalNumber number2)
        {
            return number1.Value != number2.Value;
        }

        public static bool operator true(DecimalNumber number) => number.Value > 0;
        public static bool operator false(DecimalNumber number) => number.Value <= 0;

    }




}
