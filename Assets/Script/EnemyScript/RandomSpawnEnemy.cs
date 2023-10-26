using System.Collections;
using UnityEngine;
public class RandomSpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [HideInInspector] public int AmountEnemySpawn = 10;
    private float _randomX;
    private Vector3 _startPosition;
    [HideInInspector] public Vector3 _spawnPos;
    [SerializeField] private Transform _saveObject;
    void Start()
    {
        StartCoroutine(SpanwSpaceshipEnemy());
    }

    private IEnumerator SpanwSpaceshipEnemy()
    {
        for (int i = 0; i < AmountEnemySpawn; i++)
        {
            _randomX = Random.Range(-6, 6);

            _startPosition = new Vector3(_randomX, 7, 0);

            _spawnPos = new Vector3(_startPosition.x, _startPosition.y, _startPosition.z);
            Instantiate(_enemyPrefab, _spawnPos, Quaternion.identity, _saveObject);

            yield return new WaitForSeconds(4f);
        }
    }
}
