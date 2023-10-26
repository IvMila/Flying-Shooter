using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour
{
    [Header("------ Text Mesh Pro UGUI ------")]
    [SerializeField] private TextMeshProUGUI _acquaintanceText;
    [Header("------ Animator ------")]
    [SerializeField] private Animator _textPopupAnimator;

    private void Start()
    {
        StartCoroutine(Acquaintance());
    }

    private IEnumerator Acquaintance()
    {
        _acquaintanceText.text = СonstantsScript.ACQUAINTANCE_TEXT_1;

        _acquaintanceText.gameObject.SetActive(true);

        _textPopupAnimator.Play("TMP_Popup");
        yield return new WaitForSeconds(5f);

        _textPopupAnimator.SetTrigger("TransitionDisappearance");

        yield return new WaitForSeconds(2f);

        _acquaintanceText.text = СonstantsScript.ACQUAINTANCE_TEXT_2;

        _textPopupAnimator.SetTrigger("TransitionAppearance");

        yield return new WaitForSeconds(5f);

        _textPopupAnimator.SetTrigger("TransitionDisappearance");

        yield return new WaitForSeconds(1.4f);

        Destroy(_acquaintanceText.gameObject);

        SceneManager.LoadScene(0);
    }
}
