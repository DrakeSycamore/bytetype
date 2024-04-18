using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditRoll : MonoBehaviour
{
    public BGMPlayer bgmPlay;
    public GameObject panel, endLogo;
    public CanvasGroup wholeScene;
    public float verticalScrollSpeed;
    public float startDelay, endDelay;
    RectTransform creditTransform, logoPos;
    CanvasGroup panelCanvas;
    bool waitEnd = false;

    void Start()
    {   
        bgmPlay = FindObjectOfType<BGMPlayer>();
        creditTransform = panel.GetComponent<RectTransform>();
        logoPos = endLogo.GetComponent<RectTransform>();
        panelCanvas = panel.GetComponent<CanvasGroup>();

        bgmPlay.LoadAndPlayBGM(1);
        StartCoroutine(CreditAnim());
    }

    IEnumerator FadeIn(CanvasGroup canvasGroup)
    {
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime * 4;
            yield return null;
        }
    }

    IEnumerator FadeOut(CanvasGroup canvasGroup)
    {
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime * 4;
            yield return null;
        }
    }

    IEnumerator FadeAllOut()
    {
        while (wholeScene.alpha < 1)
        {
            wholeScene.alpha += Time.deltaTime * 4;
            yield return null;
        }
    }

    IEnumerator CreditAnim()
    {
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(FadeIn(panelCanvas));
        yield return new WaitForSeconds(startDelay);
        waitEnd = true;

        while (waitEnd && creditTransform.anchoredPosition.y < (logoPos.anchoredPosition.y * -1) + 100)
        {
            creditTransform.anchoredPosition = new Vector2(creditTransform.anchoredPosition.x, creditTransform.anchoredPosition.y + (Time.deltaTime * verticalScrollSpeed));
            yield return null;
        }

        yield return new WaitForSeconds(endDelay);
        yield return StartCoroutine(FadeOut(panelCanvas));
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(FadeAllOut());

        yield return new WaitForSeconds(1); // Optional delay before loading the next scene

        // Load the title scene asynchronously
        yield return SceneManager.LoadSceneAsync("TitleScreen");

        // Note: The next line will not be reached because the scene is being unloaded
        // and the script will be destroyed. It's included for completeness.
        yield return null;
    }
}
