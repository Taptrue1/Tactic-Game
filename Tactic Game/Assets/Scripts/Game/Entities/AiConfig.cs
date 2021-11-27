using UnityEngine;

[System.Serializable]
public class AiConfig
{
    [SerializeField] private Cell _startCell;

    public AI Init(CellsPool cellsPool, UnitData defaultAIData, UnitType aiType, float randomOffset)
    {
        var aiData = GenerateRandomData(defaultAIData, aiType, randomOffset);
        var ai = new AI();

        ai.Init(aiData, cellsPool);
        _startCell.SetOwner(aiData);

        return ai;
    }

    private UnitData GenerateRandomData(UnitData defaultData, UnitType aiType, float offset)
    {
        var attack = Random.Range(defaultData.Attack.Value - offset, defaultData.Attack.Value + offset);
        var defence = Random.Range(defaultData.Defence.Value - offset, defaultData.Defence.Value + offset);
        var reproduction = Random.Range(defaultData.Reproduction.Value - offset, defaultData.Reproduction.Value + offset);
        var speed = Random.Range(defaultData.Speed.Value - offset, defaultData.Speed.Value + offset);

        var aiData = new UnitData(aiType, attack, defence, reproduction, speed);

        return aiData;
    }
}
