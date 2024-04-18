using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Linq;
using System.Collections.Generic;

public class CharaSelect : MonoBehaviour
{
    public PlayerInfo PlayerInfo;
    public AudioSource sound;
    public AudioClip select;
    public AreaDetails areaDetails;
    public Characters characters;
    BGMPlayer BGMPlay;
    public LoadSceneScreen loadScrn;
    public GameObject HayanoGO, MiharuGO;
    public Button HayanoButton, HayanoGlow;
    public Button MiharuButton, MiharuGlow;
    public Button StartButton;

    private void Start()
    {   
        //sound = FindObjectOfType<AudioSource>();
        BGMPlay = FindObjectOfType<BGMPlayer>();
        PlayerInfo.playerInfo.CharacterIndex = -1;
    }

    private void Update()
    {
        BGMPlay.LoadAndPlayBGM(2);
        UnlockMiharu();
        GetCharAndStart();


        if (Input.GetMouseButtonDown(0))
        {
            BGMPlay.sound.PlayOneShot(select, 0.7f);
            HandleMouseClick();
        }
    }

    private void HandleMouseClick()
    {
            PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        GameObject selectedObject = results.Count > 0 ? results[0].gameObject : null;

        bool isValidSelection = selectedObject != null &&
            selectedObject.GetComponentsInChildren<Transform>().Any(child =>
                child.GetComponentsInChildren<Button>().Any(button => button.interactable)) ||
            selectedObject == StartButton.gameObject;

        PlayerInfo.playerInfo.CharacterIndex = isValidSelection ? PlayerInfo.playerInfo.CharacterIndex : -1;

        Debug.LogWarning(isValidSelection ? "Button Selected" : "Button NOT Selected");
        
    }

    private void UnlockMiharu()
    {
        bool allLevelsFinished = true;

        for (int i = 0; i < areaDetails.areas[0].levelLists.Count; i++)
        {
            if (!areaDetails.areas[0].levelLists[i].isFinished)
            {
                allLevelsFinished = false;
                break;
            }
        }

        if (allLevelsFinished && areaDetails.areas[1].shardRequired <= PlayerInfo.playerInfo.CrystalShards)
        {
            StartCoroutine(AnimateUnlock());
        }
        else
        {
            SetButtonInteractable(MiharuButton, MiharuGlow, false);
        }
    }

    private IEnumerator AnimateUnlock()
    {
        //yield return new WaitForSeconds(/* Animation duration */);

        SetButtonInteractable(MiharuButton, MiharuGlow, true);
        yield return characters.characters[1].isUnlocked = true;
    }

    private void SetButtonInteractable(Button button, Button glow, bool interactable)
    {
        button.interactable = interactable;
        glow.interactable = interactable;
    }

    private void GetCharAndStart()
    {
        StartButton.interactable = !(PlayerInfo.playerInfo.CharacterIndex > 1 || PlayerInfo.playerInfo.CharacterIndex < 0);
    }

    public void SelectChar(int tempIndex)
    {
        PlayerInfo.playerInfo.CharacterIndex = tempIndex;
        Debug.LogError("Selected character index: " + PlayerInfo.playerInfo.CharacterIndex);
    }


}
