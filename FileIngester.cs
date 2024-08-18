public static class FileIngester
{
    public static List<string> GetLines(string relativePath)
    {
        List<string> lines = new();

        try
        {
            using (StreamReader reader = new StreamReader(relativePath))
            {
                string? curLine = reader.ReadLine();

                while (curLine != null)
                {
                    if (curLine != "" && curLine[0] != '#')
                    {
                        lines.Add(curLine);
                    }

                    curLine = reader.ReadLine();
                }
            }
        }

        catch (Exception e)
        {
            Console.WriteLine($"Error reading input file \"{relativePath}\": {e}");
        }

        return lines;
    }

    public static Word WordFromLine(string line)
    {
        Word result = new();

        for (int i = 0; i < result.Length; i++)
        {
            result[result.Length - 1 - i] = line[i] == '1';
        }

        return result;
    }

    public static MemoryModule GenerateMemoryModule(List<string> lines)
    {
        MemoryModule result = new(1024);

        for (int i = 0; i < lines.Count; i++)
        {
            result[i] = WordFromLine(lines[i]);
        }

        return result;
    }
}