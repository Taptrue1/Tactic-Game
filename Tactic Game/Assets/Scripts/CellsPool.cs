using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CellsPool : MonoBehaviour
{
    public List<Cell> Cells => _cells;

    private List<Cell> _cells;

    private void Start()
    {
        _cells = GetAllCells();
    }

    public List<Cell> GetMyCells(ScriptableObject type) => _cells.Where(cell => cell.Type == type).ToList();
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
}
