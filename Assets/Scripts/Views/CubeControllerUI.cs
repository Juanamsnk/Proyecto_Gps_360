using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CubeControllerUI : MonoBehaviour
{
    #region Variables
    public Material material;
    public Button button360;
    public TextMeshProUGUI nameText;
    #endregion


    #region Public Methods
    public void ChangeMaterial(Renderer renderer)
    {
        renderer.material = material;
    }

    public void ChangeName(string name)
    {
        nameText.text = name;
    }
        #endregion
    }
