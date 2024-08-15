using System.Collections;
using System.Text;

public abstract class Word
{
    private BitArray _bits;

    public Word(int numBits)
    {
        _bits = new BitArray(numBits);
    }

    public BitArray Bits
    {
        get => _bits;
        set => _bits = value;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder(_bits.Length);

        foreach (bool bit in _bits)
        {
            stringBuilder.Append($"{(bit ? 1 : 0)}");
        }

        return stringBuilder.ToString();
    }
}