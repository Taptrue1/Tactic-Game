using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [Header("Characteristics")]
    [SerializeField] private Characteristic _attack;
    [SerializeField] private Characteristic _defence;
    [SerializeField] private Characteristic _reproduction;
    [SerializeField] private Characteristic _speed;

    [Header("Other Options")]
    [SerializeField] private UnitType _playerType;
    [SerializeField] private MoneyView _moneyView;

    private Money _money;
    private UnitData _playerData;
    private UnitData _aiData;
    private InformationMover _informationMover;
    private int _levelIndex = 2;

    private const int _menuIndex = 1;

    private void Start()
    {
        _informationMover = FindObjectOfType<InformationMover>();
        _informationMover.GameOver = OnGameOver;

        _playerData = new UnitData(_playerType, _attack, _defence, _reproduction, _speed);
        _aiData = new UnitData(null, 1, 1, 1, 1);

        _money = new Money();
        _moneyView.Init(_money);
        _money.Add(10000);
    }

    public void ExitMenu()
    {
        Application.Quit();
    }
    public void LoadLevel()
    {
        _informationMover.PlayerData = _playerData;
        _informationMover.AIData = _aiData;

        SceneManager.LoadScene(_levelIndex);
    }
    public void UpgradeAttack()
    {
        _money.Subtract(_playerData.Attack.Upgrade(_money.Value));
    }
    public void UpgradeDefence()
    {
        _money.Subtract(_playerData.Defence.Upgrade(_money.Value));
    }
    public void UpgradeReproduction()
    {
        _money.Subtract(_playerData.Reproduction.Upgrade(_money.Value));
    }
    public void UpgradeSpeed()
    {
        _money.Subtract(_playerData.Speed.Upgrade(_money.Value));
    }

    private void OnGameOver(bool isWin)
    {
        SceneManager.LoadScene(_menuIndex);
        if (isWin)
            _levelIndex++;
    }
}