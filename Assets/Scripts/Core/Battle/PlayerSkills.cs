using System;
using TMPro;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    private WordDropper word;
    private InputDetector inputDetector;
    public Characters chara;
    public PlayerInfo playInfo;
    public bool boostActivated = false;
    public float timeDuration;
    private float timeDurTemp;

    public TMP_Text boostTimer;

    private void Start()
    {
        word = FindObjectOfType<WordDropper>();
        inputDetector = FindObjectOfType<InputDetector>();
        timeDurTemp = timeDuration;
    }

    private void Update()
    {
        BoostCheckDuration();
    }

    public void ToggleTime()
    {
        timeDuration = timeDurTemp;
    }

    // Additional functions
    private void BoostCheckDuration()
    {
        if (boostActivated)
        {   
            if (!boostTimer.gameObject.activeSelf)
            {
                boostTimer.gameObject.SetActive(true);
            }


            UpdateScreenInfo(playInfo.playerInfo.CharacterIndex);

            int minutes = (int)(timeDuration / 60);
            int seconds = (int)(timeDuration % 60);

            boostTimer.text = $"{minutes}:{(seconds + 0.9).ToString("00")}";

            if (timeDuration > 0)
            {
                timeDuration -= Time.deltaTime;
            }
            else
            {
                boostActivated = false;
                ToggleTime();
            }
        }
        else
        {
            inputDetector.DefaultValues();
            boostTimer.gameObject.SetActive(false);
        }
    }

    private void UpdateScreenInfo(int index)
    {
        inputDetector.scoreMultiplier = chara.characters[index].scoreMultiplier;
        inputDetector.timeMultiplier = chara.characters[index].timeMultiplier;
        CheckBoolType(index);
    }

    private void CheckBoolType(int index)
    {
        if (chara.characters[index].skillType.scoreMultiply)
        {
            inputDetector.score.color = chara.characters[index].color;
        }

        if (chara.characters[index].skillType.timeSlow)
        {
            word.timer.color = chara.characters[index].color;
        }
        else
        {
            
        }
    }
}
