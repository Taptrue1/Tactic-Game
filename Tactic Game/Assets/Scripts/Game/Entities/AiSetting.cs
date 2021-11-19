using UnityEngine;

public class AiSetting
{
    [SerializeField] private Cell _startCell;
    [SerializeField] private UnitType _aiType;

    private AI _ai;

    public void Init()
    {
        _ai = new AI();
        _startCell.SetOwner()
    }
}
