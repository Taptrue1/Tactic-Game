public class UnitData
{
    public UnitType Type => _type;
    public int Attack => _attack;
    public int Defence => _defence;
    public int Reproduction => _reproduction;
    public int Speed => _speed;

    private UnitType _type;
    private int _attack;
    private int _defence;
    private int _reproduction;
    private int _speed;

    public UnitData(UnitType type)
    {
        _type = type;
    }
}
