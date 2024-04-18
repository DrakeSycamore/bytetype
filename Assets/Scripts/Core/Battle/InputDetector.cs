using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputDetector : MonoBehaviour
{
    private WordDropper word;
    private PlayerSkills skills;
    private AudioSource audioS;
    public Characters chara;
    public PlayerInfo playInfo;

    public ulong myScore;
    public uint baseScore = 1;
    public TMP_Text score;
    public Animator chibiAnime;

    public uint scoreMultiplier;
    public float timeMultiplier;

    public Image fillBar;
    private float fillCount = 0;
    private float oldFillCount = 0;
    public float partition;
    public float fillSpeed;
    public bool boostActive = false;

    public GameObject boostEffect;

    public uint typeCount;
    public uint mistakes;

    private GameObject ready;
    [HideInInspector] public int boostCounter;

    private const KeyCode EnterKey = KeyCode.KeypadEnter;

    void Start()
    {
        word = FindObjectOfType<WordDropper>();
        skills = FindObjectOfType<PlayerSkills>();
        audioS = FindObjectOfType<AudioSource>();
        ready = GameObject.Find("Ready");
        chibiAnime.runtimeAnimatorController = chara.characters[playInfo.playerInfo.CharacterIndex].animationSet;
        DefaultValues();
        myScore = 0;
        ready.SetActive(false);
        boostEffect.SetActive(false);
        fillBar.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        InputChecker();
        BoostBarAnim();
    }

    private void InputChecker()
    {
        if (Input.anyKeyDown && word.isBattle)
        {
            string keysPressed = Input.inputString.ToLower();
            if (keysPressed.Length == 1)
            {
                if (word.IsCorrectLetter(keysPressed))
                {
                    chibiAnime.SetTrigger("ComboA");
                    HandleCorrectInput(keysPressed);
                }
                else if (!(Input.GetKeyDown(EnterKey) || Input.GetKeyDown(KeyCode.Return)))
                {
                    chibiAnime.SetTrigger("Hit");
                    HandleIncorrectInput();
                }
            }

            if (boostActive && (Input.GetKeyDown(EnterKey) || Input.GetKeyDown(KeyCode.Return)))
            {
                chibiAnime.SetTrigger("ComboA");
                HandleBoostActivation();
            }
        }
    }

    private void HandleCorrectInput(string key)
    {
        fillCount++;
        baseScore++;
        typeCount++;
        if (baseScore >= 5)
        {
            baseScore = 5;
        }
        DataHandler(0);
        Debug.LogWarning(key);
        word.EnterLetter(key);

        PlayAttackSound();
    }

    private void HandleIncorrectInput()
    {
        float maxMissedSound = chara.characters[playInfo.playerInfo.CharacterIndex].attackSound.Length;
        int randMissedSound = (int)UnityEngine.Random.Range(0, maxMissedSound);
        baseScore = 1;
        mistakes++;
        audioS.PlayOneShot(chara.characters[playInfo.playerInfo.CharacterIndex].attackMissedSound[randMissedSound]);
    }

    private void HandleBoostActivation()
    {
        boostCounter++;
        word.PlaySfx(3);
        boostActive = false;
        ready.SetActive(false);
        fillBar.fillAmount = 0;
        oldFillCount = 0;
        fillCount = 0;
        boostEffect.SetActive(true);
        boostEffect.GetComponent<Image>().color = chara.characters[playInfo.playerInfo.CharacterIndex].color;
        skills.boostActivated = true;
        skills.ToggleTime();
    }

    private void PlayAttackSound()
    {
        float maxAttackSound = chara.characters[playInfo.playerInfo.CharacterIndex].attackSound.Length;
        int randAttackSound = (int)UnityEngine.Random.Range(0, maxAttackSound);
        audioS.PlayOneShot(chara.characters[playInfo.playerInfo.CharacterIndex].attackSound[randAttackSound]);
    }

    public void DataHandler(int index)
    {
        switch (index)
        {
            case 0: //score
                myScore += baseScore * scoreMultiplier;
                PrintScore();
                break;

            case 1:
                break;
        }
    }

    public void DefaultValues()
    {
        scoreMultiplier = 1;
        timeMultiplier = 1;
        boostEffect.SetActive(false);
        word.ResetVisuals();
    }

    public void PrintScore()
    {
        score.text = "SCORE:  " + myScore.ToString("0000000000");
    }

    public void BoostBarAnim()
    {
        if (oldFillCount < fillCount)
        {
            fillBar.fillAmount = oldFillCount / partition;
            oldFillCount += Time.deltaTime * fillSpeed;
        }

        if (fillCount >= partition && !boostActive)
        {   

            word.PlaySfx(1);
            boostActive = true;
            ready.SetActive(true);
        }
    }
}
