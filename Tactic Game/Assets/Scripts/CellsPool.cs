using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellsPool : MonoBehaviour
{
    private List<Cell> _cells;

    private void Start()
    {
        _cells = GetAllCells();
        Debug.Log(_cells.Count);
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
}
