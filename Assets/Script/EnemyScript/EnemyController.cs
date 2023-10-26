using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private CoinsController _coinsController;

    //[SerializeField] private List<LaserScriptableObject> _laserList;
    [SerializeField] private List<ShipScriptableObject> _shipScriptableObject;

    private int _maxHpEnemy = 100;
    private int _enemyHP;

    private Animator _explosionAnimator;

    private EnemySound _enemySound;

    private float _timeOut = 1f;
    private float _currentTime;

    private CreateEnemyLaser _createEnemyLaser;
    private UIController _uIController;

    private void Start()
    {
        _uIController = UIController.UIControllerInstance;

        _enemyHP = _maxHpEnemy;

        _explosionAnimator = GetComponent<Animator>();

        _enemySound = EnemySound.EnemySoundInstance;

        _createEnemyLaser = CreateEnemyLaser.CreateEnemyLaserInstance;
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, -Vector2.up * 5f, Color.red);

        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, -Vector2.up, 5, LayerMask.GetMask(СonstantsScript.PLAYER));

        if (raycastHit2D)
        {
            var player = raycastHit2D.collider.GetComponent<PlayerController>();

            if (player && player.IsAlive)
            {
                Shoot();
            }
        }
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;
        ChangePosition();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(СonstantsScript.LASER))
        {
            DamageLaser();
        }
    }

    private void DamageLaser()
    {
        foreach (var check in _shipScriptableObject)
        {
            if (TestCreate.LaserIndex == check.LaserScriptableObjects.IndexLaser)
            {
                EnemyHP -= check.LaserScriptableObjects.DamageLaser;
            }
        }
    }

    private void ChangePosition()
    {
        float pos = -7f;

        if (gameObject.transform.position.y < pos)
        {
            gameObject.transform.position = new Vector2(transform.position.x, 8f);
        }
    }

    private IEnumerator DestroyEnemySpaceship()
    {
        yield return new WaitForSeconds(3.5f);
        Destroy(gameObject);
    }

    private void ComponentsEnemyFalse()
    {
        gameObject.GetComponent<EnemyController>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void Shoot()
    {
        if (_currentTime > _timeOut)
        {
            _currentTime = 0;
            _createEnemyLaser.CreateLaser();
            _enemySound.ShootSound();
        }
    }

    public int EnemyHP
    {
        get { return _enemyHP; }
        set
        {
            _enemyHP = value;
            if (_enemyHP <= 0)
            {
                _uIController.Amoutn += СonstantsScript.ADD_KILLED_AMOUNT;
                _coinsController.AddCoins();

                GlobalEventManager.SendEnemyKilled();

                ComponentsEnemyFalse();

                _enemySound.ExplosionSound();
                _explosionAnimator.SetTrigger(СonstantsScript.EXPLOSION);

                StartCoroutine(DestroyEnemySpaceship());
            }
        }
    }
}
