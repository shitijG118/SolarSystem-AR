using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VenusButtonScript : MonoBehaviour
{
    public Canvas mainCanvas;
    public Canvas VenusCanvas;
    
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
        VenusCanvas.gameObject.SetActive(true);

        // Set Canvas to inactive
        //mainCanvas.gameObject.SetActive(false);
        
    }
    
}
