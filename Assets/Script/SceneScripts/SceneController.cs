using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [Header("------ Background ------")]
    [SerializeField] private GameObject _prefabBackgroundSprite;
    [SerializeField] private Transform _saveSprite;
    private const int _posY = 20;
    private Vector3 _startPos;
  
    void Start() 
    {
        _startPos = new Vector3(0, 0, 0);
        CreateBackground();
    }

    private void CreateBackground()
    {
        for (int i = 0; i < 7; i++)
        {
            GameObject newSprite = Instantiate(_prefabBackgroundSprite, _saveSprite);

            float posY = (_posY * i) + _startPos.y;

            newSprite.transform.position = new Vector3(_startPos.x, posY, _startPos.z);
        }
    }
}
