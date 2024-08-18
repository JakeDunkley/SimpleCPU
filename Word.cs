using System.Collections;
using System.Text;

/// <summary>
/// Represents a 32-bit word
/// </summary>
public class Word
{

    private static readonly int _length = 32;
    private BitArray _bits;

    public Word()
    {
        _bits = new BitArray(_length);
    }

    public int Length => _length;

    public BitArray Bits
    {
        get => _bits;
        set => _bits = value;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder(_length);

        for (int i = _length - 1; i >= 0; i--)
        {
            stringBuilder.Append(this[i] ? 1 : 0);
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

    public virtual uint ToUInt()
    {
        uint result = 0;

        foreach (bool bit in _bits)
        {
            result <<= 1;
            result += (uint) (bit ? 1 : 0);
        }

        return result;
    }

    public Word Clone()
    {
        Word clone = new();

        for (int i = 0; i < Length; i++)
        {
            clone[i] = this[i];
        }

        return clone;
    }

    public static Word Zero
    {
        get
        {
            return new Word();
        }
    }

    public static Word One
    {
        get
        {
            Word one = new();
            one[0] = true;

            return one;
        }
    }

    /// <summary>
    /// Create word from the segment of the word containing the operation code.
    /// </summary>
    public Word OpCodeAsWord
    {
        get
        {
            Word opCode = new();

            for (int i = 0; i < 4; i++)
            {
                opCode[_length - 1 - i] = this[_length - 1 - i];
            }

            return opCode;
        }
    }

    /// <summary>
    /// Create word from the segment of the word containing literal or address values
    /// </summary>
    public Word DataAsWord
    {
        get
        {
            Word data = new();

            for (int i = 0; i < _length - 4; i++)
            {
                data[i] = this[i];
            }

            return data;
        }
    }

    public bool this[int index]
    {
        get => _bits[_length - 1 - index];
        set => _bits[_length - 1 - index] = value;
    }

    public static Word operator +(Word a, Word b)
    {
        Word sum = new();

        bool carryBit = false;

        for(int i = 0; i < _length; i++)
        {
            int total = (a[i] ? 1 : 0) + (b[i] ? 1 : 0) + (carryBit ? 1 : 0);

            if (total < 2)
            {
                sum[i] = total > 0;
                carryBit = false;
            }

            else
            {
                sum[i] = total == 3;
                carryBit = true;
            }
        }

        return sum;
    }

    public static Word operator -(Word a, Word b)
    {
        Word notB = !b;

        notB += One;

        return a + notB;
    }

    public static Word operator !(Word word)
    {
        Word result = new();

        for (int i = 0; i < _length; i++)
        {
            result[i] = !word[i];
        }

        return result;
    }

    public static Word operator &(Word a, Word b)
    {
        Word result = new();

        for (int i = 0; i < _length; i++)
        {
            result[i] = a[i] & b[i];
        }

        return result;
    }

    public static Word operator |(Word a, Word b)
    {
        Word result = new();

        for (int i = 0; i < _length; i++)
        {
            result[i] = a[i] | b[i];
        }

        return result;
    }

    public static Word operator ^(Word a, Word b)
    {
        Word result = new();

        for (int i = 0; i < _length; i++)
        {
            result[i] = a[i] ^ b[i];
        }

        return result;
    }
}