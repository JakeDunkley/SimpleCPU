public static class Decoder
{
    private static readonly Dictionary<int, Word> _registerLookup = new()
    {
        {0, CPU.RegisterA},
        {1, CPU.RegisterB},
        {2, CPU.RegisterC},
        {3, CPU.RegisterD},
        {4, CPU.RegisterE},
        {5, CPU.RegisterF},
        {6, CPU.RegisterG},
        {7, CPU.RegisterH},
    };

    private static readonly Dictionary<uint, Action<Word>> _execute = new()
    {
        {0b_0000_0000000000000000000000000000, LoadImmediate},
        {0b_0001_0000000000000000000000000000, LoadRegister},
        {0b_0010_0000000000000000000000000000, MoveAccumulator},
        {0b_0011_0000000000000000000000000000, SaveAccumulator},
        {0b_0100_0000000000000000000000000000, Add},
        {0b_0101_0000000000000000000000000000, Subtract},
        {0b_0110_0000000000000000000000000000, Not},
        {0b_0111_0000000000000000000000000000, InclusiveOr},
        {0b_1000_0000000000000000000000000000, And},
        {0b_1001_0000000000000000000000000000, ExclusiveOr},
        {0b_1010_0000000000000000000000000000, JumpUnconditional},
        {0b_1011_0000000000000000000000000000, JumpNotZero},
        {0b_1100_0000000000000000000000000000, JumpEqualZero},
        {0b_1101_0000000000000000000000000000, JumpLessThanZero},
        {0b_1110_0000000000000000000000000000, JumpGreaterThanZero},
        {0b_1111_0000000000000000000000000000, Halt}
    };

    public static Dictionary<int, Word> RegisterLookup => _registerLookup;

    public static Dictionary<uint, Action<Word>> Execute => _execute;

    public static void LoadImmediate(Word word)
    {
        CPU.Accumulator = word.DataAsWord;
    }

    public static void LoadRegister(Word word)
    {
        CPU.Accumulator = RegisterLookup[word.DataAsWord.ToInt()].Clone();
    }

    public static void MoveAccumulator(Word word)
    {
        RegisterLookup[word.DataAsWord.ToInt()] = CPU.Accumulator.Clone();
    }

    public static void SaveAccumulator(Word word)
    {
        CPU.RAM[word.DataAsWord.ToInt()] = CPU.Accumulator.Clone();
    }
    
    public static void Add(Word word)
    {
        CPU.Accumulator += RegisterLookup[word.DataAsWord.ToInt()];
    }

    public static void Subtract(Word word)
    {
        CPU.Accumulator -= RegisterLookup[word.DataAsWord.ToInt()];
    }

    public static void Not(Word word)
    {
        CPU.Accumulator = !CPU.Accumulator;
    }

    public static void InclusiveOr(Word word)
    {
        CPU.Accumulator |= RegisterLookup[word.DataAsWord.ToInt()];;
    }

    public static void And(Word word)
    {
        CPU.Accumulator &= RegisterLookup[word.DataAsWord.ToInt()];;
    }

    public static void ExclusiveOr(Word word)
    {
        CPU.Accumulator ^= RegisterLookup[word.DataAsWord.ToInt()];;
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