public static class Decoder
{
    private static readonly Dictionary<int, Word> registerLookup = new()
    {
        {0x00000000, CPU.RegisterA},
        {0x00000001, CPU.RegisterB},
        {0x00000002, CPU.RegisterC},
        {0x00000003, CPU.RegisterD},
        {0x00000004, CPU.RegisterE},
        {0x00000005, CPU.RegisterF},
        {0x00000006, CPU.RegisterG},
        {0x00000007, CPU.RegisterH},
    };

    public static void Add(Word instruction)
    {
        int register = instruction.DataAsWord.ToInt();
    }

    public static void JumpUnconditional(Word instruction)
    {
        CPU.ProgramCounter = instruction.DataAsWord;

        CPU.FlagNoIncrement = true;
    }

    public static void JumpNotZero(Word instruction)
    {
        if (CPU.Accumulator.ToInt() != 0)
        {
            CPU.ProgramCounter = instruction.DataAsWord;
        }

        CPU.FlagNoIncrement = true;
    }

    public static void JumpEqualZero(Word instruction)
    {
        if (CPU.Accumulator.ToInt() == 0)
        {
            CPU.ProgramCounter = instruction.DataAsWord;
        }

        CPU.FlagNoIncrement = true;
    }

    public static void JumpLessThanZero(Word instruction)
    {
        if (CPU.Accumulator.ToInt() < 0)
        {
            CPU.ProgramCounter = instruction.DataAsWord;
        }

        CPU.FlagNoIncrement = true;
    }

    public static void JumpGreaterThanZero(Word instruction)
    {
        if (CPU.Accumulator.ToInt() > 0)
        {
            CPU.ProgramCounter = instruction.DataAsWord;
        }

        CPU.FlagNoIncrement = true;
    }

    public static void Halt()
    {
        CPU.FlagHalt = true;
    }
}