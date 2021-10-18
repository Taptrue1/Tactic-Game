public class Characteristic
{
    public float Value => _value;

    private float _value;
    private float _upgradeCoeff;
    private int _upgradePrice;
    private float _priceCoeff;

    public Characteristic(float startValue, float upgradeCoeff, int upgradePrice, float priceCoeff)
    {
        _value = startValue;
        _upgradeCoeff = upgradeCoeff;
        _upgradePrice = upgradePrice;
        _priceCoeff = priceCoeff;
    }

    public int Upgrade(int money)
    {
        var resultMoney = money;

        if(CanUpgrade(money))
        {
            resultMoney -= _upgradePrice;
            _value += _upgradeCoeff;
            _upgradePrice += (int)_priceCoeff;
        }

        return resultMoney;
    }

    private bool CanUpgrade(int money) => money >= _upgradePrice;
}
