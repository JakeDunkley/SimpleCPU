public static class Decoder
{
    private static readonly Dictionary<int, Word> _registerLookup = new()
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

    // private static readonly Dictionary<int, Action<Word>> _functionLinks = new()
    // {
    //     {0b_01000000000000000000000000000000, Add},
    //     {0b_0101_0000000000000000000000000000, Subtract},
    //     {0b_0110_0000000000000000000000000000, Not},
    //     {0b_0111_0000000000000000000000000000, InclusiveOr},
    //     {0b_1000_0000000000000000000000000000, And},
    //     // {0b_1001_0000000000000000000000000000, ExclusiveOr},
    //     // {0b_1010_0000000000000000000000000000, JumpUnconditional},
    //     // {0b_1011_0000000000000000000000000000, JumpNotZero},
    //     // {0b_1100_0000000000000000000000000000, JumpEqualZero},
    //     // {0b_1101_0000000000000000000000000000, JumpLessThanZero},
    //     // {0b_1110_0000000000000000000000000000, JumpGreaterThanZero},
    //     // {0b_1111_0000000000000000000000000000, Halt}
    // };

    public static Dictionary<int, Word> RegisterLookup => _registerLookup;
    
    public static void Add(Word word)
    {
        CPU.Accumulator += word.DataAsWord;
    }

    public static void Subtract(Word word)
    {
        CPU.Accumulator -= word.DataAsWord;
    }

    public static void Not(Word word)
    {
        CPU.Accumulator = !CPU.Accumulator;
    }

    public static void InclusiveOr(Word word)
    {
        CPU.Accumulator |= word;
    }

    public static void And(Word word)
    {
        CPU.Accumulator &= word;
    }

    public static void ExclusiveOr(Word word)
    {
        CPU.Accumulator ^= word;
    }

    public static void JumpUnconditional(Word word)
    {
        CPU.ProgramCounter = word.DataAsWord;

        CPU.FlagNoIncrement = true;
    }

    public static void JumpNotZero(Word word)
    {
        if (CPU.Accumulator.ToInt() != 0)
        {
            CPU.ProgramCounter = word.DataAsWord;
        }

        CPU.FlagNoIncrement = true;
    }

    public static void JumpEqualZero(Word word)
    {
        if (CPU.Accumulator.ToInt() == 0)
        {
            CPU.ProgramCounter = word.DataAsWord;
        }

        CPU.FlagNoIncrement = true;
    }

    public static void JumpLessThanZero(Word word)
    {
        if (CPU.Accumulator.ToInt() < 0)
        {
            CPU.ProgramCounter = word.DataAsWord;
        }

        CPU.FlagNoIncrement = true;
    }

    public static void JumpGreaterThanZero(Word word)
    {
        if (CPU.Accumulator.ToInt() > 0)
        {
            CPU.ProgramCounter = word.DataAsWord;
        }

        CPU.FlagNoIncrement = true;
    }

    public static void Halt(Word word)
    {
        CPU.FlagHalt = true;
    }
}