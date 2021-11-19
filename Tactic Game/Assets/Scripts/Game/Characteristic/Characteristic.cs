using System;

public class Characteristic
{
    public float Value => _value;

    private float _value;
    private int _price;

    private UpgradeData _data;

    public Characteristic(float value, int price = 0, UpgradeData data = null)
    {
        _value = value;
        _price = price;
        _data = data;
    }

    public int Upgrade(int money)
    {
        var resultMoney = money;

        if(CanUpgrade(money))
        {
            resultMoney -= _price;

            switch(_data.BonusOperation)
            {
                case Operation.Add: _value += _data.BonusCoeff; break;
                case Operation.Multiply: _value *= _data.BonusCoeff; break;
            }

            switch(_data.PriceOperation)
            {
                case Operation.Add: _price = (int)_data.PriceCoeff; break;
                case Operation.Multiply: _price =  Convert.ToInt32(_price * _data.PriceCoeff); break;
            }
        }

        return resultMoney;
    }

    private bool CanUpgrade(int money) => money >= _price;
}