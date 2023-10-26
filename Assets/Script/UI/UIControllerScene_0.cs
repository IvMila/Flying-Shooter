using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIControllerScene_0 : MonoBehaviour
{
    public static UIControllerScene_0 Instance;
    [Header("------ Text Mesh Pro UGUI ------")]
    [SerializeField] private TextMeshProUGUI _infoSpaceshipText;
    [SerializeField] private TextMeshProUGUI _warningText;
    [SerializeField] private TextMeshProUGUI _textCostSpaceship;
    [Header("------ Game Objects ------")]
    [SerializeField] private GameObject _settingsButton;
    [SerializeField] private GameObject _shopPanel;

    [Header("------ Button ------")]

    [SerializeField] private Button _buttonBuySpaceship;

    [Header("------ Image ------")]
    [SerializeField] private Image _mySpaceshipImage;

    [Header("------ Settings ------")]
    [SerializeField] private List<ShipScriptableObject> _shipScriptableObjects;

    private CoinsController _coinsController;

    [SerializeField] private GameManager _gameManager;

    [Header("------ Animators ------")]
    [SerializeField] private Animator _noEnoughtCoinsAnimator;

    private int _selectedShipIndex = -1;

    [Header("------ DATA ------")]
    [SerializeField] private List<PurchasedObject> _purchasedObjects;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        _gameManager.LoadGameData();
        LoadMyDefaultSpaceship();
        _coinsController = GetComponent<CoinsController>();

        _buttonBuySpaceship.onClick.AddListener(BuySpaceship);
    }

    private void BuySpaceship()
    {
        if (_selectedShipIndex < 0)
            return;

        foreach (var check in _shipScriptableObjects)
        {
            if (check.Index == _selectedShipIndex)
            {
                if (!_gameManager.PurchasingData.PurchasedObjects.Contains(check.NameShip)
                    && _coinsController.Coins >= check.Cost)
                {
                    _gameManager.PurchasingData.LastSelectedShip = check.Index;
                    _gameManager.PurchasingData.PurchasedObjects.Add(check.NameShip);

                    _gameManager.SaveGameData();

                    CheckBougthShip(check.NameShip);

                    ShowPurchasedItemInfo(check);

                    _coinsController.BuySpaceship(check.Cost);

                    _selectedShipIndex = -1;
                }
                else if (_gameManager.PurchasingData.PurchasedObjects.Contains(check.NameShip))
                {
                    _warningText.text = СonstantsScript.WARNING_TEXT;
                    _noEnoughtCoinsAnimator.SetTrigger("WarningText");
                }
                else
                {
                    _warningText.text = СonstantsScript.NO_ENOUGHT_COINS_TEXT;
                    _noEnoughtCoinsAnimator.SetTrigger("WarningText");
                }
            }
        }
    }

    private void CheckBougthShip(string nameShip)
    {
        foreach (var check in _purchasedObjects)
        {
            if (check.ObjectName == nameShip)
            {
                if (!check.Bougth) //!check.Selected)
                {
                    check.Bougth = true;
                    //check.Selected = true;

                    _textCostSpaceship.text = СonstantsScript.SELECTED_SPACESHIP;
                }
            }
        }
    }

    private void LoadMyDefaultSpaceship()
    {
        foreach (var ship in _shipScriptableObjects)
        {
            if (ship.Index == _gameManager.PurchasingData.LastSelectedShip)
            {
                if (!_gameManager.PurchasingData.PurchasedObjects.Contains(ship.NameShip))
                {
                    _gameManager.PurchasingData.PurchasedObjects.Add(ship.NameShip);

                    _gameManager.SaveGameData();
                }

                _textCostSpaceship.text = СonstantsScript.SELECTED_SPACESHIP;

                ShowPurchasedItemInfo(ship);

            }
        }
    }

    public void ShipSelection(int index)
    {
        foreach (var check in _shipScriptableObjects)
        {
            if (check.Index == index)
            {
                if (_gameManager.PurchasingData.PurchasedObjects.Contains(check.NameShip))
                {
                    _gameManager.PurchasingData.LastSelectedShip = check.Index;
                    _gameManager.SaveGameData();
                    _textCostSpaceship.text = СonstantsScript.SELECTED_SPACESHIP;
                }
                else
                {
                    _textCostSpaceship.text = СonstantsScript.BUY_FOR_TEXT + check.Cost;
                }

                ShowPurchasedItemInfo(check);

                _selectedShipIndex = index;

                return;
            }
        }
        _selectedShipIndex = -1;
    }

    private void ShowPurchasedItemInfo(ShipScriptableObject shipScriptableObject)
    {
        _mySpaceshipImage.sprite = shipScriptableObject.SpriteSpaceship;
        _infoSpaceshipText.text = shipScriptableObject.Info;
        _mySpaceshipImage.preserveAspect = true;
    }

    public void ShopButton()
    {
        _shopPanel.SetActive(true);
        _settingsButton.SetActive(false);
    }

    public void ReturnButton()
    {
        _shopPanel.SetActive(false);
        _settingsButton.SetActive(true);

        _selectedShipIndex = -1;
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }
}

