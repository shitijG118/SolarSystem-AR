using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SunButtonScript : MonoBehaviour
{
    public Canvas mainCanvas;
    public Canvas SunCanvas;
    // This function will be called when the button is clicked
    public void OnMouseDown()
    {
        Canvas[] canvases = FindObjectsOfType<Canvas>();

        // Disable all canvases
        foreach (Canvas canvas in canvases)
        {
            canvas.enabled = false;
        }
       // Set EarthCanvas to active
        SunCanvas.gameObject.SetActive(true);

        // Set Canvas to inactive
        //mainCanvas.gameObject.SetActive(false);
        
    }
    
}
