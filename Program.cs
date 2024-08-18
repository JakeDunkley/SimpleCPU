using System.Collections;

public class Program
{
    public static void Main(string[] args)
    {
        CPU.LoadProgram("program.txt");

        CPU.RAM.Dump();
    }
}