using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GPSService : MonoBehaviour
{
    #region Variables
    public float latitude;
    public float longitude;
    public float altitude;

    public static GPSService instance;
    #endregion

    #region MonoBehaviour Methods

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
        }
    }
    void Start()
    {
        StartCoroutine(InitGPSService());
    }
    #endregion

    #region Public Methods
    public IEnumerator InitGPSService()
    {

        // First, make sure the user has allowed access to location.
        if (!Input.location.isEnabledByUser)
        {
            yield break;
        }

        // Start the location service.
        Input.location.Start();

        // Wait until the location service starts.
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service did not start within the expected time.
        if (maxWait <= 0)
        {
            yield break;
        }

        // Location service failed.
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            yield break;
        }
        else
        {
            // Success, now we can get the location.
            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;
            altitude = Input.location.lastData.altitude;
        }
    }

    public IEnumerator StopLocationService()
    {
        // Stop the location service.
        Input.location.Stop();

        yield break;
    }
    #endregion
}
