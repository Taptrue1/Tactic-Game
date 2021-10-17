﻿using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class Unit : MonoBehaviour
{
    public UnitType Type => _ownerData.Type;
    public UnitData OwnerData => _ownerData;
    public GameObject Target => _target;

    private UnitData _ownerData;
    private GameObject _target;
    private Rigidbody2D _rigidbody;
    private Vector2 _movementDirection;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        _rigidbody.velocity = _movementDirection * _ownerData.Speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isUnit = collision.gameObject.TryGetComponent(out Unit unit);
        bool isTarget = collision.gameObject == _target;

        if (isTarget || isUnit && unit.Type != Type)
            Destroy(gameObject);
    }

    public void Init(GameObject target, UnitData ownerData)
    {
        _ownerData = ownerData;
        _target = target;
        _movementDirection = target.transform.position - transform.position;
    }
}