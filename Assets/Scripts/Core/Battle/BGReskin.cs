using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGReskin : MonoBehaviour
{
    public AreaDetails areaDetails;
    public PlayerInfo playInfo;
    public Camera cam;
    public Image bgImage;
    public Image floorImage;
    public RawImage roofImage;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    private void Start()
    {
        ChangeBG();
    }


    void ChangeBG()
    {
        
        cam.backgroundColor = areaDetails.areas[playInfo.playerInfo.Area].levelLists[playInfo.playerInfo.Level].levelColor;
        bgImage.sprite = areaDetails.areas[playInfo.playerInfo.Area].bgImage;
        roofImage.color = areaDetails.areas[playInfo.playerInfo.Area].areaColor;
        floorImage.color = areaDetails.areas[playInfo.playerInfo.Area].areaColor;
        bgImage.color = areaDetails.areas[playInfo.playerInfo.Area].areaColor;


    }
}
