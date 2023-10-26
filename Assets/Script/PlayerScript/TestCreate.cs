using System.Collections.Generic;
using UnityEngine;

public class TestCreate : MonoBehaviour
{
    [SerializeField] private GameObject _prefabs;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Transform _saveSpaceship;
    public List<ShipScriptableObject> _shipScriptableObjects;
    [SerializeField] private PlayerController _playerController;
    private GameObject _newShip;
    public static int LaserIndex = 0;

    private void Awake()
    {
        _gameManager.LoadGameData();
    }
    void Start()
    {
        CreateSpaceship();
        _playerController = _newShip.GetComponent<PlayerController>();
    }

    private void CreateSpaceship()
    {
        foreach (var test in _shipScriptableObjects)
        {
            if (test.Index == _gameManager.PurchasingData.LastSelectedShip)
            {
                _newShip = Instantiate(_prefabs, _saveSpaceship);
                _newShip.transform.position = new Vector3(0f, -1.7f, 0f);

                SpriteRenderer newSprite = _newShip.GetComponent<SpriteRenderer>();

                newSprite.sprite = test.SpriteSpaceship;

                return;
            }
        }
    }

    public void CreateLaser()
    {
        foreach (var check in _shipScriptableObjects)
        {
            if (check.Index == _gameManager.PurchasingData.LastSelectedShip)
            {
                LaserIndex = check.LaserScriptableObjects.IndexLaser;
                GameObject newLaser = Instantiate(check.LaserScriptableObjects.PrefabLaser);

                newLaser.transform.position = _playerController.transform.position;
              
                return;
            }
        }
    }
}
