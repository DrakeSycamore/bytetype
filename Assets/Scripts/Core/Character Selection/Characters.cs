
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "NewCharacters", menuName = "Custom/Characters")]
public class Characters : ScriptableObject
{

    [System.Serializable]
     public class CharInfo
    {
        public string name;
        public bool isUnlocked = false;
        public uint scoreMultiplier = 1;
        public float timeMultiplier = 1;
        public SkillType skillType;
        public Color32 color;
        public Sprite spriteArtFullBody;
        public Sprite charIcon;
        public AnimatorOverrideController animationSet;
        public AudioClip[] attackSound;
        public AudioClip[] attackCritSound;
        public AudioClip[] attackMissedSound;
        public AudioClip Victory;
        public AudioClip Lose;
    }

    [System.Serializable]
    public struct SkillType
    {
        public bool scoreMultiply;
        public bool timeSlow;
        public bool timeFreeze;
        public bool wordSkip;
    }

    public List<CharInfo> characters = new List<CharInfo>();

    // You can use the Inspector to populate the list with initial data.

    //public void UpdateCharacterData(int index, CharInfo newData)
    //{
    //    if (index >= 0 && index < CharacterData.Count)
    //    {
    //        CharacterData[index] = newData;
    //    }
    //}

}
