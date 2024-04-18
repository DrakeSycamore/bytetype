using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewAreaDetails", menuName = "Custom/AreaDetails")]
public class AreaDetails : ScriptableObject
{
    // Start is called before the first frame update
    public List<AreaDetailList> areas = new List<AreaDetailList>();

    [System.Serializable]
    public class AreaDetailList 
    {   
        public string name;
        public string description;
        public int shardRequired;
        public Color32 areaColor;
        public Sprite bgImage;
        public List<LevelList> levelLists = new List<LevelList>();


    }

    [System.Serializable]
    public class LevelList
    {
        public int bankIndex;
        public Color32 levelColor;
        public int aiLevel;
        public int aiAnim;
        public bool isFinished;
        public int shardCount;
    }


}
