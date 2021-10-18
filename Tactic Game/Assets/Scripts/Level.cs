using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] CellsPool _cellPool;
    [SerializeField] Player _player;
    [SerializeField] UnitType _playerType;
    [SerializeField] UnitType _aiType;

    private UnitData _playerData;
    private UnitData _aiData;

    private void Start()
    {
        _playerData = new UnitData(_playerType, 1, 1, 1, 1);
        _aiData = new UnitData(_aiType, 1, 1, 1, 1);

        _player.Init(_playerData);
    }
}
