using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemyLaser : MonoBehaviour
{
    public static CreateEnemyLaser CreateEnemyLaserInstance;

    [SerializeField] private GameObject _enemyLaserPrefab;

    private void Awake()
    {
        CreateEnemyLaserInstance = this;
    }

    public void CreateLaser()
    {
        Instantiate(_enemyLaserPrefab, gameObject.transform);
    }
}
