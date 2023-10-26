using UnityEngine;

[CreateAssetMenu(fileName = "Laser_", menuName = "Create/New Laser")]
public class LaserScriptableObject : ScriptableObject
{
    [SerializeField] private int _indexLaser;
    public int IndexLaser => _indexLaser;

    [SerializeField] private int _damageLaser;
    public int DamageLaser => _damageLaser;

    [SerializeField] private GameObject _prefabLaser;
    public GameObject PrefabLaser => _prefabLaser;
}
