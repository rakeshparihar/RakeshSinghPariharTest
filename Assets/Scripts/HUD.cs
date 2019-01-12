using UnityEngine;
using UnityEngine.UI;

public class HUD : IBaseUI 
{
    [SerializeField] private Text ScoreText;
    [SerializeField] private Text TimerText;

    private void Start()
    {
        ScoreText.text = string.Format("Score : {0} \nStreak : {1}", 0,0);
    }

    public void UpdateScore(int score, int streak)
    {
        ScoreText.text = string.Format("Score : {0} \nStreak : {1}", score, streak);
    }

    public void UpdateTimer(int time)
    {
        TimerText.text = string.Format("Time Left : {0}", time);
    }
}
