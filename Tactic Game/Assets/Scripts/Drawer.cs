using System.Collections.Generic;
using UnityEngine;

public class Drawer
{
    public void Init(Player player)
    {
        player.DrawLines = DrawLines;
        player.ClearLines = ClearLines;
    }
    private void DrawLines(List<Cell> choosedCells, Vector2 target)
    {
        foreach(Cell cell in choosedCells)
        {
            foreach(Transform child in cell.transform)
            {
                if(child.TryGetComponent(out LineRenderer lineRenderer))
                {
                    lineRenderer.SetPosition(0, cell.transform.position);
                    lineRenderer.SetPosition(1, target);
                }
            }
        }
    }
    private void ClearLines(List<Cell> choosedCells)
    {
        foreach (Cell cell in choosedCells)
        {
            foreach (Transform child in cell.transform)
            {
                if (child.TryGetComponent(out LineRenderer lineRenderer))
                {
                    lineRenderer.SetPosition(1, cell.transform.position);
                }
            }
        }
    }
}
