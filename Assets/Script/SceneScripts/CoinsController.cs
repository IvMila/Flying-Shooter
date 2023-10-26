using TMPro;
using UnityEngine;

public class CoinsController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsText;
    [SerializeField] private GameManager _gameManager;

    private void Start()
    {
        _coinsText.text = СonstantsScript.COINS_TEXT + Coins;

        GlobalEventManager.OnEnemyKillled += AddCoins;
    }
    private void OnDestroy()
    {
        GlobalEventManager.OnEnemyKillled -= AddCoins;
    }
    public void AddCoins()
    {
        Coins += СonstantsScript.ADD_COINS;
        _coinsText.text = СonstantsScript.COINS_TEXT + Coins;
    }

    public void BuySpaceship(int coins)
    {
        Coins -= coins;
        _coinsText.text = СonstantsScript.COINS_TEXT + Coins;
    }

    public int Coins
    {
        get
        {
            return _gameManager.PurchasingData.Coins;
        }
        set
        {
            _gameManager.PurchasingData.Coins = value;
            _gameManager.SaveGameData();
        }
    }
}
