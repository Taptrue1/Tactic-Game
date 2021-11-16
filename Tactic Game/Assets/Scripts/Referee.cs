using System.Collections;
using UnityEngine;

public class Referee
{
    private CellsPool _cellsPool;
    private GameObject _unitsPool;
    private float _checkDelay;

    public void Init(CellsPool cellsPool, GameObject unitsPool, float checkDelay)
    {
        _cellsPool = cellsPool;
        _unitsPool = unitsPool;
        _checkDelay = checkDelay;
    }
    public IEnumerator StartCheckLoop()
    {
        while(!IsGameOver())
        {
            yield return new WaitForSeconds(_checkDelay);
        }

        Debug.Log("Game is Over");
    }

    private bool IsGameOver()
    {
        var isUnitsPoolEmpty = _unitsPool.transform.childCount == 0;

        return isUnitsPoolEmpty && _cellsPool.IsAllCellsCaptured();
    }
}