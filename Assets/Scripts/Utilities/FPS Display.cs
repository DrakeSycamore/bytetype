using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPSDisplay : MonoBehaviour
{
    public TMP_Text fpsText;
    public float deltaTime;
    InputDetector inputDetector;
    void Start()
    {
        inputDetector = GetComponent<InputDetector>();
    }
    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = "FPS: " + Mathf.Ceil(fps).ToString() + "\nBase Score: " + inputDetector.baseScore ;
    }

}
