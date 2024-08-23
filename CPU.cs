public static class CPU
{
    private static bool _flagHalt            = false;
    private static bool _flagNoIncrement     = false;
    private static bool _flagDoubleIncrement = false;
    private static Word _programCounter = new();
    private static Word _accumulator    = new();
    private static Word _registerA      = new();
    private static Word _registerB      = new();
    private static Word _registerC      = new();
    private static Word _registerD      = new();
    private static Word _registerE      = new();
    private static Word _registerF      = new();
    private static Word _registerG      = new();
    private static Word _registerH      = new();
    private static MemoryModule _ram = new(1024);

    public static bool FlagHalt
    {
        get => _flagHalt;
        set => _flagHalt = value;
    }

    public static bool FlagNoIncrement
    {
        get => _flagNoIncrement;
        set => _flagNoIncrement = value;
    }

    public static bool FlagDoubleIncrement
    {
        get => _flagDoubleIncrement;
        set => _flagDoubleIncrement = value;
    }

    public static Word ProgramCounter
    {
        get => _programCounter;
        set => _programCounter = value;
    }

    public static Word Accumulator
    {
        get => _accumulator;
        set => _accumulator = value;
    }

    public static Word RegisterA
    {
        get => _registerA;
        set => _registerA = value;
    }

    public static Word RegisterB
    {
        get => _registerB;
        set => _registerB = value;
    }

    public static Word RegisterC
    {
        get => _registerC;
        set => _registerC = value;
    }

    public static Word RegisterD
    {
        get => _registerD;
        set => _registerD = value;
    }

    public static Word RegisterE
    {
        get => _registerE;
        set => _registerE = value;
    }

    public static Word RegisterF
    {
        get => _registerF;
        set => _registerF = value;
    }

    public static Word RegisterG
    {
        get => _registerG;
        set => _registerG = value;
    }

    public static Word RegisterH
    {
        get => _registerH;
        set => _registerH = value;
    }

    public static MemoryModule RAM
    {
        get => _ram;
        set => _ram = value;
    }

    public static void DumpStatus()
    {
        Console.WriteLine($"FLAG Halt         | {(_flagHalt ? 1 : 0)}");
        Console.WriteLine($"FLAG No Increment | {(_flagNoIncrement ? 1 : 0)}");
        Console.WriteLine($"FLAG 2x Increment | {(_flagDoubleIncrement ? 1 : 0)}");
        Console.WriteLine($"Program Counter   | {_programCounter}");
        Console.WriteLine($"Accumulator       | {_accumulator}");
        Console.WriteLine($"Register A        | {_registerA}");
        Console.WriteLine($"Register B        | {_registerB}");
        Console.WriteLine($"Register C        | {_registerC}");
        Console.WriteLine($"Register D        | {_registerD}");
        Console.WriteLine($"Register E        | {_registerE}");
        Console.WriteLine($"Register F        | {_registerF}");
        Console.WriteLine($"Register G        | {_registerG}");
        Console.WriteLine($"Register H        | {_registerH}");
    }

    public static void LoadProgram(string relativePath)
    {
        _ram = FileHandler.GenerateMemoryModule(FileHandler.GetLines(relativePath));
    }

    public static void Run()
    {
        while (!_flagHalt)
        {
            Decoder.Execute[RAM[_programCounter.ToInt()].OpCodeAsWord.ToUInt()](RAM[_programCounter.ToInt()]);

            if (!_flagNoIncrement)
            {
                _programCounter += Word.One;
            }

            if (_flagDoubleIncrement)
            {
                _programCounter += Word.One;
            }

            _flagNoIncrement     = false;
            _flagDoubleIncrement = false;
        }
    }

    public static void Step()
    {
        if (!_flagHalt)
        {
            Decoder.Execute[RAM[_programCounter.ToInt()].OpCodeAsWord.ToUInt()](RAM[_programCounter.ToInt()]);

            if (!_flagNoIncrement)
            {
                _programCounter += Word.One;
            }

            if (_flagDoubleIncrement)
            {
                _programCounter += Word.One;
            }

            _flagNoIncrement     = false;
            _flagDoubleIncrement = false;
        }
    }
}