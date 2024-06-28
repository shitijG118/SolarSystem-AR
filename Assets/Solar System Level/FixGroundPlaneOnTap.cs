using UnityEngine;
using Vuforia;

public class FixGroundPlaneOnTap : MonoBehaviour
{
    private bool objectPlaced = false;
    [SerializeField]
    private GameObject plane;
    private Vector3 groundPlanePosition;

    private void Start()
    {
        groundPlanePosition = plane.transform.position;
    }

    public void OnInteractiveHitTest(HitTestResult result)
    {
        if (!objectPlaced)
        {
            objectPlaced = true;
            plane.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (objectPlaced)
        {
            plane.transform.position = groundPlanePosition;
        }
    }
}
