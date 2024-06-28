using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SolarLevelBackControlHome : MonoBehaviour
{
    // Update is called once per frame
    public void OnButtonClick()
    {
        SceneManager.LoadScene("SolarSystemScene");
    }
}
