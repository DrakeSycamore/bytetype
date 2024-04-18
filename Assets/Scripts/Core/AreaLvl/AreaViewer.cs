using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Linq;
using Unity.VisualScripting;

public class AreaViewer : MonoBehaviour
{
    private AudioSource sound;
    public BGMPlayer BGMPlayer;
    public AreaDetails areaDetails;
    public AudioClip select;
    public PlayerInfo playerInfo;
    public Image background;
    public TMP_Text areaName;
    public TMP_Text shardText;
    [SerializeField] private int myIndex;


    void Start()
    {
        //sound = FindObjectOfType<AudioSource>();
        BGMPlayer = FindObjectOfType<BGMPlayer>();
        BGMPlayer.LoadAndPlayBGM(2);
        GetAreaInfo();

    }

    void Update()
    {
        CheckShardRequirements();
        if (Input.GetMouseButtonDown(0))
        {
            BGMPlayer.sound.PlayOneShot(select, 0.7f);
            HandleMouseClick();
        }
    }


    private void GetAreaInfo()
    {

        areaName.text = areaDetails.areas[myIndex].name;
        background.sprite = areaDetails.areas[myIndex].bgImage;
        shardText.text = areaDetails.areas[myIndex].shardRequired.ToString();
    }


    private void CheckShardRequirements()
    {
        if (playerInfo.playerInfo.CrystalShards >= areaDetails.areas[myIndex].shardRequired)
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


        playerInfo.playerInfo.Area = isValidSelection ? playerInfo.playerInfo.Area : -1;
    }

    public void SelectArea(int tempIndex)
    {
        playerInfo.playerInfo.Area = tempIndex;
        Debug.LogError("Selected character index: " + playerInfo.playerInfo.Area);
    }



































    //    public double ShardCount;
    //    public double ShardCountBank;
    //    public TMP_Text ShardCountTxt;
    //    public int AreaIndex;
    //    public TMP_Text AreaNameTxt;
    //    public TMP_Text AreaDescTxt;

    //    public RawImage backgroundImage;
    //    public Button AreaButtonPrefab;
    //    public Transform btnArea;

    //    ButtonListener btnListen;

    //    BGAreaAnimator bgAnim;

    //    private Button button;

    //    public int btnCount;
    //    public List<Button> btnList = new List<Button>();
    //    public List<AreaDisplay> Areas = new List<AreaDisplay>();

    //    void Start()
    //    {
    //        btnListen = FindObjectOfType<ButtonListener>();
    //        bgAnim = FindObjectOfType<BGAreaAnimator>();

    //        ShardCountBank = ShardCount;
    //        StartCoroutine(setAreas());
    //    }


    //    void Update()
    //    {   
    //        shardViewer();
    //        AreaRefresher();
    //    }

    //    [System.Serializable]
    //    public class AreaDisplay
    //    {
    //        public string AreaName;
    //        public string AreaDescription;
    //        public bool AreaIsLocked;
    //        public int ShardRequired;
    //        public Texture background;

    //    }
    //    public void selectArea(int index)
    //    {   
    //        AreaNameTxt.text = Areas[index].AreaName;
    //        Debug.Log(Areas[index].AreaName);
    //        AreaDescTxt.text = Areas[index].AreaDescription;
    //        StartCoroutine(bgAnim.bgSwitch(index));

    //    }

    //    public void AreaLockChecker(int index)
    //    {
    //        if (Areas[index].ShardRequired > ShardCount)
    //        {   
    //            Areas[index].AreaIsLocked = true;
    //            button.interactable = false;
    //            string indexName = index.ToString();
    //            button.GetComponentInChildren<TMP_Text>().text = "Locked";
    //        }
    //        else
    //        {   
    //            Areas[index].AreaIsLocked = false;
    //            button.interactable = true;
    //            button.GetComponentInChildren<TMP_Text>().text = Areas[index].AreaName;
    //        }

    //    }

    //    public void AreaRefresher()
    //    {
    //        if(ShardCount != ShardCountBank)
    //        {   

    //            GameObject[] destroyables = GameObject.FindGameObjectsWithTag("Area");
    //            foreach (var button in destroyables)
    //            {
    //                Destroy(button);
    //                Debug.LogWarning("Removed button");
    //            }
    //            btnList.Clear();
    //            StartCoroutine(setAreas());
    //            StartCoroutine(btnListen.AfterButtonDestroyed());
    //            ShardCountBank = ShardCount;

    //        }
    //        if (GameObject.FindGameObjectsWithTag("Area") == null)
    //        {
    //            StartCoroutine(setAreas());
    //            StartCoroutine(btnListen.AfterButtonDestroyed());
    //        }


    //    }


    //    public IEnumerator setAreas()
    //    {   
    //        for (int i = 0; i < btnCount; i++)
    //        {
    //            button = Instantiate(AreaButtonPrefab);
    //            button.name = "" + i;
    //            button.transform.SetParent(btnArea, false);
    //            btnList.Add(button.GetComponent<Button>());
    //            Debug.LogWarning("Created button");
    //            AreaLockChecker(i);
    //        }
    //        yield return new WaitForSeconds(2000f);;

    //    }

    //    void shardViewer()
    //    {
    //        ShardCountTxt.text = ShardCount.ToString();
    //    }




    //    public void MoveToLvlSlct()
    //    {   
    //        Debug.LogError("Area " + AreaIndex + 1 + " Selected!");
    //        SceneManager.LoadScene("LevelSelection");
    //    }

    //    public void BackToMainMenu()
    //    {   
    //        SceneManager.LoadScene("MainMenu");
    //    }






    //    // void AddListeners()
    //    // {
    //    //     foreach (Button button in btnList)
    //    //     {
    //    //         button.onClick.AddListener(() => btnListen.OnClick());
    //    //     }
    //    // }




    //    // public void Name(string name)
    //    // {
    //    //     AreaName.text = name;
    //    // }

    //    // public void Desc(string desc)
    //    // {
    //    //     AreaDescription.text = desc;
    //    // }

    //    // public void BGImage(int index)
    //    // {
    //    //     background.image = background;
    //    // }

    //    // public void selectArea(string area)
    //    // {   
    //    //     switch(area){

    //    //         case "Area1":
    //    //             areaDet.Area1();
    //    //             break;

    //    //         case "Area2":
    //    //             areaDet.Area2();
    //    //             break;

    //    //         case "Area3":
    //    //             areaDet.Area3();
    //    //             break;

    //    //         case "Area4":
    //    //             areaDet.Area4();
    //    //             break;

    //    //         case "Area5":
    //    //             areaDet.Area5();
    //    //             break;

    //    //     }
    //    // }
    //}
}

