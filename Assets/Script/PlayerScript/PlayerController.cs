using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool IsAlive => _playerHP > 0;
    public int PlayerHPMax = 100;
    private int _playerHP;
    public SliderPlayerHP _sliderPlayerHP;
    private Animator _animationDeath;
    private AudioController _audioPlayer;
    private UIController _uIController;
    [SerializeField] private TestCreate _testCreate;
    [Header("------ Shoot ------")]
    private float _timeOut = 0.2f;
    private float _currentTime;

    private void Start()
    {
        _testCreate = FindObjectOfType<TestCreate>();

        _playerHP = PlayerHPMax;

        _animationDeath = GetComponent<Animator>();

        _sliderPlayerHP = SliderPlayerHP.Instance;

        _audioPlayer = AudioController.AudioControllerInstance;

        _uIController = UIController.UIControllerInstance;

        _uIController._buttonFire.onClick.AddListener(Shoot);
    }
    
    private void Update()
    {
        _sliderPlayerHP.SetColor(PlayerHP);

        _currentTime += Time.deltaTime;
    }
    private void Shoot()
    {

        if (_currentTime > _timeOut)
        {
            _currentTime = 0;

            _testCreate.CreateLaser();

            _audioPlayer.PlayerShoot();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(СonstantsScript.LASER_ENEMY))
        {
            PlayerHP -= 5;
            _sliderPlayerHP.SetHP(PlayerHP);
        }
    }

    private void Death()
    {
        _audioPlayer.Explosion();

        //_uIController._backgroundSound.volume = 0.2f;
        _animationDeath.enabled = true;
        _animationDeath.SetTrigger(СonstantsScript.EXPLOSION);

        GlobalEventManager.SendLoss();
    }

    public int PlayerHP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            if (_playerHP <= 0)
            {
                Death();
            }
        }
    }
}
