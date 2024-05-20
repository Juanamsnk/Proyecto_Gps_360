using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public interface ISceneLoader
{
    void LoadScene(SceneID sceneID);
}

public enum SceneID
{
    SplashScene,
    TutorialScene,
    MainScene,
}

public class SceneLoader : MonoBehaviour, ISceneLoader
{
    #region Variables
    private SceneID sceneToLoad = SceneID.TutorialScene;
    private float delayBeforeLoading = 2f;
    #endregion

    #region MonoBehaviour Methods
    private void Start()
    {
        StartCoroutine(LoadSceneAfterDelay());
    }
    #endregion

    #region Public Methods
    public void LoadScene(SceneID sceneID)
    {
        SceneManager.LoadScene(sceneID.ToString());
    }
    #endregion

    #region Private Methods
    private IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeLoading);
        LoadScene(sceneToLoad);
    }
    #endregion
}
