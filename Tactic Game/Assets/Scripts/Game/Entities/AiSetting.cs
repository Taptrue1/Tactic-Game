using UnityEngine;

[System.Serializable]
public class AiSetting
{
    [SerializeField] private Cell _startCell;
    [SerializeField] private UnitType _aiType;

    private AI _ai;
    private const float _offset = 1;

    public void Init(UnitData defaultAiData, CellsPool cellPool)
    {
        var aiData = RandomizeData(defaultAiData);
        _ai = new AI();
        _ai.Init(aiData, cellPool);
        _startCell.SetOwner(aiData);

    }
    
    private UnitData RandomizeData(UnitData defaultAiData)
    {
        var attack = Random.Range(defaultAiData.Attack.Value - _offset, defaultAiData.Attack.Value + _offset);
        var defence = Random.Range(defaultAiData.Defence.Value - _offset, defaultAiData.Defence.Value + _offset);
        var reproduction = Random.Range(defaultAiData.Reproduction.Value - _offset, defaultAiData.Reproduction.Value + _offset);
        var speed = Random.Range(defaultAiData.Speed.Value - _offset, defaultAiData.Speed.Value + _offset);

        return new UnitData(_aiType, attack, defence, reproduction, speed);
    }
}
