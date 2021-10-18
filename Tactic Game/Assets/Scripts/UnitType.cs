using UnityEngine;

[CreateAssetMenu(menuName = "UnitType", order = 0)]
public class UnitType : ScriptableObject
{
    [Header("References")]
    [SerializeField] private Unit _unitPrefab;

    [Header("Parameters")]
    [SerializeField] Color _unitColor;

    public Unit GetUnit(Vector2 position)
    {
        var unit = Instantiate(_unitPrefab, position, Quaternion.identity);
        unit.gameObject.GetComponent<SpriteRenderer>().color = _unitColor;
        return unit;
    }
}
