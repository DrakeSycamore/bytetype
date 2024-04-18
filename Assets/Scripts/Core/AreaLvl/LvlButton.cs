using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlButton : MonoBehaviour
{   

    public AreaDetails areaDetails;
    public PlayerInfo playerInfo;
    [SerializeField] private LevelViewer levelViewer;

    public GameObject[] shardObjects;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ShardCount();

    }


    public void ShardCount()
    {

        for (int i = 0; i < areaDetails.areas[playerInfo.playerInfo.Area].levelLists[levelViewer.myIndex].shardCount; i++)
        {
            shardObjects[i].SetActive(true);
        }
        
    }
}
