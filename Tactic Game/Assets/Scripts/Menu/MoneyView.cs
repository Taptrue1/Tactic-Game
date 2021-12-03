using UnityEngine;
using TMPro;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private string _textFormat = "${0}";

    public MoneyView(Money money)
    {
        money.MoneyChanged = OnMoneyChanged;
    }

    private void OnMoneyChanged(int money)
    {
        _moneyText.text = string.Format(_textFormat, money);
    }
}
