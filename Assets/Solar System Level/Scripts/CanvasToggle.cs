using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasToggle : MonoBehaviour
{
    [SerializeField]
    private Camera arCamera;
    public Canvas toDisable;
    public Canvas toEnablePlanet;
    public Canvas toEnableSS;

    // void Start(){
    //     toDisable.gameObject.SetActive(true);
    // }

    // Update is called once per frame
    private void OnEnable()
    {
        // Your script logic here
        Debug.Log("Canvas is enabled! Script is running.");
        Button[] buttons = toDisable.GetComponentsInChildren<Button>(true);
        foreach (Button button in buttons)
        {
            button.interactable = true;
        }
    }
    public void onClickPlanetQuiz()
    {
        Debug.Log("Button Clicked");
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
    public void onClickSSQuiz()
    {
        Debug.Log("Button Clicked");
        toDisable.gameObject.SetActive(false);
        toEnableSS.gameObject.SetActive(true);
            transform.LookAt(transform.position + arCamera.transform.rotation * Vector3.forward,
                     arCamera.transform.rotation * Vector3.up);

            // Attach the CanvasFacingCamera script to the canvas
            CanvasFacingCamera canvasFacingCamera = toEnableSS.gameObject.GetComponent<CanvasFacingCamera>();
            if (canvasFacingCamera == null)
            {
                canvasFacingCamera = toEnableSS.gameObject.AddComponent<CanvasFacingCamera>();
            }

            // Set the AR camera as the target for the canvas to face
            canvasFacingCamera.SetTarget(arCamera.transform);
    }
}
