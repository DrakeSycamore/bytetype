using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using UnityEngine.Windows;
using Unity.VisualScripting;

public class LoadSceneScreen : MonoBehaviour
{
    public PlayerInfo PlayerInfo;
    public GameObject loadingScreen;
    public TMP_Text tips;
    public AreaDetails areaDetails;

    public void LoadSceneWithLoading(string loadScene)
    {
        StartCoroutine(LoadSceneOperation(loadScene));
    }

    public void LoadSceneSpecial()
    {
        
        StartCoroutine(SpecialLoadSceneA("AreaSelection", "LevelSelection", "CreditsScene"));
    }

    public IEnumerator LoadSceneOperation(string loadScene)
    {
        
        loadingScreen.SetActive(true);
        string path = Application.streamingAssetsPath +"/Utilities/Tips.txt";
        AsyncOperation operation = SceneManager.LoadSceneAsync(loadScene);

        StreamReader read = new StreamReader(path);
        string allLine = read.ReadToEnd();
        string[] lines = allLine.Split("\n");
        Debug.Log(allLine);
        Debug.Log(lines.Length);

        Random.seed = System.DateTime.Now.Millisecond;
        while (!operation.isDone)
        {

            Debug.LogWarning("Loading Screen");
            tips.text = "TIP: " + lines[Random.Range(0, lines.Length)];
            yield return new WaitForSeconds(2);

        }
        read.Close();

        yield return new WaitForSeconds(200000);
    }

    public IEnumerator SpecialLoadSceneA(string loadSceneA, string loadSceneB, string loadSceneC)
    {
        string loadScene;
        bool allLevelsFinished = true;
        bool overallLevelFinished = false;
        for (int i = 0; i < areaDetails.areas[PlayerInfo.playerInfo.Area].levelLists.Count; i++)
        {
            if (!areaDetails.areas[PlayerInfo.playerInfo.Area].levelLists[i].isFinished)
            {
                allLevelsFinished = false;
               


                break;
            }
        }

        if ((areaDetails.areas.Count == PlayerInfo.playerInfo.Area) && (areaDetails.areas[areaDetails.areas.Count].levelLists.Count == PlayerInfo.playerInfo.Level))
        {
            overallLevelFinished = true;
            for (int i = 0; i < areaDetails.areas.Count; i++)
            {
                for (int j = 0; j < areaDetails.areas[i].levelLists.Count; j++)
                {
                    if (!areaDetails.areas[i].levelLists[j].isFinished)
                    {
                        overallLevelFinished = false;
                    }

                }
            }
        }
        
        if (overallLevelFinished)
        {
            loadScene = loadSceneC;
            PlayerInfo.playerInfo.Area = -1;
            PlayerInfo.playerInfo.Level = -1;

            SceneManager.LoadSceneAsync(loadScene);
        }

        else if (allLevelsFinished && !overallLevelFinished)
        {   
            loadScene = loadSceneA;
            PlayerInfo.playerInfo.Area = -1;
        }
        else
        {  
            loadScene = loadSceneB;
            PlayerInfo.playerInfo.Level = -1;
        }

        loadingScreen.SetActive(true);
        string path = Application.streamingAssetsPath + "/Utilities/Tips.txt";
        AsyncOperation operation = SceneManager.LoadSceneAsync(loadScene);

        StreamReader read = new StreamReader(path);
        string allLine = read.ReadToEnd();
        string[] lines = allLine.Split("\n");
        Debug.Log(allLine);
        Debug.Log(lines.Length);

        Random.seed = System.DateTime.Now.Millisecond;
        while (!operation.isDone)
        {

            Debug.LogWarning("Loading Screen");
            tips.text = "TIP: " + lines[Random.Range(0, lines.Length)];
            yield return new WaitForSeconds(2);

        }
        read.Close();
        
        yield return new WaitForSeconds(200000);
    }

}
