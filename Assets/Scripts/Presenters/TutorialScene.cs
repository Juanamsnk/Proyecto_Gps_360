using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScene : MonoBehaviour
{
    #region Variables
    public TutorialSceneUI tutorialSceneUI;
    #endregion

    #region MonoBehaviour Methods
    private void Awake()
    {
        tutorialSceneUI = GetComponent<TutorialSceneUI>();
    }
    void Start()
    {
        tutorialSceneUI.InitButton.onClick.AddListener(ChangeScene);
    }
    #endregion

    #region Public Methods
    public void ChangeScene()
    {
        SceneID sceneToLoad = SceneID.MainScene;

        SceneManager.LoadScene(sceneToLoad.ToString());
    }
    #endregion
}
