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

    public void Dump()
    {
        for (int i = 0; i < Memory.Length; i++)
        {
            Console.WriteLine($"{i:0000} | {Memory[i]}");
        }
    }
}