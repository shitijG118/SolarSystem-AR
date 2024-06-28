using UnityEngine;
using Vuforia;

public class FixGroundPlaneAnchor : MonoBehaviour
{
    private ObserverBehaviour observerBehaviour;
    private bool isAnchorFixed = false;

    private void Start()
    {
        observerBehaviour = GetComponent<ObserverBehaviour>();
    }

    public void FixAnchorOnClick()
    {
        if (!isAnchorFixed && observerBehaviour != null)
        {
            observerBehaviour.enabled = false;
            observerBehaviour.enabled = true;
            isAnchorFixed = true;
        }
    }
}
