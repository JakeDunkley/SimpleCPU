using System.Collections;

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Loading program...");
        CPU.LoadProgram("program.txt");
        Console.WriteLine(" Done!");

        CPU.Run();
    }
}