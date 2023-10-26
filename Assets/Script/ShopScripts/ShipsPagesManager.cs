using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShipsPagesManager : MonoBehaviour
{
    [SerializeField] private GameObject _pagesСildCreate;
    [SerializeField] private List<ShipScriptableObject> _shipScriptableObjects;
    [SerializeField] private List<GameObject> _childObjects = new List<GameObject>();

    private UIControllerScene_0 _uIControllerScene_0;

    private void Start()
    {
        _uIControllerScene_0 = UIControllerScene_0.Instance;
        CreatePage();
    }

    private void CreatePage()
    {
        for (int i = 0; _shipScriptableObjects.Count > i; i++)
        {
            GameObject newChild = Instantiate(_pagesСildCreate, transform);
            _childObjects.Add(newChild);

            Image imageComponent = newChild.GetComponent<Image>();

            LoadIcon(imageComponent, i);

            var indexButton = i;
            Button button = newChild.GetComponent<Button>();
            button.onClick.AddListener(() => LoadButtonIndex(indexButton));
        }
    }

    private void LoadIcon(Image icon, int index)
    {
        if (icon != null)
        {
            icon.sprite = _shipScriptableObjects[index].SpriteSpaceship;
        }
    }

    private void LoadButtonIndex(int index)
    {
        _uIControllerScene_0.ShipSelection(_shipScriptableObjects[index].Index);
    }
}
