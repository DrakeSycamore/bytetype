using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{

    public PlayerInfo playerInfo;
    // Start is called before the first frame update
    public void goToNewScene(string menuChoice)
    {
        SceneManager.LoadSceneAsync(menuChoice);
        CheckType(menuChoice);

    }
    private void CheckType(string type)
    {
        switch (type) 
        {
            case "AreaSelection":
                playerInfo.playerInfo.Area = -1;
                break;
            case "LevelSelection":
                playerInfo.playerInfo.Level = -1;
                break;
            case "CharacterSelection":
                playerInfo.playerInfo.CharacterIndex = -1;
                break;

        }

    }

}

