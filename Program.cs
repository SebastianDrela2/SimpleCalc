namespace Test
{
    public class Program
    {        
        internal static void Main()
        {
            var calculator = new Calculator();
            var calculator2 = new Calculator2();

            var result1 = calculator.Calculate("1 + 5 + 5 - 10");
            calculator2.Calculate("1 + 5 + 5 - 10");

            var result2 = calculator2.TotalValue;

            Console.WriteLine(result1);
            Console.WriteLine(result2);
        }
    }
}
