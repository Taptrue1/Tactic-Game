using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private UnitType _playerType;
    [SerializeField] private MoneyView _moneyView;

    private Money _money;
    private UnitData _playerData;
    private UnitData _aiData;
    private InformationMover _informationMover;
    private int _nextLevelIndex;

    private const int _defaultValue = 1;

    private void Start()
    {
        _informationMover = FindObjectOfType<InformationMover>();

        _playerData = new UnitData(_playerType, _defaultValue, _defaultValue, _defaultValue, _defaultValue);
        _aiData = new UnitData(null, 1, 1, 1, 1);

        _money = new Money();
        _moneyView = new MoneyView(_money);
    }

    public void StartLevel()
    {
        _informationMover.PlayerData = _playerData;
        _informationMover.AIData = _aiData;

        SceneManager.LoadScene(_nextLevelIndex);
    }
    public void UpgradeAttack()
    {
        _playerData.Attack.Upgrade(_money.Value);
    }
    public void UpgradeDefence()
    {
        _playerData.Defence.Upgrade(_money.Value);
    }
    public void UpgradeReproduction()
    {
        _playerData.Reproduction.Upgrade(_money.Value);
    }
    public void UpgradeSpeed()
    {
        _playerData.Speed.Upgrade(_money.Value);
    }
}