using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
public class MainMenuController : IBaseUI
{
    private LoadingController loadingController; 
    AsyncOperation asyncOperation;

    [SerializeField] private Text bestScore;

    private void Awake()
    {
        loadingController = FindObjectOfType<LoadingController>();
        Show();
    }
    public override void Show()
    {
        base.Show();
        bestScore.text = "Best Score : "+ Convert.ToString(PersistentStorage.LoadData()) ;
    }

    public override void Hide()
    {
        base.Hide();
    }

    public void OnPlayButtonClick()
    {
        Hide();
        loadingController.Show();
        StartCoroutine("LoadNextScene");        
    }

    IEnumerator LoadNextScene()
    {
        yield return null;
        asyncOperation = SceneManager.LoadSceneAsync("GameScene");
        asyncOperation.allowSceneActivation = false;
        loadingController.loadingText.text = "Loading Progress : "+(asyncOperation.progress * 100) + "%";
        while (!asyncOperation.isDone)
        {
            if (asyncOperation.progress >= 0.89f)
            {
                loadingController.loadingText.text = "Please Press Space Bar To Continue";
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    asyncOperation.allowSceneActivation = true;
                    loadingController.Hide();
                }               
            }
            yield return null;
        }      
    }
}
