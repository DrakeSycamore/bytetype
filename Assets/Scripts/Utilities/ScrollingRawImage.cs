using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingRawImage : MonoBehaviour
{
    [SerializeField] private RawImage scrollableImage;
    [SerializeField] private float x, y, scale, speed;
    [SerializeField] private float SinIntensityX, SinIntensityY, frequencyX, frequencyY;
    [SerializeField] private bool OscX, OscY;
   private float toX, toY;
    // Update is called once per frame
    void LateUpdate()
    {

        if (OscX && !OscY)
        {
            OscToX();
        }
        else if (!OscX && OscY)
        {
            OscToY();
        }
        else if (OscX && OscY)
        {
            OscBoth();
            
        }
        else
        {
            OscReset();
        }

     


        scrollableImage.uvRect = new Rect(scrollableImage.uvRect.position.x + toX + x * Time.deltaTime , scrollableImage.uvRect.position.y + toY + y * Time.deltaTime, Screen.width/ scale, Screen.height/ scale);

    }

    private void OscToX()
    {   
        float sinVal = Mathf.Sin(frequencyX * Time.time * speed);
       
        toX = (sinVal - SinIntensityX/2) * SinIntensityX * speed;
        toY = 0;
    }

    private void OscToY()
    {
        float sinVal = Mathf.Sin(frequencyY * Time.time * speed);
        
        toY = (sinVal - SinIntensityY / 2) * SinIntensityY * speed;
        toX = 0;
    }

    private void OscBoth()
    {
        float sinValX = Mathf.Sin(frequencyX * Time.time * speed);
        
        toX = (sinValX - SinIntensityX / 2) * SinIntensityX * speed;
        float sinValY = Mathf.Cos(frequencyY * Time.time * speed);
        
        toY = (sinValY - SinIntensityY / 2) * SinIntensityY * speed;
    }

    private void OscReset()
    {
        toX = 0;
        toY = 0;
    }

}
