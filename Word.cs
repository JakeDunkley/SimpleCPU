using System.Collections;
using System.Text;

public class Word
{
    private BitArray _bits;

    public Word()
    {
        _bits = new BitArray(32);
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

    public virtual int ToInt()
    {
        int result = 0;

        foreach (bool bit in _bits)
        {
            result <<= 1;
            result += bit ? 1 : 0;
        }

        return result;
    }

    public BitArray OpBits
    {
        get
        {
            BitArray opBits = new(4);

            for (int i = 0; i < 4; i++)
            {
                opBits.Set(i, _bits.Get(i));
            }

            return opBits;
        }
    }

    public BitArray DataBits
    {
        get
        {
            BitArray dataBits = new(_bits.Length - 4);

            for (int i = 4; i < _bits.Length; i++)
            {
                dataBits.Set(i, _bits.Get(i));
            }

            return dataBits;
        }
    }

    public Word DataAsWord
    {
        get
        {
            BitArray paddedDataBits = new(_bits.Length);
            BitArray dataBits = DataBits;

            for (int i = 4; i < _bits.Length; i++)
            {
                paddedDataBits.Set(i, dataBits.Get(i));
            }

            return new Word(){Bits = paddedDataBits};
        }
    }
}