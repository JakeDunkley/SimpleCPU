public static class Decoder
{
    public static void JumpUnconditional(Word instruction)
    {
        CPU.ProgramCounter = instruction.DataAsWord;
    }

    public static void JumpEqualZero(Word instruction)
    {
        if (CPU.Accumulator.ToInt() == 0)
        {
            CPU.ProgramCounter = instruction.DataAsWord;
        }
    }
}