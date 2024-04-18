using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScreenResolution : MonoBehaviour
{
    public RectTransform background;
    public float zoomOffset = 1;
    private void Awake()
    {
        RectTransform background = GetComponent<RectTransform>();

    }
    void Update()
    {   

        
        background.sizeDelta = new Vector3(Screen.width * zoomOffset, Screen.height * zoomOffset, this.background.anchoredPosition3D.z);
    }
}
