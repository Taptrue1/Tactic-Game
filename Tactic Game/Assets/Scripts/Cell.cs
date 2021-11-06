using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Cell : MonoBehaviour
{
    public int Mass => _mass;
    public UnitType Type => _ownerData.Type;

    [SerializeField] private float _unitSpawnOffset;
    [SerializeField] private int _mass;

    private UnitData _ownerData;
    private UnitData _defaultData;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isUnit = collision.TryGetComponent(out Unit unit);

        if (!isUnit) return;
        if (unit.Target != gameObject.transform) return;


        if (unit.Type == Type)
            _mass++;
        else
            _mass--; //Attack(unit.OwnerData.Attack);

        CheckMass(unit);
    }

    public void Init(UnitData defaultData, UnitData ownerData = null)
    {
        _defaultData = defaultData;

        if (ownerData == null)
            _ownerData = defaultData;
        else
            _ownerData = ownerData;

        ChangeColor(_ownerData.Type.Color);
        StartCoroutine(StartReproduction());
    }
    public void SendUnits(Transform target)
    {
        if (target == gameObject) return;

        for(int i = 0; i < _mass; i++)
        {
            SendUnit(target);
        }

        _mass = 0;
    }

    private void SendUnit(Transform target)
    {
        var unit = SpawnUnit();
        unit.SetTarget(target);
    }
    private Unit SpawnUnit()
    {
        var x = transform.position.x + Random.Range(-_unitSpawnOffset, _unitSpawnOffset);
        var y = transform.position.y + Random.Range(-_unitSpawnOffset, _unitSpawnOffset);
        var spawnPosition = new Vector2(x, y);

        var unit = _ownerData.Type.GetUnit(spawnPosition);

        unit.Init(_ownerData);

        return unit;
    }
    private void ApplyDamage(int value)
    {
        var attack = Mathf.CeilToInt(value - _ownerData.Defence.Value);

        if (attack <= 0) return;

        _mass -= attack;
    }
    private void CheckMass(Unit unit)
    {
        if (_mass == 0)
        {
            _ownerData = _defaultData;
        }
        else if (_mass < 0)
        {
            _ownerData = unit.OwnerData;
            _mass = 1;
        }

       ChangeColor(_ownerData.Type.Color);
    }
    private void ChangeColor(Color color)
    {
        _spriteRenderer.color = color;
    }
    private IEnumerator StartReproduction()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            _mass += Mathf.CeilToInt(_ownerData.Reproduction.Value);
        }
    }
}