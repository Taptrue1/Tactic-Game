using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI
{
    private UnitData _data;
    private CellsPool _pool;

    public void Init(UnitData data, CellsPool pool)
    {
        _data = data;
        _pool = pool;

        //StartCoroutine(Attack(5));
    }
    public IEnumerator StartAnalize(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);

            Cell target = FindWeakTarget();

            if (target == null) yield break;

            SendUnits(target);
        }
    }

    private void SendUnits(Cell target)
    {
        List<Cell> myCells = _pool.GetMyCells(_data.Type);

        foreach(Cell cell in myCells)
        {
            cell.SendUnits(target.transform);
        }
    }
    private Cell FindWeakTarget()
    {
        List<Cell> enemyCells = _pool.GetEnemyCells(_data.Type);

        if (enemyCells.Count < 1) return null;

        Cell target = enemyCells[0];
        
        foreach(Cell cell in enemyCells)
        {
            if (cell.Mass > target.Mass)
                target = cell;
        }

        return target;
    }
}