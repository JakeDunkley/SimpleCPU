public static class CPU
{
    private static Word _programCounter = new Word();
    private static Word _accumulator    = new Word();
    private static Word _registerA      = new Word();
    private static Word _registerB      = new Word();
    private static Word _registerC      = new Word();
    private static Word _registerD      = new Word();
    private static Word _registerE      = new Word();
    private static Word _registerF      = new Word();
    private static Word _registerG      = new Word();
    private static Word _registerH      = new Word();
    private static MemoryModule  _ram   = new MemoryModule(1024);

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
}