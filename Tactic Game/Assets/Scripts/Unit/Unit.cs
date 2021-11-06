using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Unit : MonoBehaviour
{
    public UnitData OwnerData => _ownerData;
    public UnitType Type => _ownerData.Type;
    public Transform Target => _target;

    private UnitData _ownerData;
    private Transform _target;
    private Rigidbody2D _rigidbody;
    private Vector2 _movementDirection;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        _rigidbody.velocity = _movementDirection * _ownerData.Speed.Value;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isUnit = collision.gameObject.TryGetComponent(out Unit unit);
        bool isTarget = collision.gameObject.transform == _target;

        if (isTarget || isUnit && unit.Type != Type)
            Destroy(gameObject);
    }

    public void Init(UnitData ownerData)
    {
        _ownerData = ownerData;
    }
    public void SetTarget(Transform target)
    {
        _target = target;

        _movementDirection = target.position - transform.position;
        _movementDirection = _movementDirection.normalized;
    }
}