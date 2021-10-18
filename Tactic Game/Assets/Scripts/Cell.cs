using System.Collections;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public int Mass => _mass;
    public UnitType Type => _ownerData.Type;

    [SerializeField] private float _unitSpawnOffset;

    private int _mass;
    private UnitData _ownerData;
    private UnitData _defaultData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isUnit = collision.TryGetComponent(out Unit unit);

        if (!isUnit) return;
        if (unit.Target != gameObject) return;


        if (unit.Type == Type)
            _mass++;
        else
            _mass--; //Attack(unit.OwnerData.Attack);

        CheckMass(unit);
    }

    public void Init(UnitData defaultData)
    {
        _ownerData = defaultData;
        StartCoroutine(StartReproduction());
    }
    public void SendUnits(GameObject target)
    {
        for(int i = 0; i < _mass; i++)
        {
            SendUnit(target);
        }

        _mass = 0;
    }

    private void SendUnit(GameObject target)
    {
        var x = transform.position.x + Random.Range(-_unitSpawnOffset, _unitSpawnOffset);
        var y = transform.position.y + Random.Range(-_unitSpawnOffset, _unitSpawnOffset);
        var spawnPosition = new Vector2(x, y);

        var unit = _ownerData.Type.GetUnit(spawnPosition);
        unit.Init(target, _ownerData);
    }
    private void Attack(int value)
    {
        var attack = value - _ownerData.Defence;

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
    }
    private IEnumerator StartReproduction()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            _mass += _ownerData.Reproduction;
        }
    }
}