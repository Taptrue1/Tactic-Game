using System.Collections;
using UnityEngine;

public class Level : MonoBehaviour
{
    [Header("Pools")]
    [SerializeField] Transform _unitsPool;
    [SerializeField] CellsPool _cellsPool;

    [Header("Referee Options")]
    [SerializeField] private float _checkDelay;

    [Header("Player")]
    [SerializeField] Player _player;
    [SerializeField] Cell _playerCell;

    [Header("Artificial Inlelligence")]
    [SerializeField] AI _ai;
    [SerializeField] Cell _aiCell;

    [Header("Types")]
    [SerializeField] UnitType _playerType;
    [SerializeField] UnitType _aiType;
    [SerializeField] UnitType _defaultType;

    private UnitData _playerData;
    private UnitData _aiData;
    private UnitData _defaultData;

    private Drawer _drawer;
    private Referee _referee;

    private void Start()
    {
        InitDatas();
        _cellsPool.Init(_defaultData, _unitsPool);
        InitEntities();
        InitCells();

        _drawer = new Drawer();
        _drawer.Init(_player);

        InitReferee();
    }

    private void InitDatas()
    {
        _playerData = new UnitData(_playerType, 2, 2, 2, 2);
        _aiData = new UnitData(_aiType, 1, 1, 1, 1);
        _defaultData = new UnitData(_defaultType, 0, 0, 0, 0);
    }
    private void InitEntities()
    {
        _player.Init(_playerData);
        _ai.Init(_aiData, _cellsPool);
    }
    private void InitCells()
    {
        _playerCell.Init(_defaultData, _unitsPool, _playerData);
        _aiCell.Init(_defaultData, _unitsPool, _aiData);
    }
    private void InitReferee()
    {
        _referee = new Referee();
        _referee.Init(_cellsPool, _unitsPool.gameObject, _checkDelay);
        StartCoroutine(_referee.StartCheckLoop());
    }
}
