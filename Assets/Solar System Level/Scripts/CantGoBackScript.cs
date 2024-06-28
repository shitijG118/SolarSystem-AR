using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CantGoBackScript : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
     if (Input.GetKeyDown (KeyCode.Escape))
			Debug.Log("You can't go back at this stage");   
    }
}
