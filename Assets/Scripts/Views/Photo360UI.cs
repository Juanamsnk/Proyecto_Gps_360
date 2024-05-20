using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Photo360UI : MonoBehaviour
{
    #region Variables
    public GameObject Sphere;
    public Button buttonClosePhoto;
    public List<Material> materials = new List<Material>();
    #endregion

    #region MonoBehaviour Methods
    public void Start()
    {
        buttonClosePhoto.onClick.AddListener(ClosePhoto360);
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// Active the Sphere 360
    /// </summary>
    public void ActiveSphere()
    {
        Sphere.SetActive(true);
    }

    /// <summary>
    /// Desactive the Sphere 360 
    /// </summary>
    public void ClosePhoto360()
    {
        Sphere.SetActive(false);
        buttonClosePhoto.gameObject.SetActive(false);
        PlaceObject.funtionStateCubes?.Invoke(true);
    }

    /// <summary>
    /// Obtain the next SphereMaterial
    /// </summary>
    public Material GetNextMaterial(int index)
    {
        Material material = materials[index];
        return material;
    }
    #endregion
}
