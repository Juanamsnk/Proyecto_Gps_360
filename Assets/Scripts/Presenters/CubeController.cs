using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeController : MonoBehaviour
{
    #region Variables
    public Cube cube = new Cube();

    public CubeControllerUI cubeUI;
    public Photo360UI photo360Controller;
    #endregion

    #region MonoBehaviour Methods

    private void Awake()
    {
        cubeUI = GetComponent<CubeControllerUI>();
    }
    public void Start()
    {
        cubeUI.button360.onClick.AddListener(SelectCube);
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// Obtain the following color for our cubes.
    /// </summary>
    public Color GetNextColor(int index)
    {
        Color color = cube.colors[index];
        return color;
    }

    /// <summary>
    /// Obtain the following name for our cubes.
    /// </summary>
    public void GetNextName(int index)
    {
        string name = cube.names[index];

        cubeUI.ChangeName(name);
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// Change the material of our 3D sphere.
    /// </summary>
    private void SetTextureSphere()
    {
        Renderer rendererTexture = photo360Controller.Sphere.GetComponent<Renderer>();
        cubeUI.ChangeMaterial(rendererTexture);
    }

    /// <summary>
    /// Select the cube 
    /// </summary>
    private void SelectCube()
    {
        photo360Controller.ActiveSphere();

        photo360Controller.buttonClosePhoto.gameObject.SetActive(true);

        SetTextureSphere();

        PlaceObject.funtionStateCubes?.Invoke(false);
    }
    #endregion
}
