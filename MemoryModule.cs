public class MemoryModule
{
    private MemoryWord[] _memory;

    public MemoryModule(int numWords)
    {
        _memory = new MemoryWord[numWords];

        for (int i = 0; i < numWords; i++)
        {
            _memory[i] = new MemoryWord();
        }
    }

    public MemoryWord[] Memory
    {
        get => _memory;
        set => _memory = value;
    }

    public void Dump()
    {
        for (int i = 0; i < Memory.Length; i++)
        {
            Console.WriteLine($"{i:0000} | {Memory[i]}");
        }
    }
}