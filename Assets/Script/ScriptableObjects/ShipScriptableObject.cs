using UnityEngine;

[CreateAssetMenu(fileName = "Spaceship_", menuName = "Create/New Spaceship")]
public class ShipScriptableObject : ScriptableObject
{
    [SerializeField] private Sprite _spriteSpaceship;
    public Sprite SpriteSpaceship => _spriteSpaceship;

    [SerializeField] private int _cost;
    public int Cost => _cost;

    [SerializeField] private string _info;
    public string Info => _info;

    [SerializeField] private string _nameShip;
    public string NameShip => _nameShip;

    [SerializeField] private int _index;
    public int Index => _index;

    public LaserScriptableObject LaserScriptableObjects;
}