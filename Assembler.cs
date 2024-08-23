using System.Text;

public static class Assembler
{
    private static readonly Dictionary<string, string> _opCodesToBits = new()
    {
        {"LDI", "0000"},
        {"LDR", "0001"},
        {"MOV", "0010"},
        {"SAV", "0011"},
        {"ADD", "0100"},
        {"SUB", "0101"},
        {"NOT", "0110"},
        {"IOR", "0111"},
        {"AND", "1000"},
        {"XOR", "1001"},
        {"JMP", "1010"},
        {"JNZ", "1011"},
        {"JEZ", "1100"},
        {"JLZ", "1101"},
        {"JGZ", "1110"},
        {"HLT", "1111"}
    };

    // Not Finished
    public static List<string> Assemble(string relativePath)
    {
        List<string> lines = FileHandler.GetLines(relativePath);

        List<string> binary = new();

        for (int i = 0; i < lines.Count; i++)
        {
            StringBuilder curLine = new();

            try
            {
                curLine.Append(_opCodesToBits[lines[i][..3]]);
            }

            catch (Exception e)
            {
                Console.WriteLine($"Error assembling file \"relativePath\": {e}");
            }
        }

        return lines;
    }
}