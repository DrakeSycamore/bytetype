using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BannerDetails : MonoBehaviour
{
    public PlayerInfo PlayerInfo;
    public AreaDetails areaDetails;
    public TMP_Text shardCount;
    public TMP_Text myScore;
    public Button EnterButton;
    public string selectionType;
    private void Start()
    {
        
    }
    void Update()
    {
        UpdatePlayerInfo();
        GetType();
    }


    private void GetType()
    {
        switch (selectionType) {

            case "Area":
                GetAreaAndStart();
                break;
            case "Level":
                GetLevelAndStart();
                break;
        
        }

    }





    private void UpdatePlayerInfo()
    {
        shardCount.text = $"SHARDS: {PlayerInfo.playerInfo.CrystalShards}";
        myScore.text = $"HIGH SCORE: {PlayerInfo.playerInfo.PlayerScore:0000000000}";
        GetShardsAndStart();
    }

    private void GetAreaAndStart()
    {
        EnterButton.interactable = !(PlayerInfo.playerInfo.Area == -1);
    }
    private void GetLevelAndStart()
    {
        EnterButton.interactable = !(PlayerInfo.playerInfo.Level == -1);
    }

    private void GetShardsAndStart()
    {
        int totalShards = 0;
        for (int i = 0; i < areaDetails.areas.Count; i++)
        {
            for (int j = 0; j < areaDetails.areas[i].levelLists.Count; j++)
            {
                totalShards += areaDetails.areas[i].levelLists[j].shardCount;
            }
        }
        PlayerInfo.playerInfo.CrystalShards = totalShards;
    }
}
