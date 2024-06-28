using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButtonScript : MonoBehaviour
{
     // This function will be called when the button is clicked
    public void OnButtonClick()
    {
       SceneManager.LoadScene("SolarSystemScene");
    }
}
