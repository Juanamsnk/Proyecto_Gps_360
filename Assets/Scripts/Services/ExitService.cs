using UnityEngine;

public class ExitService : MonoBehaviour
{
    #region MonoBehaviour Methods
    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android && Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    #endregion
}
