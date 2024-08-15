using System.Collections;

public class MemoryWord : Word
{
    public MemoryWord() : base(40) {}

    public BitArray OperationWordA
    {
        get
        {
            BitArray operationWord = new(16);

            for (int i = 0; i < 16; i++)
            {
                operationWord.Set(i, Bits.Get(i + 8));
            }

            return operationWord;
        }
    }

    public BitArray OperationWordB
    {
        get
        {
            BitArray operationWord = new(16);

            for (int i = 0; i < 16; i++)
            {
                operationWord.Set(i, Bits.Get(i + 8));
            }

            return operationWord;
        }
    }
}