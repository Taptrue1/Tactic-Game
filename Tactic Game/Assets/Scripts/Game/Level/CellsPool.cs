using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CellsPool : MonoBehaviour
{
    public List<Cell> Cells => _cells;
    
    private List<Cell> _cells;
    private UnitType _defaultType;

    public void Init(UnitData defaultData, GameObject unitPool)
    {
        _defaultType = defaultData.Type;
        _cells = GetAllCells();
        InitCells(defaultData, unitPool);
    }
    public List<Cell> GetEnemyCells(UnitType type) => _cells.Where(cell => cell.OwnerType != type).ToList();
    public List<Cell> GetMyCells(UnitType type) => _cells.Where(cell => cell.OwnerType == type).ToList();
    public bool IsEnemiesDefeated(UnitType playerType)
    {
        foreach (Cell cell in _cells)
        {
            if (cell.OwnerType != playerType && cell.OwnerType != _defaultType)
                return false;
        }
        return true;
    }
    public bool IsAllCellsCaptured()
    {
        var firstCell = _cells[0];
        foreach(Cell cell in _cells)
        {
            if (firstCell.OwnerType != cell.OwnerType)
                return false;
        }
        return true;
    }

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
    private void InitCells(UnitData defaultData, GameObject unitPool)
    {
        foreach(Cell cell in _cells)
        {
            cell.Init(defaultData, unitPool);
        }
    }
}