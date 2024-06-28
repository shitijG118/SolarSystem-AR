using UnityEngine;

public class PlanetRoot : MonoBehaviour
{
    private Transform root;
    public Transform planet;
    public SolarSystem solarSystem;

    [SerializeField] private float rootRotateSpeed = 25f;
    [SerializeField] private float planetRotateSpeed = 25f;


    private void Start()
    {
        root = transform;
    }

    private void Update()
    {
        planet.Rotate(Vector3.up * planetRotateSpeed * Time.deltaTime, Space.Self);
        
        if (solarSystem.isZoomed == false)
            root.Rotate(Vector3.up * rootRotateSpeed * Time.deltaTime, Space.Self);
    }
}
