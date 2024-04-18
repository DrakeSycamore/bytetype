using System.Collections;
using TMPro;
using UnityEngine;

public class LosePanel : MonoBehaviour
{
    public CanvasGroup blackPanel;
    [SerializeField] private LoadSceneScreen load;
    [SerializeField] private GameObject loserObject;
    public float speed;
    private bool isLoad = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeAndChangeScene());
    }

    IEnumerator FadeAndChangeScene()
    {
        yield return FadeAnim();

        if (!isLoad)
        {
            yield return new WaitForSeconds(1);
            yield return ShowLoser();
            yield return new WaitForSeconds(3);
            yield return load.LoadSceneOperation("LevelSelection");
            isLoad = true;
        }
    }

    private IEnumerator FadeAnim()
    {
        while (blackPanel.alpha < 1)
        {
            blackPanel.alpha += Time.deltaTime * speed;
            yield return null;
        }
    }

    bool ShowLoser()
    {
        loserObject.SetActive(true);
        return true;
    }
}
