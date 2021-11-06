using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Action<List<Cell>, Vector2> DrawLines;
    public Action<List<Cell>> ClearLines;

    private UnitData _data;
    private List<Cell> _choosedCells;
    private Cell _target;

    private void Awake()
    {
        _choosedCells = new List<Cell>();
        _target = null;
    }
    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var rayResult = Physics2D.Raycast(mousePosition, Vector2.zero).collider;

            if (_choosedCells.Count > 0) DrawLines.Invoke(_choosedCells, mousePosition);
            if (!rayResult) return;

            var isCell = rayResult.TryGetComponent(out Cell cell);
            if (!isCell) return;

            ChooseCell(cell);
            DrawLines.Invoke(_choosedCells, _target.transform.position);
        }
        else if(_choosedCells.Count > 0)
        {
            SendUnits();
            ClearLines.Invoke(_choosedCells);

            _choosedCells.Clear();
            _target = null;
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
            cell.SendUnits(_target.transform);
        }
    }
    private void ChooseCell(Cell cell)
    {
        var isMyCell = cell.Type == _data.Type;
        var containsCell = _choosedCells.Contains(cell);

        if (!containsCell && isMyCell)
            _choosedCells.Add(cell);

        _target = cell;
    }
}
