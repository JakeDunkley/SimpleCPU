public static class CPU
{
    private static OperationWord _programCounter = new OperationWord();
    private static OperationWord _accumulator    = new OperationWord();
    private static OperationWord _registerA      = new OperationWord();
    private static OperationWord _registerB      = new OperationWord();
    private static OperationWord _registerC      = new OperationWord();
    private static OperationWord _registerD      = new OperationWord();
    private static OperationWord _registerE      = new OperationWord();
    private static OperationWord _registerF      = new OperationWord();
    private static OperationWord _registerG      = new OperationWord();
    private static OperationWord _registerH      = new OperationWord();
    private static MemoryModule  _ram            = new MemoryModule(1024);

    public static OperationWord ProgramCounter
    {
        get => _programCounter;
        set => _programCounter = value;
    }

    public static OperationWord Accumulator
    {
        get => _programCounter;
        set => _programCounter = value;
    }

    public static OperationWord RegisterA
    {
        get => _programCounter;
        set => _programCounter = value;
    }

    public static OperationWord RegisterB
    {
        get => _programCounter;
        set => _programCounter = value;
    }

    public static OperationWord RegisterC
    {
        get => _programCounter;
        set => _programCounter = value;
    }

    public static OperationWord RegisterD
    {
        get => _programCounter;
        set => _programCounter = value;
    }

    public static OperationWord RegisterE
    {
        get => _programCounter;
        set => _programCounter = value;
    }

    public static OperationWord RegisterF
    {
        get => _programCounter;
        set => _programCounter = value;
    }

    public static OperationWord RegisterG
    {
        get => _programCounter;
        set => _programCounter = value;
    }

    public static OperationWord RegisterH
    {
        get => _programCounter;
        set => _programCounter = value;
    }

    public static MemoryModule RAM
    {
        get => _ram;
        set => _ram = value;
    }
}