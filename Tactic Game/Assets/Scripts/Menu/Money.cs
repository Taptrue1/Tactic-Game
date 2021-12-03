using System;

public class Money
{
    public int Value => _value;
    public Action<int> MoneyChanged;

    private int _value;

    public void Add(int value)
    {
        if (value < 0) return;

        _value += value;

        MoneyChanged?.Invoke(value);
    }
    public void Subtract(int value)
    {
        if (value < 0) return;

        _value -= value;

        MoneyChanged?.Invoke(value);
    }
}
