public class MemoryModule
{
    private Word[] _memory;

    public MemoryModule(int numWords)
    {
        _memory = new Word[numWords];

        for (int i = 0; i < numWords; i++)
        {
            _memory[i] = new Word();
        }
    }

    public Word[] Memory
    {
        get => _memory;
        set => _memory = value;
    }

    public Word this[int index]
    {
        get => _memory[index];
        set => _memory[index] = value;
    }

    public void Dump(int rangeStart = 0, int rangeEnd = 0)
    {
        if (rangeEnd == 0)
        {
            rangeEnd = Memory.Length;
        }

        for (int i = rangeStart; i < rangeEnd; i++)
        {
            Console.WriteLine($"{i:0000} | {Memory[i]}");
        }
    }
}