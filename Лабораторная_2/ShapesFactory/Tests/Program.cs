

namespace Tests
{
    //abstract Product
    public class Program
    {
        static void Main(string[] args)
        {
            byte[] bytes1 = new byte[5];
            Random rnd1 = new Random();
            rnd1.NextBytes(bytes1);
            for (int ctr = bytes1.GetLowerBound(0);
                 ctr <= bytes1.GetUpperBound(0);
                 ctr++)
            {
                Console.Write("{0, 5}", bytes1[ctr]);
            }
        }
    }
}
