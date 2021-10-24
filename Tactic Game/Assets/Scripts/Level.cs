using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] CellsPool _cellPool;
    [SerializeField] Player _player;

    [Header("StartBases")]
    [SerializeField] Cell _playerCell;
    [SerializeField] Cell _aiCell;

    [Header("Types")]
    [SerializeField] UnitType _playerType;
    [SerializeField] UnitType _aiType;
    [SerializeField] UnitType _defaultType;

    private UnitData _playerData;
    private UnitData _aiData;
    private UnitData _defaultData;

    private void Start()
    {
        _playerData = new UnitData(_playerType, 1, 1, 1, 1);
        _aiData = new UnitData(_aiType, 1, 1, 1, 1);
        _defaultData = new UnitData(_defaultType, 0, 0, 0, 0);

        _cellPool.Init(_defaultData);
        _player.Init(_playerData);

        _playerCell.Init(_defaultData, _playerData);
    }
}
