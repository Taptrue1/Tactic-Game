using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CellsPool : MonoBehaviour
{
    public List<Cell> Cells => _cells;

    [SerializeField] private UnitData _defaultData;

    private List<Cell> _cells;


    private void Awake()
    {
        _defaultData = new UnitData(new UnitType(), 0, 0, 0, 0);
        _cells = GetAllCells();
        InitializeCells();
    }

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
    private void InitializeCells()
    {
        foreach(Cell cell in _cells)
        {
            cell.Init(_defaultData);
        }
    }
}
