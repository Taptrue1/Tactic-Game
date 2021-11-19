using UnityEngine;

[CreateAssetMenu(menuName = "UnitType", order = 0)]
public class UnitType : ScriptableObject
{
    public Color Color => _unitColor;

    [Header("References")]
    [SerializeField] private Unit _unitPrefab;

    [Header("Parameters")]
    [SerializeField] Color _unitColor;

    public Unit GetUnit(Vector2 position, Transform parent)
    {
        var unit = Instantiate(_unitPrefab, position, Quaternion.identity, parent);
        unit.gameObject.GetComponent<SpriteRenderer>().color = _unitColor;
        return unit;
    }
}
