
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;

public class SolarSystemController : MonoBehaviour
{
    [SerializeField]
    private Camera arCamera;
    public Button[] planetButtons;  // Array of buttons representing the planets
    public Transform sun;           // Reference to the sun transform
    public GameObject[] planets;    // Array of planet objects
    public GameObject HomePanel;
    public GameObject Panel;

    public Button ExitButton;

    public Canvas[] canvases;       // Array of canvases corresponding to the buttons

    private Vector3[] originalPlanetPositions;  // Array to store the original positions of the planets

    private void Start()
    {
        // Store the original positions of the planets
        originalPlanetPositions = new Vector3[planets.Length];
        for (int i = 0; i < planets.Length; i++)
        {
            originalPlanetPositions[i] = planets[i].transform.position;
        }

        // Add button click listeners
        foreach (Button button in planetButtons)
        {
            button.onClick.AddListener(() => OnPlanetButtonClick(button));
        }
        
    }

public void OnPlanetButtonClick(Button button)
{
    int buttonIndex = System.Array.IndexOf(planetButtons, button);

    // Store the original scales of all planets
    Vector3[] originalScales = new Vector3[planets.Length];
    for (int i = 0; i < planets.Length; i++)
    {
        originalScales[i] = planets[i].transform.localScale;
    }

    // Shrink all planets to zero scale
    foreach (Transform planetTransform in planets.Select(p => p.transform))
    {
        planetTransform.DOScale(Vector3.zero, 1f);
    }

    // Move the clicked planet to the position of the sun
    Transform planetToMove = planets[buttonIndex].transform;

    planetToMove.DOMove(sun.position, 1f).OnComplete(() =>
    {
        // Scale back all planets to their original sizes
        for (int i = 0; i < planets.Length; i++)
        {
            Transform planetTransform = planets[i].transform;
            planetTransform.DOScale(originalScales[0], 1f);
        }

        // Disable all other planets except the clicked one
        foreach (GameObject planet in planets)
        {
            if (planet != planetToMove.gameObject)
            {
                planet.gameObject.SetActive(false);
            }
        }

        // Call the custom function "LoadCanvas" with the button index
        LoadCanvas(buttonIndex);
    });
}


    private void LoadCanvas(int buttonIndex)
    {
        ExitButton.gameObject.SetActive(false);
        HomePanel.SetActive(false);
        Panel.SetActive(true);
        // Disable all canvases
        foreach (Canvas canvas in canvases)
        {
            canvas.gameObject.SetActive(false);
        }

        // Enable the canvas corresponding to the button index
        if (buttonIndex >= 0 && buttonIndex < canvases.Length)
        {
            canvases[buttonIndex].gameObject.SetActive(true);
            Button[] Canvasbuttons = canvases[buttonIndex].gameObject.GetComponentsInChildren<Button>(true);
            foreach (Button button in Canvasbuttons)
            {
                button.interactable = true;
            }
            transform.LookAt(transform.position + arCamera.transform.rotation * Vector3.forward,
                     arCamera.transform.rotation * Vector3.up);

            // Attach the CanvasFacingCamera script to the canvas
            CanvasFacingCamera canvasFacingCamera = canvases[buttonIndex].gameObject.GetComponent<CanvasFacingCamera>();
            if (canvasFacingCamera == null)
            {
                canvasFacingCamera = canvases[buttonIndex].gameObject.AddComponent<CanvasFacingCamera>();
            }

            // Set the AR camera as the target for the canvas to face
            canvasFacingCamera.SetTarget(arCamera.transform);

        }
        
    }
   
}
