using UnityEngine;

public class CanvasFacingCamera : MonoBehaviour
{
    private Transform target;  // The target to face (the camera)

    public void SetTarget(Transform targetTransform)
    {
        target = targetTransform;
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            // Face the target (camera)
            transform.LookAt(target);
            transform.Rotate(0f, 180f, 0f);  // Flip the canvas to face the camera
        }
    }
}
