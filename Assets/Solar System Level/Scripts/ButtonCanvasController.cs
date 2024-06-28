using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCanvasController : MonoBehaviour
{
    [SerializeField]
    private Camera arCamera;
    public Button[] buttons;  // Array of buttons
    public Canvas[] canvases; // Array of canvases
    // Start is called before the first frame update
    void Start()
    {
        // Add button click listeners
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Store the current index value for the button click listener
            buttons[i].onClick.AddListener(() => EnableCanvas(index));
        }
    }
    public void EnableCanvas(int index)
    {
        // Disable all canvases
        foreach (Canvas canvas in canvases)
        {
            canvas.gameObject.SetActive(false);
        }

        // Enable the corresponding canvas based on the button index
        if (index >= 0 && index < canvases.Length)
        {
            canvases[index].gameObject.SetActive(true);
            transform.LookAt(transform.position + arCamera.transform.rotation * Vector3.forward,
                     arCamera.transform.rotation * Vector3.up);

            // Attach the CanvasFacingCamera script to the canvas
            CanvasFacingCamera canvasFacingCamera = canvases[index].gameObject.GetComponent<CanvasFacingCamera>();
            if (canvasFacingCamera == null)
            {
                canvasFacingCamera = canvases[index].gameObject.AddComponent<CanvasFacingCamera>();
            }

            // Set the AR camera as the target for the canvas to face
            canvasFacingCamera.SetTarget(arCamera.transform);
        }
    }

    
}
