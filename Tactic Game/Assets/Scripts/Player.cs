using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private UnitData _data;
    private Cell _target;
    private List<Cell> _choosedCells;

    private void Start()
    {
        _choosedCells = new List<Cell>();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var ray = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (!ray) return;

            var isCell = ray.collider.TryGetComponent(out Cell cell);

            if (!isCell) return;
            
            ChooseCell(cell);
        }
        else if(_choosedCells.Count > 0)
        {
            SendUnits();
        }
    }

    public void Init(UnitData playerData)
    {
        _data = playerData;
    }

    private void SendUnits()
    {
        foreach(Cell cell in _choosedCells)
        {
            if (cell.Type == _data.Type)
                cell.SendUnits(_target.gameObject);
        }

        _choosedCells.Clear();
        _target = null;
    }
    private void ChooseCell(Cell cell)
    {
        var containsCell = _choosedCells.Contains(cell);

        if (!containsCell)
            _choosedCells.Add(cell);

        _target = cell;
    }
}
