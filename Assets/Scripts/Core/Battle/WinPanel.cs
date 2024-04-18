using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;
using static Characters;

public class WinPanel : MonoBehaviour
{
    public AreaDetails areaDetails;
    public PlayerInfo PlayerInfo;
    PlayerProgress playProgress;
    InputDetector inputDetector;
    WordDropper wordDropper;
    PlayerSkills skills;
    public PlayerInfo playInfo;
    public Characters chara;
    public TMP_Text showScore, elapsedTime, showWPM, showMistakes, showAccuracy, showName;
    private float i = 0;
    public float countDuration;
    private float timer = 0;
    private float timeElapsed;
    private bool isDone = false;
    public GameObject continueButton;




    public string characterName;
    public Image characterDisplay;
    public Image characterSihlouette;




    void Start()
    {
        playProgress = FindObjectOfType<PlayerProgress>();
        inputDetector = FindObjectOfType<InputDetector>();
        wordDropper = FindObjectOfType<WordDropper>();
        skills = FindObjectOfType<PlayerSkills>();

        Image characterDisplay = GetComponent<Image>();
        Image characterSihlouette = GetComponent<Image>();
        
        

    }


    void Update()
    {
        LoadSprite();
        if (wordDropper.WinPanel.activeSelf && !isDone)
        {
            
            StartCoroutine(WinSequence());
        }
        if (isDone)
        {
            
            continueButton.SetActive(true);
        }
       
    }

    IEnumerator WinSequence()
    {

        
        continueButton.SetActive(false);
        yield return GetNameAndIsFinished();
        yield return new WaitForSeconds(1);
        yield return ScoreCount();
        yield return new WaitForSeconds(1);
        yield return TimeCount();
        yield return new WaitForSeconds(1);
        yield return WPM();
        yield return new WaitForSeconds(1);
        yield return Mistakes();
        yield return new WaitForSeconds(1);
        yield return Accuracy();
        yield return new WaitForSeconds(1);
        ShardAward();
    }
    
    private bool GetNameAndIsFinished()
    {
       showName.text = chara.characters[playInfo.playerInfo.CharacterIndex].name;
        areaDetails.areas[PlayerInfo.playerInfo.Area].levelLists[PlayerInfo.playerInfo.Level].isFinished = true;
        PlayerInfo.playerInfo.PlayerScore = (long)inputDetector.myScore;

        return true;
    }


    private bool ScoreCount()
    {

        playInfo.playerInfo.PlayerScore = (long)Mathf.Max(playInfo.playerInfo.PlayerScore, inputDetector.myScore);
        if (timer >= countDuration)
        {
            showScore.text = "Score: " + inputDetector.myScore.ToString("0000000000");
            

            return true;
        }

        else if (i < inputDetector.myScore && timer < countDuration)
        {
            timer += Time.deltaTime;
            float progress = Mathf.Clamp01(timer / countDuration);
            i = Mathf.Lerp(0, inputDetector.myScore, progress);
            showScore.text = "Score: " + i.ToString("0000000000");
            return false;

        }
        else
        {
            return false;
        }
    }

    private bool TimeCount()
    {
        timeElapsed = wordDropper.timeLeftInit - wordDropper.timeLeft;
        int minutes = (int)(timeElapsed / 60);
        int seconds = (int)(timeElapsed % 60);

        elapsedTime.text = "Time Elapsed: " + minutes.ToString("00") + ":" + Mathf.RoundToInt(seconds).ToString("00");


        return true;
    }

    private bool WPM()
    {
        float letterTyped = inputDetector.typeCount;

        showWPM.text = Mathf.RoundToInt((letterTyped/5)/ (timeElapsed/60)).ToString();

        return true;
    }

    private bool Mistakes()
    {
        float mistakes = inputDetector.mistakes;

        showMistakes.text = mistakes.ToString();

        return true;
    }

    private bool Accuracy()
    {
        float letterTyped = inputDetector.typeCount;
        float mistakes = inputDetector.mistakes;
        double percentage = ((letterTyped - mistakes)/letterTyped) * 100;
        showAccuracy.text = percentage.ToString("F2")+"%";

        return true;
    }

    private void LoadSprite()
    {


        Sprite spriteArt = chara.characters[playInfo.playerInfo.CharacterIndex].spriteArtFullBody;
        
        characterDisplay.sprite  = spriteArt;
        characterSihlouette.sprite = spriteArt;

        characterDisplay.rectTransform.sizeDelta = new Vector2(spriteArt.texture.width, spriteArt.texture.height);
        characterSihlouette.rectTransform.sizeDelta = new Vector2(spriteArt.texture.width, spriteArt.texture.height);
    }


    private bool ShardAward()
    {
        if (!isDone)
        {
            int shard = 0;
            
            if(inputDetector.myScore >= 1900)
            {
                shard++;
            }
            
            
            float letterTyped = inputDetector.typeCount;
            float mistakes = inputDetector.mistakes;
            //Accuracy

            double percentage = ((letterTyped - mistakes) / letterTyped) * 100;
            //WPM
            int wpm = Mathf.RoundToInt((letterTyped / 5) / (timeElapsed / 60));


            if (wpm >= 36)
            {
                shard++;
            }
            if (percentage >= 80f)
            {
                shard++;
            }

            Debug.LogError("SHARD COUNT: " + shard);
            areaDetails.areas[PlayerInfo.playerInfo.Area].levelLists[PlayerInfo.playerInfo.Level].shardCount = Mathf.Max(shard, areaDetails.areas[PlayerInfo.playerInfo.Area].levelLists[PlayerInfo.playerInfo.Level].shardCount);
            playProgress.SaveGame();
            isDone = true;
        }



        return true;
    }
}
