using System;
using UnityEngine;
[System.Serializable]
public class Characteristic
{
    public float Value => _value;

    [SerializeField] private UpgradeData _data;
    [SerializeField] private float _value;
    [SerializeField] private int _price;

    public Characteristic(float value, int price = 0, UpgradeData data = null)
    {
        _value = value;
        _price = price;
        _data = data;
    }

    public int Upgrade(int money)
    {
        var price = _price;

        if(CanUpgrade(money))
        {
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

            return price;
        }

        return 0;
    }

    private bool CanUpgrade(int money) => money >= _price;
}