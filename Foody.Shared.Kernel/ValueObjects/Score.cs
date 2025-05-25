namespace Foody.Shared.Kernel.ValueObjects;

public readonly struct Score
{
    private readonly float _value;

    private Score(float value)
    {
        if (value is < 1 or > 10)
            throw new ArgumentOutOfRangeException(nameof(value), "Score must be between 1 and 10");
        _value = value;
    }
    
    public static implicit operator float(Score score) => score._value;
    public static explicit operator Score(float value) => new(value);
}