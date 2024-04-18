using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{

    BGMPlayer bgmPlayer;
    public AudioSource sound;
    public AudioClip selectSound;
    public GameObject options;
    public GameObject buttons;
    void Start()
    {
        bgmPlayer = FindObjectOfType<BGMPlayer>();
        bgmPlayer.LoadAndPlayBGM(0);

    }
    // Update is called once per frame
    void Update()
    {

        

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

    void MainSceneSelect(string MenuChoice) {

        sound.PlayOneShot(selectSound, 1.0f);
        if (MenuChoice == "New Game")
        {
            SceneManager.LoadScene("AreaSelection");
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
}
