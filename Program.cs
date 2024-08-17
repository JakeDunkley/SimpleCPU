using System.Collections;

public class Program
{
    public static void Main(string[] args)
    {
        Word testA = new();
        Word testB = new();

        testA[0] = true;
        testA[2] = true;
        testA[3] = true;

        testB[0] = true;
        testB[1] = true;
        testB[3] = true;
        testB[4] = true;

        Console.WriteLine(testA);
        Console.WriteLine(testA.ToInt());

        Console.WriteLine(testB);
        Console.WriteLine(testB.ToInt());

        Word testC = testA + testB;

        Console.WriteLine(testC);
        Console.WriteLine(testC.ToInt());
    }
}