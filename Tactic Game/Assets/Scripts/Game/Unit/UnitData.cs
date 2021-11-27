[System.Serializable]
public class UnitData
{
    public UnitType Type => _type;
    public Characteristic Attack => _attack;
    public Characteristic Defence => _defence;
    public Characteristic Reproduction => _reproduction;
    public Characteristic Speed => _speed;

    private UnitType _type;
    private Characteristic _attack;
    private Characteristic _defence;
    private Characteristic _reproduction;
    private Characteristic _speed;

    public UnitData(UnitType type, float attack, float defence, float reproduction, float speed)
    {
        _type = type;
        _attack = new Characteristic(attack);
        _defence = new Characteristic(defence);
        _reproduction = new Characteristic(reproduction);
        _speed = new Characteristic(speed);
    }
    public UnitData(UnitType type, Characteristic attack, Characteristic defence, Characteristic reproduction, Characteristic speed)
    {
        _type = type;
        _attack = attack;
        _defence = defence;
        _reproduction = reproduction;
        _speed = speed;
    }
}
