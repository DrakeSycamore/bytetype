using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class MainMenu : MonoBehaviour
{

    BGMPlayer bgmPlayer;
    PlayerProgress playProgress;
    public TMP_Text NewGameContinue;
    public AudioSource sound;
    public AudioClip selectSound;
    public GameObject options;
    public GameObject buttons;
    public GameObject deleteSave;
    void Start()
    {
        playProgress = FindObjectOfType<PlayerProgress>();
        GameObject soundObject = GameObject.Find("SFXSpeaker");

        // If it doesn't exist, create a new one
        if (soundObject == null)
        {
            soundObject = new GameObject("SFXSpeaker");
            // Attach your AudioSource component to the new GameObject if needed
            soundObject.AddComponent<AudioSource>();
        }

        // Now you can get the AudioSource component
        sound = soundObject.GetComponent<AudioSource>();
        bgmPlayer = FindObjectOfType<BGMPlayer>();
        bgmPlayer.LoadAndPlayBGM(0);

    }
    // Update is called once per frame
    void Update()
    {
        CheckForData();


        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log(" Pressed Enter or Space ");
            SceneManager.LoadScene("AreaSelection");
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log(" Pressed Escape ");
        }
    }


    public void OnClick()
    {
        string MenuChoice = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(MenuChoice + " Selected");
        MainSceneSelect(MenuChoice);
    }

    private void CheckForData()
    {
        if (!playProgress.CheckData())
        {
            NewGameContinue.text = "New Game";
        }
        else
        {
            NewGameContinue.text = "Continue";
        }
    }
    void MainSceneSelect(string MenuChoice) {

        sound.PlayOneShot(selectSound, bgmPlayer.sfxVol);
        if (MenuChoice == "NewGame")
        {
            
            if (!playProgress.CheckData())
            {
                playProgress.SaveGame();
                Debug.LogError("Game Saved"); 
            }
            else
            {
                playProgress.LoadGame();
                Debug.LogError("Game Loaded");
            }
            SceneManager.LoadSceneAsync("AreaSelection");
        }
        else if (MenuChoice == "Options")
        {
            options.SetActive(true);
            buttons.SetActive(false);
        }
        else if (MenuChoice == "Quit Game")
        {   
            Debug.Log("Kunwari Naexit");
            Application.Quit();
        }

    }

    public void CloseOptions()
    {
        sound.PlayOneShot(selectSound, 1.0f);
        if (!options.activeSelf)
        {
            return;
        }
        options.SetActive(false);
        buttons.SetActive(true);
    }


    public void DataBlockClearPrompt()
    {
        options.SetActive(false);
        deleteSave.SetActive(true);
    }
    
    public void DataBlockCancelPrompt()
    {
        options.SetActive(true);
        deleteSave.SetActive(false);
    }

    public void DataBlockDelete()
    {
        playProgress.DeleteGame();
        options.SetActive(false);
        deleteSave.SetActive(false);
        buttons.SetActive(true);
    }

    
}
