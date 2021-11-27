using System.Collections;
using UnityEngine;

public class Level : MonoBehaviour
{
    [Header("Pools")]
    [SerializeField] private Transform _unitsPool;
    [SerializeField] private CellsPool _cellsPool;

    [Header("Player")]
    [SerializeField] private Player _player;
    [SerializeField] private Cell _playerStartCell;

    [Header("Artificial Inlelligence")]
    [SerializeField] private int _analizeDelay = 2;
    [SerializeField] private AiSetting[] _ai;

    [Header("Referee Options")]
    [SerializeField] private float _checkDelay;

    [Header("Types")]
    [SerializeField] private UnitType _playerType;
    [SerializeField] private UnitType _defaultType;

    private UnitData _playerData;
    private UnitData _aiData;
    private UnitData _defaultData;

    private Referee _referee;
    private Drawer _drawer;

    private void Start()
    {
        InitDatas();
        _cellsPool.Init(_defaultData, _unitsPool);
        InitPlayer();
        InitAi();

        InitReferee();
        InitDrawer();
    }

    private void InitDatas()
    {
        _playerData = new UnitData(_playerType, 2, 2, 2, 2);
        _aiData = new UnitData(null, 1, 1, 1, 1);
        _defaultData = new UnitData(_defaultType, 0, 0, 0, 0);
    }
    private void InitPlayer()
    {
        _player.Init(_playerData);
        _playerStartCell.SetOwner(_playerData);
    }
    private void InitAi()
    {
        foreach(AiSetting setting in _ai)
        {
            setting.Init(_aiData, _cellsPool);
        }
    }
    private void InitReferee()
    {
        _referee = new Referee();
        _referee.Init(_cellsPool, _unitsPool.gameObject, _checkDelay);
        StartCoroutine(_referee.StartCheckLoop());
    }
    private void InitDrawer()
    {
        _drawer = new Drawer();
        _drawer.Init(_player);
    }
}
