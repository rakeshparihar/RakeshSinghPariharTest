using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]private HUD hud;
    [SerializeField]private ResultScreen result;

    //Public 
    public int GameTimeInSec = 60;
    public int TotalItemToCollect = 10;

    //Private
    private int collectCounter = 0;
    private int mScore;
    float bonusPoint;
    public void UpdateScore(int score, int streakMultipler)
    {
        mScore = score;
        collectCounter++;
        hud.UpdateScore(mScore, streakMultipler);
        UpdateBestScore(mScore);
    }

    private void UpdateBestScore(int bestScore)
    {
        if(PersistentStorage.LoadData() < bestScore)
        {
            PersistentStorage.SaveData(bestScore);
        }
    }

    private void Start()
    {       
        StartCoroutine(StartGameTimer());
    }

    IEnumerator StartGameTimer()
    {
        float gameTime = GameTimeInSec;
      
        while (gameTime > 0f && collectCounter < TotalItemToCollect)
        {
            gameTime -= Time.deltaTime;
            yield return null;

            hud.UpdateTimer((int)gameTime);
        }
        bonusPoint = GameTimeInSec - gameTime;
        result.DisplayFinalScore(mScore, (int)gameTime);
        UpdateScore(mScore+(int)gameTime, 1);
    }

}
