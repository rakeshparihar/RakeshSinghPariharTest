using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ResultScreen : IBaseUI 
{
    [SerializeField] private Text ResultScoreText;
    [SerializeField] private Text BonusText;

    //Private
    AsyncOperation asyncOperation;
    LoadingController loadingController;

    private void Awake()
    {
        loadingController = FindObjectOfType<LoadingController>();
    }
    public override void Show()
    {
        base.Show();
    }

    public void DisplayFinalScore(int totalScore, int totalTime)
    {
        Show();
        ResultScoreText.text = string.Format("Total Score : {0} \n Total Time : {1} ", totalScore, totalTime);
        BonusText.text = string.Format("Bonus Point : {0} ", totalTime);
    }

    public void OnMainMenuButton()
    {
        StartCoroutine("LoadNextScene");
    }

    IEnumerator LoadNextScene()
    {
        yield return null;
        asyncOperation = SceneManager.LoadSceneAsync("MainScene");
        asyncOperation.allowSceneActivation = false;
        loadingController.loadingText.text = "Loading Progress : " + (asyncOperation.progress * 100) + "%";
        while (!asyncOperation.isDone)
        {
            if (asyncOperation.progress >= 0.89f)
            {
                asyncOperation.allowSceneActivation = true;
                loadingController.Hide();
            }
            yield return null;
        }
    }
}
