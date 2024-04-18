using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WordDropper : MonoBehaviour
{
    private AreaBanks allBank;
    private InputDetector inputDetector;
    private AudioSource audioSource;
    public Characters chara;
    public PlayerInfo playInfo;
    public AreaDetails areaDetails;
    private PlayerSkills skills;
    private BGMPlayer BGMPlay;
    private EnemySkills enemy;


    public TMP_Text areaLevelText;
    public GameObject wordDrop;
    public TMP_Text wordOutput;

    public GameObject countObject;
    public Animator anim;
    public Image charIcon;
    public TMP_Text countDown;

    public GameObject WinPanel;
    public GameObject LosePanel;

    public float timeLeft;
    [HideInInspector] public float timeLeftInit;

    public TMP_Text timer;
    public bool isBattle = false;

    private float second = 0;
    public string remainingWord = string.Empty;

    [SerializeField] private List<AudioClip> audioSFX = new List<AudioClip>();
    [SerializeField] private List<AudioClip> audioBGM = new List<AudioClip>();

    void Start()
    {
        allBank = FindObjectOfType<AreaBanks>();
        inputDetector = FindObjectOfType<InputDetector>();
        skills = FindObjectOfType<PlayerSkills>();
        enemy = FindObjectOfType<EnemySkills>();
        audioSource = FindObjectOfType<AudioSource>();
        BGMPlay = FindObjectOfType<BGMPlayer>();

        timeLeftInit = timeLeft;
        anim = countObject.GetComponentInChildren<Animator>();

        allBank.currentBank.AddRange(allBank.AllBanks[areaDetails.areas[playInfo.playerInfo.Area].levelLists[playInfo.playerInfo.Level].bankIndex]);
        Shuffle(allBank.currentBank);
        ConvertToLower(allBank.currentBank);
        StartCoroutine(BattleSequence());
        BGMPlay.LoadAndPlayBGM(3);
    }

    private void Update()
    {
        
        AreaLevelDisplay();

        inputDetector.fillBar.color = chara.characters[playInfo.playerInfo.CharacterIndex].color;
        charIcon.sprite = chara.characters[playInfo.playerInfo.CharacterIndex].charIcon;

        if (isBattle)
        {
            TimeRunningOut();

            int minutes = (int)(timeLeft / 60);
            int seconds = (int)(timeLeft % 60);

            timer.text = minutes + ":" + Mathf.RoundToInt(seconds).ToString("00");
            timeLeft -= Time.deltaTime * inputDetector.timeMultiplier;
        }

        if (timeLeft <= 0)
        {
            isBattle = false;
            StartCoroutine(GameOver());
        }

        if (allBank.currentBank.Count == 0 && remainingWord.Length == 0)
        {
            isBattle = false;
            StartCoroutine(WinBattle());
        }
    }

    private void TimeRunningOut()
    {
        if (timeLeft <= 10)
        {
            timerColorize(1);
            second -= Time.deltaTime;
            if (second <= 0)
            {
                PlaySfx(2);
                second = 1;
            }
        }

        if (timeLeft > 10 && !skills.boostActivated)
        {
            timerColorize(0);
        }
    }

    public void PlaySfx(int index)
    {
        audioSource.PlayOneShot(audioSFX[index], BGMPlay.sfxVol);
    }

    private void PlaySound(int index)
    {
        audioSource.clip = audioBGM[index];
        audioSource.Play();
    }

    private void timerColorize(int index)
    {
        switch (index)
        {
            case 0:
                timer.color = Color.white;
                break;
            case 1:
                timer.color = Color.red;
                break;
        }
    }

    IEnumerator BattleSequence()
    {
        wordDrop.SetActive(false);
        yield return new WaitForSeconds(2);
        countObject.SetActive(true);
        audioSource.PlayOneShot(audioSFX[0], BGMPlay.sfxVol);
        anim.SetTrigger("Bam");
        countDown.text = "3";
        yield return new WaitForSeconds(1);
        anim.SetTrigger("Bam");
        countDown.text = "2";
        yield return new WaitForSeconds(1);
        anim.SetTrigger("Bam");
        countDown.text = "1";
        yield return new WaitForSeconds(1);
        anim.SetTrigger("Bam");
        countDown.text = "START!";
        yield return new WaitForSeconds(0.5f);
        countObject.SetActive(false);
        wordDrop.SetActive(true);
        isBattle = true;
        SetCurrentWord();
    }

    IEnumerator GameOver()
    {
        BGMPlay.LoadAndPlayBGM(4);
        wordDrop.SetActive(false);
        countObject.SetActive(true);
        anim.SetTrigger("Bam");
        countDown.text = "TIME'S UP";
        yield return new WaitForSeconds(3);
        LosePanel.SetActive(true);
    }

    IEnumerator WinBattle()
    {
        BGMPlay.LoadAndPlayBGM(5);
        wordDrop.SetActive(false);
        countObject.SetActive(true);
        anim.SetTrigger("Bam");
        countDown.text = "LEVEL CLEAR";
        yield return new WaitForSeconds(3);
        WinPanel.SetActive(true);
    }

    public string GetWord()
    {
        string newWord = string.Empty;

        if (allBank.currentBank.Count != 0)
        {
            enemy.enemyAnime.SetTrigger("Attack");
            audioSource.PlayOneShot(audioSFX[4], BGMPlay.sfxVol);
            newWord = allBank.currentBank.Last();
            allBank.currentBank.Remove(newWord);
        }

        return newWord;
    }

    public void SetCurrentWord()
    {
        string currentWord = GetWord();
        SetRemainingWord(currentWord);
    }

    public void SetRemainingWord(string newString)
    {
        remainingWord = newString;
        wordOutput.text = remainingWord;
    }

    public void EnterLetter(string TypedLetter)
    {
        if (IsCorrectLetter(TypedLetter))
        {
            Debug.LogWarning("Correct Letter");
            RemoveLetter();

            if (IsWordComplete())
                SetCurrentWord();
        }
    }

    public bool IsCorrectLetter(string letter)
    {
        return remainingWord.IndexOf(letter) == 0;
    }

    public bool IsWordComplete()
    {
        return remainingWord.Length == 0;
    }

    public void RemoveLetter()
    {
        string newString = remainingWord.Remove(0, 1);
        SetRemainingWord(newString);
    }

    public void ResetVisuals()
    {
        wordOutput.color = Color.white;

        if (timeLeft > 10)
        {
            timer.color = Color.white;
        }

        inputDetector.score.color = Color.white;
    }

    public void AreaLevelDisplay()
    {
        int offset = 1;
        areaLevelText.text = "Area " + (playInfo.playerInfo.Area + offset) + " - Level " + (playInfo.playerInfo.Level + offset);
    }

    private void Shuffle(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int random = UnityEngine.Random.Range(i, list.Count);
            string temporary = list[i];
            list[i] = list[random];
            list[random] = temporary;
        }
    }

    private void ConvertToLower(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
            list[i] = list[i].ToLower();
    }
}
