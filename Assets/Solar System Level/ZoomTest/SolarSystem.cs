using UnityEngine;
using DG.Tweening;

public class SolarSystem : MonoBehaviour
{
    const string TWEEN_ID = "solar_system_tween";

    public bool isZoomed = false;
    [SerializeField] private float zoomScale = 10f;
    [SerializeField] private PlanetRoot targetPlanetRoot;


    private void OnDestroy()
    {
        DOTween.Kill(TWEEN_ID);
    }


    private void Update()
    {
        // Zoom In
        if (Input.GetKeyDown(KeyCode.E))
        {
            isZoomed = !isZoomed;

            UpdateTransformsTween();
            // UpdateTransforms();
        }
    }


    private void UpdateTransformsTween()
    {
        if (isZoomed)
        {
            Vector3 targetPosition = transform.localPosition - (GetTargetPlanetOffset(targetPlanetRoot) * zoomScale);
            Vector3 targetScale = transform.localScale * zoomScale;

            transform.DOLocalMove(targetPosition, 1f).SetId(TWEEN_ID);
            transform.DOScale(targetScale, 1f).SetId(TWEEN_ID);
        }
        else
        {
            Vector3 targetPosition = Vector3.zero;
            Vector3 targetScale = Vector3.one;

            transform.DOLocalMove(targetPosition, 1f).SetId(TWEEN_ID);
            transform.DOScale(targetScale, 1f).SetId(TWEEN_ID);
        }
    }


    private void UpdateTransforms()
    {
        if (isZoomed)
        {
            transform.localPosition -= GetTargetPlanetOffset(targetPlanetRoot) * zoomScale;
            transform.localScale *= zoomScale;
        }
        else
        {
            transform.localPosition = Vector3.zero;
            transform.localScale = Vector3.one;
        }
    }


    private Vector3 GetTargetPlanetOffset(PlanetRoot targetPlanetRoot)
    {
        // Use global positions
        Transform planet = targetPlanetRoot.planet;
        Vector3 offset = planet.transform.position - transform.position;
        return offset;
    }
}
