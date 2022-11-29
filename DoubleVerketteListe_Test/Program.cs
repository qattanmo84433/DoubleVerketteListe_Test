namespace DoubleVerketteListe_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {

            MyList students = new MyList();
            students.AddSort("Aziz");
            students.AddSort("Mali");
            students.AddSort("Hareth");
            students.AddSort("Abi");
            //students.Remove("Mali");
            //students.Remove("Hareth");
            //students.Remove("Abi");
            //students.Remove("Aziz");
            //students.Remove("Aziz");
            foreach (var item in students)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}