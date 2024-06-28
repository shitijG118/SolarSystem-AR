using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FIxTextRotate : MonoBehaviour
{
    [SerializeField]
    private Camera arCamera;
    private TextMeshPro textMeshPro;

    // Start is called before the first frame update
    void Start()
    {
    arCamera = Camera.main;
    textMeshPro = GetComponent<TextMeshPro>();
    }


    // Update is called once per frame
    void LateUpdate()
    {
    transform.LookAt(transform.position + arCamera.transform.rotation * Vector3.forward,
                     arCamera.transform.rotation * Vector3.up);
    }

}
