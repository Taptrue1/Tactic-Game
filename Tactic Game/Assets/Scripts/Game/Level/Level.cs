using UnityEngine;

public class Level : MonoBehaviour
{
    [Header("Pools")]
    [SerializeField] private CellsPool _cellsPool;
    [SerializeField] private GameObject _unitsPool;

    [Header("Types")]
    [SerializeField] private UnitType _defaultType;
    [SerializeField] private UnitType[] _aiTypes;

    [Header("Player")]
    [SerializeField] private Player _player;
    [SerializeField] private Cell _startPlayerCell;

    [Header("AI")]
    [SerializeField] private float _analyzeDelay;
    [SerializeField] private AiConfig[] _ais;

    [Header("Referee Options")]
    [SerializeField] private float _checkDelay;

    private UnitData _playerData;
    private UnitData _defaultAIData;
    private UnitData _defaultCellData;

    private Referee _referee;
    private Drawer _drawer;
    private InformationMover _informationMover;

    private const float _randomOffset = 1;

    private void Start()
    {
        _informationMover = FindObjectOfType<InformationMover>();
        _analyzeDelay = _informationMover.AIAnalizeDelay;

        InitData();
        _cellsPool.Init(_defaultCellData, _unitsPool);
        InitPlayer();
        InitAI();
        InitReferee();
        InitDrawer();
    }

    private void InitData()
    {
        _playerData = _informationMover.PlayerData;
        _defaultAIData = _informationMover.AIData;
        _defaultCellData = new UnitData(_defaultType, 0, 0, 0, 0);
    }
    private void InitPlayer()
    {
        _player.Init(_playerData);
        _startPlayerCell.SetOwner(_playerData);
    }
    private void InitAI()
    {
        foreach(AiConfig aiConfig in _ais)
        {
            var ai = aiConfig.Init(_cellsPool, _defaultAIData, RandomizeAIType(), _randomOffset);
            StartCoroutine(ai.StartAnalize(_analyzeDelay));
        }
    }
    private void InitReferee()
    {
        _referee = new Referee();
        _referee.Init(_cellsPool, _unitsPool, _playerData.Type, _checkDelay, _informationMover);
        StartCoroutine(_referee.StartCheckLoop());
    }
    private void InitDrawer()
    {
        _drawer = new Drawer();
        _drawer.Init(_player);
    }

    private UnitType RandomizeAIType()
    {
        var typeIndex = Random.Range(0, _aiTypes.Length);

        return _aiTypes[typeIndex];
    }
}