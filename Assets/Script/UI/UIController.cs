using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController UIControllerInstance;

    public Canvas Canvas { get; private set; }

    [Header("------ Game Objects ------")]
    [SerializeField] private GameObject _lossScreen;
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _buttonRestart;
    [SerializeField] private GameObject _settingVisible;
    [SerializeField] private GameObject _visidleSlidersController;

    [Header("------ Text Mesh Pro UGUI ------")]
    [SerializeField] private TextMeshProUGUI _amountKilledEnemyText;
    [SerializeField] private TextMeshProUGUI _taskTextGame;

    [Header("------ Settings ------")]
    private AudioController _audioPlayer;

    public Button _buttonFire;

    [HideInInspector] public int Amoutn;

    private void Awake()
    {
        Canvas = GetComponent<Canvas>();
        UIControllerInstance = this;
        Amoutn = 0;
    }

    private void Start()
    {
        _amountKilledEnemyText.text = СonstantsScript.KILLED_ENEMY_TEXT + Amoutn;

        StartCoroutine(TaskGameVisible());

        _taskTextGame.text = "Your task: Destroy " + СonstantsScript.TASK_AMOUNT_KILLED_ENEMY + " alien ships";

        _audioPlayer = AudioController.AudioControllerInstance;

        GlobalEventManager.OnEnemyKillled += EnemyKilled;

        GlobalEventManager.OnWin += WinScreen;

        GlobalEventManager.OnLoss += LossScreen;
    }

    private void OnDestroy()
    {
        GlobalEventManager.OnWin -= WinScreen;
        GlobalEventManager.OnLoss -= LossScreen;
        GlobalEventManager.OnEnemyKillled -= EnemyKilled;
    }

    private void WinScreen()
    {
        _audioPlayer.SoundWin();
        _winScreen.SetActive(true);
        _buttonRestart.SetActive(true);
        var player = FindObjectOfType<PlayerController>();
        player.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void LossScreen()
    {
        _audioPlayer.SoundLoss();
        _lossScreen.SetActive(true);
        _buttonRestart.SetActive(true);
    }

    private void EnemyKilled()
    {
        _amountKilledEnemyText.text = СonstantsScript.KILLED_ENEMY_TEXT + Amoutn;
    }

    public void SettingButton()
    {
        if (!_settingVisible.activeSelf)
            _settingVisible.SetActive(true);

        else if (_settingVisible.activeSelf)
            _settingVisible.SetActive(false);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(СonstantsScript.INDEX_SCENE_1);
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene(СonstantsScript.INDEX_SCENE_0);
    }
    public void MuteButton()
    {
        //_isPresedButtonMute = true;
        //if (!_mute)
        //{
        //    _mute = true;
        //    _backgroundSound.mute = true;
        //}
        //else if (_isPresedButtonMute)
        //{
        //    _backgroundSound.mute = false;
        //    _mute = false;
        //    _isPresedButtonMute = false;
        //}
        if (!_visidleSlidersController.activeSelf)
            _visidleSlidersController.SetActive(true);

        else if (_visidleSlidersController.activeSelf)
            _visidleSlidersController.SetActive(false);
    }


    private IEnumerator TaskGameVisible()
    {
        yield return new WaitForSeconds(3f);
        _taskTextGame.gameObject.SetActive(false);
    }
}
