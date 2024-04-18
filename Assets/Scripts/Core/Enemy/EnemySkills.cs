using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySkills: MonoBehaviour
{
    private AudioSource sound;
    private BGMPlayer BGMPlay;
    [SerializeField] private AudioClip[] sfx;
    public PlayerInfo playerInfo;
    public AreaDetails areaDetails;
    public Animator enemyAnime;
    public AnimatorOverrideController[] enemyAnim;
    InputDetector inputDetector;
    PlayerSkills skill;
    WordDropper word;
    [SerializeField] private float coolDown, temp;
    


    private char[] symbolArray = {  '!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '-', '.', '/',
                                    ':', ';', '<', '=', '>', '?', '@', '[', ']', '^', '_', '`', '{', '|', '}',
                                    '~', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n',
                                    'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };



    void Start()
    {
        BGMPlay = FindObjectOfType<BGMPlayer>();
        sound = FindObjectOfType<AudioSource>();
        word = FindObjectOfType<WordDropper>();
        inputDetector = FindObjectOfType<InputDetector>();
        skill = FindObjectOfType<PlayerSkills>();
        temp = coolDown;
        enemyAnime.runtimeAnimatorController = enemyAnim[areaDetails.areas[playerInfo.playerInfo.Area].levelLists[playerInfo.playerInfo.Level].aiAnim];
    }

    void Update()
    {
        if (word.isBattle)
        {
            coolDown -= Time.deltaTime;
            CheckAILevel(areaDetails.areas[playerInfo.playerInfo.Area].levelLists[playerInfo.playerInfo.Level].aiLevel);
        }

        
        
    }

    private void CheckAILevel(int index)
    {

            switch (index)
            {
                case 0:
                    AILvl1();
                    break;

                case 1:
                    AILvl2();
                    break;

                case 2:
                    AILvl3();
                    break;

                case 3:
                    AILvl4();
                    break;

                case 4:
                    AILvl5();
                    break;

                case 5:
                    AILvl6();
                    break;

                case 6:
                    AILvl7();
                    break;

                case 7:
                    AILvl8();
                    break;

                case 8:
                    AILvl9();
                    break;
                
                default:

                    break;
            }
        

    }

    private void AILvl1()
    {
        if (coolDown <= 0)
        {
            coolDown = temp;
        }
    }

                                                //Cancel out boost Minimal
    private void AILvl2()
    {
        if (coolDown <= 0)
        {
            float number = UnityEngine.Random.Range(0f, 10f);
            if (inputDetector.boostCounter >= 1)
            {
                if (number <= 3.5f && skill.boostActivated)
                {
                    inputDetector.chibiAnime.SetTrigger("Attack");
                    enemyAnime.SetTrigger("Attack");
                    sound.PlayOneShot(sfx[1], BGMPlay.sfxVol); //Destroy
                    skill.timeDuration = 0; //Cancel out boost
                                            //Attack Animation here

                }
            }
            coolDown = temp;
        }
    }
                                                //Corrupt text minimal
    private void AILvl3()
    {
        float number3 = 9;
        if (coolDown <= 0)
        {
            number3 = UnityEngine.Random.Range(0f, 9f);
            if (number3 <= 3.5f)
            {
                char[] corruptWord = word.remainingWord.ToCharArray();
                int index = UnityEngine.Random.Range(0, word.remainingWord.Length);
                corruptWord[index] = symbolArray[UnityEngine.Random.Range(0, symbolArray.Length)];
                string corrupted = new string(corruptWord);
                inputDetector.chibiAnime.SetTrigger("Attack");
                enemyAnime.SetTrigger("Attack");
                sound.PlayOneShot(sfx[2], BGMPlay.sfxVol); //Glitch
                word.SetRemainingWord(corrupted);
                Debug.LogError("Word Corrupted");
                // Attack Animation here 
            }
            coolDown = temp;
        }
        
    }

    private void AILvl4()
    {
        if (coolDown <= 0)
        {
            coolDown = temp;
        }
    }
    private void AILvl5()
    {
        if (coolDown <= 0)
        {
            coolDown = temp;
        }
    }
    private void AILvl6()
    {
        if (coolDown <= 0)
        {
            coolDown = temp;
        }
    }
                                                //Cancel AND Subtract time
    private void AILvl7()
    {
        if (coolDown <= 0)
        {

            int number = UnityEngine.Random.Range(0, 2);
            Debug.LogError(number);
            if (number == 0)
            {
                float number2 = UnityEngine.Random.Range(0f, 9f);
                if (number2 <= 8.5f && skill.boostActivated)
                {
                    enemyAnime.SetTrigger("Attack");
                    inputDetector.chibiAnime.SetTrigger("Attack");
                    sound.PlayOneShot(sfx[1], BGMPlay.sfxVol); //Destroy
                    skill.timeDuration = 0; //Cancel out boost
                                            //Attack Animation here
                }

            }
            else if (number == 1)
            {
                float number3 = UnityEngine.Random.Range(0f, 10f);
                Debug.LogWarning(number3);

                if (number3 <= 4f)
                {
                    enemyAnime.SetTrigger("Attack");
                    inputDetector.chibiAnime.SetTrigger("Attack");
                    word.timeLeft -= 1;
                    // Attack Animation here
                }

            }


            coolDown = temp;
        }


    }
    private void AILvl8()
    {
        if (coolDown <= 0)
        {
            coolDown = temp;
        }
    }

                                                //Cancel out AND Corrupt Word
    private void AILvl9()
    {
        if (coolDown <= 0)
        {

            int number = UnityEngine.Random.Range(0, 2);
            Debug.LogError(number);
            if (number == 0)
                {
                float number2 = UnityEngine.Random.Range(0f, 9f);
                if (number2 <= 8.5f && skill.boostActivated)
                {
                    enemyAnime.SetTrigger("Attack");
                    inputDetector.chibiAnime.SetTrigger("Attack");
                    sound.PlayOneShot(sfx[1], BGMPlay.sfxVol); //Destroy
                    skill.timeDuration = 0; //Cancel out boost
                                                //Attack Animation here
                }

            }
            else if (number == 1)
            {
                float number3 = UnityEngine.Random.Range(0f, 10f);
                Debug.LogWarning(number3);

                if (number3 <= 8.5f)
                {
                    enemyAnime.SetTrigger("Attack");
                    char[] corruptWord = word.remainingWord.ToCharArray();
                    int index = UnityEngine.Random.Range(0, word.remainingWord.Length);
                    corruptWord[index] = symbolArray[UnityEngine.Random.Range(0, symbolArray.Length)];
                    string corrupted = new string(corruptWord);
                    inputDetector.chibiAnime.SetTrigger("Attack");
                    sound.PlayOneShot(sfx[2], BGMPlay.sfxVol); //Glitch
                    word.SetRemainingWord(corrupted);
                    Debug.LogWarning("Word Corrupted");
                    // Attack Animation here
                }

            }
          
            coolDown = temp;
        }

    }

}
