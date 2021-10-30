using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CellsPool : MonoBehaviour
{
    public List<Cell> Cells => _cells;

    private List<Cell> _cells;

    public void Init(UnitData defaultData)
    {
        _cells = GetAllCells();
        InitCells(defaultData);
    }
    public List<Cell> GetEnemyCells(UnitType type) => _cells.Where(cell => cell.Type != type).ToList();
    public List<Cell> GetMyCells(UnitType type) => _cells.Where(cell => cell.Type == type).ToList();

    private List<Cell> GetAllCells()
    {
        List<Cell> cells = new List<Cell>();
        foreach(Transform child in gameObject.transform)
        {
            if (child.TryGetComponent(out Cell cell))
                cells.Add(cell);
        }
        return cells;
    }
    private void InitCells(UnitData defaultData)
    {
        foreach(Cell cell in _cells)
        {
            cell.Init(defaultData);
        }
    }
}