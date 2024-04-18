using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerInfo", menuName = "Custom/PlayerInfo")]
public class PlayerInfo : ScriptableObject
{
    public PlayerInformation playerInfo;
    [System.Serializable]
    public class PlayerInformation
    {
        public string PlayerName = "Hayai Typing";
        public string CharacterSelected = "None";
        public int CharacterIndex = -01;
        public long PlayerScore = 0;
        public int CrystalShards;
        public int Area = 1;
        public int Level = 1;
        public bool HasFinished = false;
    }




}
