using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SliderPlayerHP : MonoBehaviour
{
    public static SliderPlayerHP Instance;
    [SerializeField] private Slider _sliderPlayerHP;
    [SerializeField] private Image _fillArea;
    private int _targetHP;
    private float _timeScale = 0f;
    private Color _maxHP = Color.green;
    private Color _minHP = Color.red;

    private void Awake()
    {
        Instance = this;
    }
    
    public void SetHP(int hp)
    {
        _targetHP = hp;
        _timeScale = 0;
        StartCoroutine(LerpHP());
    }

    public void SetColor(int hp)
    {
        var player = FindObjectOfType<PlayerController>();
        _sliderPlayerHP.value = hp;

        _fillArea.color = Color.Lerp(_minHP, _maxHP, (float)hp / player.PlayerHPMax);
    }

    private IEnumerator LerpHP()
    {
        float speedLerp = 5f;
        float startHP = _sliderPlayerHP.value;

        while (_timeScale < 1)
        {
            _timeScale += Time.deltaTime * speedLerp;
            _sliderPlayerHP.value = Mathf.Lerp(startHP, _targetHP, _timeScale);
            yield return null;
        }
    }
}
