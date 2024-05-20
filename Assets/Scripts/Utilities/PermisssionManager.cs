using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class PermisssionManager : MonoBehaviour
{
    #region MonoBehaviour Methods
    // Start is called before the first frame update
    void Start()
    {
        RequestLocationPermission();
    }
    #endregion

    #region Private Methods
    /// <summary>
    ///  Request location permission at runtime.
    /// </summary>
    private void RequestLocationPermission()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }
    }
    #endregion
}
