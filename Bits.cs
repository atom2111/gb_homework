public class Bits{
    private long value;

    public Bits(long value){
        this.value = value;
    }

    // Оператор неявного приведения из long в Bits
    public static implicit operator Bits(long value){
        return new Bits(value);
    }

    // Оператор неявного приведения из int в Bits
    public static implicit operator Bits(int value){
        return new Bits(value);
    }

    // Оператор неявного приведения из byte в Bits
    public static implicit operator Bits(byte value){
        return new Bits(value);
    }

    public override string ToString()
    {
        return $"Bits with value: {value}";
    }
}