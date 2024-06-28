using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EarthButtonScript : MonoBehaviour
{
    [SerializeField]
    private Camera arCamera;
    public Canvas toDisable;
    public Canvas toEnablePlanet;
    // This function will be called when the button is clicked
    public void OnClick()
    {
       toDisable.gameObject.SetActive(false);
        toEnablePlanet.gameObject.SetActive(true);
            transform.LookAt(transform.position + arCamera.transform.rotation * Vector3.forward,
                     arCamera.transform.rotation * Vector3.up);

            // Attach the CanvasFacingCamera script to the canvas
            CanvasFacingCamera canvasFacingCamera = toEnablePlanet.gameObject.GetComponent<CanvasFacingCamera>();
            if (canvasFacingCamera == null)
            {
                canvasFacingCamera = toEnablePlanet.gameObject.AddComponent<CanvasFacingCamera>();
            }

            // Set the AR camera as the target for the canvas to face
            canvasFacingCamera.SetTarget(arCamera.transform);
    }
    
}
