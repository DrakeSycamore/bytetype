using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelViewer : MonoBehaviour
{
    // Start is called before the first frame update
    public AreaDetails areaDetails;
    public AudioClip select;
    public AudioSource sound;
    public BGMPlayer bGMPlayer;
    public PlayerInfo playerInfo;
    public Image levelBG;
    public Button lvlButton;
    public TMP_Text levelName;
    public TMP_Text shardText;
    public int myIndex;


    void Start()
    {   
        //sound = FindObjectOfType<AudioSource>();
        bGMPlayer = FindObjectOfType<BGMPlayer>();
        bGMPlayer.LoadAndPlayBGM(2);
        GetLevelInfo();
    }

    void Update()
    {
        CheckIfLevelFinished();
        if (Input.GetMouseButtonDown(0))
        {
            bGMPlayer.sound.PlayOneShot(select, 0.7f);
            HandleMouseClick();
        }
    }


    private void GetLevelInfo()
    {   levelBG.color = areaDetails.areas[playerInfo.playerInfo.Area].areaColor;
        levelName.text = (myIndex + 1).ToString();

        ColorBlock buttonColors = lvlButton.colors;
        buttonColors.normalColor = new Color32((byte)Mathf.Max(areaDetails.areas[playerInfo.playerInfo.Area].areaColor.r -72, 0), (byte)Mathf.Max(areaDetails.areas[playerInfo.playerInfo.Area].areaColor.g - 72, 0), (byte)Mathf.Max(areaDetails.areas[playerInfo.playerInfo.Area].areaColor.b -72, 0) , (byte)(areaDetails.areas[playerInfo.playerInfo.Area].areaColor.a));
        buttonColors.highlightedColor = areaDetails.areas[playerInfo.playerInfo.Area].areaColor;
        buttonColors.pressedColor = new Color32((byte)Mathf.Max(areaDetails.areas[playerInfo.playerInfo.Area].areaColor.r - 100, 0), (byte)Mathf.Max(areaDetails.areas[playerInfo.playerInfo.Area].areaColor.g - 100, 0), (byte)Mathf.Max(areaDetails.areas[playerInfo.playerInfo.Area].areaColor.b - 100, 0), (byte)(areaDetails.areas[playerInfo.playerInfo.Area].areaColor.a));
        buttonColors.selectedColor = new Color32((byte)Mathf.Max(areaDetails.areas[playerInfo.playerInfo.Area].areaColor.r - 30, 0), (byte)Mathf.Max(areaDetails.areas[playerInfo.playerInfo.Area].areaColor.g - 30, 0), (byte)Mathf.Max(areaDetails.areas[playerInfo.playerInfo.Area].areaColor.b - 30, 0), (byte)(areaDetails.areas[playerInfo.playerInfo.Area].areaColor.a));
        buttonColors.disabledColor = Color.black;
        lvlButton.colors = buttonColors;
    }


    private void CheckIfLevelFinished()
    {
        if (areaDetails.areas[playerInfo.playerInfo.Area].levelLists[Mathf.Max(myIndex-1, 0)].isFinished || myIndex-1 < 0)
        {
            gameObject.GetComponentsInChildren<Transform>().Any(child =>
                child.GetComponentsInChildren<Button>().Any(button => button.interactable = true));
        }
        else
        {
            gameObject.GetComponentsInChildren<Transform>().Any(child =>
                child.GetComponentsInChildren<Button>().Any(button => button.interactable = false));
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
                child.GetComponentsInChildren<Button>().Any(button => button.interactable));


        playerInfo.playerInfo.Level = isValidSelection ? playerInfo.playerInfo.Level : -1;
    }

    public void SelectLevel(int tempIndex)
    {
        playerInfo.playerInfo.Level = tempIndex;

        Debug.LogError("Selected level index: " + playerInfo.playerInfo.Level);
    }
}
