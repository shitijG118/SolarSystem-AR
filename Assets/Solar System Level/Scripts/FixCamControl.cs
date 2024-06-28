using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;

public class FixCamControl : MonoBehaviour
{
    [SerializeField]
    private Camera arCamera;
    public Canvas MainMcqCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            MainMcqCanvas.gameObject.SetActive(true);
            transform.LookAt(transform.position + arCamera.transform.rotation * Vector3.forward,
                     arCamera.transform.rotation * Vector3.up);

            // Attach the CanvasFacingCamera script to the canvas
            CanvasFacingCamera canvasFacingCamera = MainMcqCanvas.gameObject.GetComponent<CanvasFacingCamera>();
            if (canvasFacingCamera == null)
            {
                canvasFacingCamera = MainMcqCanvas.gameObject.AddComponent<CanvasFacingCamera>();
            }

            // Set the AR camera as the target for the canvas to face
            canvasFacingCamera.SetTarget(arCamera.transform);
    }
}
