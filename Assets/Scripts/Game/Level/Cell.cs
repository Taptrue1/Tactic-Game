using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Cell : MonoBehaviour
{
    public int Mass => _mass;
    public UnitType OwnerType => _ownerData.Type;

    [SerializeField] private float _unitSpawnOffset;
    [SerializeField] private int _mass;

    private UnitData _ownerData;
    private UnitData _defaultData;
    private SpriteRenderer _spriteRenderer;
    private GameObject _unitPool;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isUnit = collision.TryGetComponent(out Unit unit);

        if (!isUnit) return;
        if (unit.Target != gameObject.transform) return;

        Attack(unit);
    }

    public void Init(UnitData defaultData, GameObject unitPool)
    {
        _defaultData = defaultData;
        _ownerData = defaultData;
        _unitPool = unitPool;

        ChangeColor();
        StartCoroutine(StartReproduction());
    }
    public void SetOwner(UnitData owner)
    {
        _ownerData = owner;
        ChangeColor();
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
        var unit = _ownerData.Type.GetUnit(spawnPosition, _unitPool.transform);

        unit.Init(_ownerData);

        return unit;
    }
    private void Attack(Unit unit)
    {
        var isMyUnit = unit.Type == OwnerType;

        if (isMyUnit)
            _mass++;
        else
            _mass--; //ApplyDamage(unit.OwnerData.Attack)

        ChangeOwner(unit);
        ChangeColor();
    }
    private void ApplyDamage(int value)
    {
        var attack = Mathf.CeilToInt(value - _ownerData.Defence.Value);

        if (attack <= 0) return;

        _mass -= attack;
    }
    private void ChangeOwner(Unit unit)
    {
        var canChangeToDefault = _mass == 0;
        var canChangeToOther = _mass < 0;

        if (canChangeToDefault)
        {
            _ownerData = _defaultData;
            return;
        }
        if (canChangeToOther)
        {
            _ownerData = unit.OwnerData;
            _mass = 1;
        }
    }
    private void ChangeColor()
    {
        _spriteRenderer.color = _ownerData.Type.Color;
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