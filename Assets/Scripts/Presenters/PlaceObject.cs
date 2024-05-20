using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObject : MonoBehaviour
{
    #region Variable
    private PlaceObjectUI placeObjectUI;
    private Photo360UI photo360Controller;

    private const float degreesLongitudeInMetersAtEquator = 111319.9f;
    private const float degreesLatitudeInMeters = 111132f;

    private readonly List<float> offsetSideValues = new List<float> { -1.5f, 0f, 1.5f };

    public List<GameObject> cubes = new List<GameObject>();

    public int currentColorIndex = 0;

    public delegate void FuntionStateCubes(bool state);
    public static FuntionStateCubes funtionStateCubes;
    #endregion

    #region Monobehaviour Methods
    private void Awake()
    {
        placeObjectUI = GetComponent<PlaceObjectUI>();
        photo360Controller = GetComponent<Photo360UI>();
    }

    public void Start()
    {
        StartCoroutine(InitExperience());
    }

    private void OnEnable()
    {
        funtionStateCubes += SetStateCubes;
    }

    private void OnDisable()
    {
        funtionStateCubes -= SetStateCubes;
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// Start the instantiation of objects with a small delay 
    /// to allow time for loading and maximizing GPS adjustment
    /// </summary>
    public IEnumerator InitExperience()
    {
        yield return new WaitForSeconds(1);

        foreach (var offsetSide in offsetSideValues)
        {
            PlaceARObject(offsetSide);
        }
    }

    /// <summary>
    /// Update the state of the cubes to hide or unhide them
    /// </summary>
    public void SetStateCubes(bool state)
    {
        foreach (var item in cubes)
        {
            item.SetActive(state);
        }
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// Instantiate de object in RA with an offset so that each cube is in a different position
    /// </summary>
    private void PlaceARObject(float offsetSide)
    {
        Vector3 positionObj = CalculatePosition(offsetSide);

        GameObject cube = InstantiateObject(positionObj);

        ApplyPropierties(cube);

        cubes.Add(cube);
    }

    /// <summary>
    /// Calculate the GPS coordinates into Unity units
    /// </summary>
    private Vector3 CalculatePosition(float offsetSide)
    {
        var latOffset = (GPSService.instance.latitude - GPSService.instance.latitude) * degreesLatitudeInMeters;
        var lonOffset = (GPSService.instance.longitude - GPSService.instance.longitude) * GetLongitudeDegreeDistance(GPSService.instance.latitude);
        var offsetFordward = 3f;
        var offsetFloor = -1f;

        return new Vector3(latOffset + offsetSide, offsetFloor, lonOffset + offsetFordward);
    }

    /// <summary>
    /// Transform the GPS coordinates into Unity units
    /// </summary>
    private float GetLongitudeDegreeDistance(float latitude)
    {
        return degreesLongitudeInMetersAtEquator * Mathf.Cos(latitude * (Mathf.PI / 180));
    }

    /// <summary>
    /// Add the unity position 
    /// </summary>
    private GameObject InstantiateObject(Vector3 position)
    {
        return Instantiate(placeObjectUI.obj, position, Quaternion.identity);
    }

    /// <summary>
    /// Adding properties to each cube.
    /// </summary>
    private void ApplyPropierties(GameObject cube)
    {
        Renderer renderer = cube.GetComponent<Renderer>();
        renderer.material.color = cube.GetComponent<CubeController>().GetNextColor(currentColorIndex);

        cube.GetComponent<CubeController>().cubeUI.material = photo360Controller.GetNextMaterial(currentColorIndex);

        cube.GetComponent<CubeController>().GetNextName(currentColorIndex);

        currentColorIndex++;

        cube.GetComponent<CubeController>().photo360Controller = photo360Controller;
    }
    #endregion
}
