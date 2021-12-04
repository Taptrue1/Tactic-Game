using System.Collections;
using UnityEngine;

public class Referee
{
    private CellsPool _cellsPool;
    private GameObject _unitsPool;
    private UnitType _playerType;
    private float _checkDelay;
    private InformationMover _informationMover;

    public void Init(CellsPool cellsPool, GameObject unitsPool, UnitType playerType, float checkDelay, InformationMover informationMover)
    {
        _cellsPool = cellsPool;
        _unitsPool = unitsPool;
        _playerType = playerType;
        _checkDelay = checkDelay;
        _informationMover = informationMover;
    }
    public IEnumerator StartCheckLoop()
    {
        bool isGameOver = false;
        while(!isGameOver)
        {
            var isUnitsPoolEmpty = _unitsPool.transform.childCount == 0;
            var isAIDefeated = _cellsPool.IsEnemiesDefeated(_playerType);
            var isPlayerDefeated = _cellsPool.IsPlayerDefeated(_playerType);

            isGameOver = isUnitsPoolEmpty && (isAIDefeated || isPlayerDefeated);

            if (isPlayerDefeated)
                _informationMover.GameOver(false);
            else if (isAIDefeated)
                _informationMover.GameOver(true);

            yield return new WaitForSeconds(_checkDelay);
        }

        Debug.Log("Game is Over");
    }
}