using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public GameObject AllData;
    private static DontDestroy instance;

    // Start is called before the first frame update
    void Awake()
    {
        // Check if an instance of the script already exists
        if (instance == null)
        {
            // If not, set the instance to this script and mark the GameObject as persistent
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this GameObject
            Destroy(gameObject);
        }
    }
}

