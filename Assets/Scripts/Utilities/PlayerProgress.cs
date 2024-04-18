using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    public PlayerInfo playInfo;
    public AreaDetails areaDetails;

    [System.Serializable]
    public class PlayerInformation
    {
        public string PlayerName;
        public long PlayerScore;
        public List<AreaDetailList> areas = new List<AreaDetailList>();
    }

    [System.Serializable]
    public class AreaDetailList
    {
        public List<LevelList> levelList = new List<LevelList>();
    }

    [System.Serializable]
    public class LevelList
    {
        public bool isFinished = false;
        public int shardCount = 0;
    }

    //public PlayerInformation data = new PlayerInformation();
    public static PlayerProgress instance; // Singleton instance

    void Awake()
    {
        // Implementing a singleton pattern to ensure only one instance of SaveManager exists
        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}

    }


    // Start is called before the first frame update


    public void SaveGame()
    {
        // Create an instance of the data to save
        PlayerInformation data = new PlayerInformation();
        data.PlayerName = playInfo.playerInfo.PlayerName;
        data.PlayerScore = playInfo.playerInfo.PlayerScore;
        for (int i = 0; i < areaDetails.areas.Count; i++)
        {
            // Ensure the data list has enough elements
            while (data.areas.Count <= i)
            {
                data.areas.Add(new AreaDetailList());
            }

            // Iterate through levels
            for (int j = 0; j < areaDetails.areas[i].levelLists.Count; j++)
            {
                // Ensure the data levelList has enough elements
                while (data.areas[i].levelList.Count <= j)
                {
                    data.areas[i].levelList.Add(new LevelList());
                }

                // Update values
                data.areas[i].levelList[j].isFinished = areaDetails.areas[i].levelLists[j].isFinished;
                data.areas[i].levelList[j].shardCount = areaDetails.areas[i].levelLists[j].shardCount;
            }
        }

        // Convert the data to a JSON string
        string jsonData = JsonUtility.ToJson(data);

        // Save the JSON string to PlayerPrefs
        PlayerPrefs.SetString("SaveData", jsonData);
        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        // Retrieve the JSON string from PlayerPrefs
        string jsonData = PlayerPrefs.GetString("SaveData", "");

        if (!string.IsNullOrEmpty(jsonData))
        {
            // Convert the JSON string back to an object
            PlayerInformation data = JsonUtility.FromJson<PlayerInformation>(jsonData);

            // Use the loaded data as needed
            playInfo.playerInfo.PlayerName = data.PlayerName;
            playInfo.playerInfo.PlayerScore = data.PlayerScore;

            for (int i = 0; i < areaDetails.areas.Count; i++)
            {
                for (int j = 0; j < areaDetails.areas[i].levelLists.Count; j++)
                {
                    areaDetails.areas[i].levelLists[j].shardCount = data.areas[i].levelList[j].shardCount;
                    areaDetails.areas[i].levelLists[j].isFinished = data.areas[i].levelList[j].isFinished;
                }
            }

            Debug.Log("Game loaded successfully.");
        }
        else
        {
            Debug.Log("No saved data found.");
        }
    }

    public void DeleteGame()
    {
        PlayerPrefs.DeleteKey("SaveData");
        ResetGameData();

    }

    public void ResetGameData()
    {
        // Reset the player info
        playInfo.playerInfo.PlayerName = ""; // Set to default or empty string
        playInfo.playerInfo.PlayerScore = 0;  // Set to default or starting score

        // Reset areaDetails data
        for (int i = 0; i < areaDetails.areas.Count; i++)
        {
            for (int j = 0; j < areaDetails.areas[i].levelLists.Count; j++)
            {
                areaDetails.areas[i].levelLists[j].shardCount = 0;         // Reset shard count to 0
                areaDetails.areas[i].levelLists[j].isFinished = false;    // Reset isFinished to false
            }
        }

        // Optionally, you can clear PlayerPrefs data here if needed
        // PlayerPrefs.DeleteAll();

        Debug.Log("Game data reset successfully.");
    }



    public bool CheckData()
    {
       
        string jsonData = PlayerPrefs.GetString("SaveData", "");

        if (string.IsNullOrEmpty(jsonData))
        {
            Debug.Log("No saved data found.");
            return false;
        }

        PlayerInformation data = JsonUtility.FromJson<PlayerInformation>(jsonData);

        if (data == null)
        {
            Debug.LogWarning("Loaded data is null.");
            return false;
        }

        // Return true if the conditions are met
        return true;
    }

}