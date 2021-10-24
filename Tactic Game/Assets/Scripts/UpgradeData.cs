using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeData", order = 0)]
public class UpgradeData : ScriptableObject
{
    public float BonusCoeff => _bonusCoefficient;
    public float PriceCoeff => _priceCoefficient;
    public Operation BonusOperation => _bonusOperation;
    public Operation PriceOperation => _priceOperation;

    [SerializeField] private float _bonusCoefficient;
    [SerializeField] private float _priceCoefficient;
    [SerializeField] private Operation _bonusOperation;
    [SerializeField] private Operation _priceOperation;
}
public enum Operation
{
    Add,
    Multiply
}