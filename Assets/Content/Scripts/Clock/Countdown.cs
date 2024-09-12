using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public float TimeLeft = 60f; 
    public bool TimerOn = false;

    public Text TimerTxt;

    private bool isBlinking = false;

    // Start is called before the first frame update
    public void LaunchTimer()
    {
        TimerOn = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (TimerOn)
        {
            // Get pour mettre condition
            if (GameManager.Instance != null && GameManager.Instance.WinnerType != GameManager.WINNER_TYPE.NONE)
            {
                TimerOn = false;
            }

            
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);

                
                if (TimeLeft <= 45 && TimeLeft > 44 && !isBlinking)
                {
                    StartCoroutine(BlinkText(2, 0.5f));  
                }
                else if (TimeLeft <= 30 && TimeLeft > 29 && !isBlinking)
                {
                    StartCoroutine(BlinkText(2, 0.5f));
                }
                else if (TimeLeft <= 10 && !isBlinking)
                {
                    StartCoroutine(BlinkUntilEnd(0.2f));  
                }
            }
            else if (TimeLeft <= 0 && TimerOn)  
            {
                Debug.Log("Time is UP !");
                if (GameManager.Instance != null)
                    GameManager.Instance.PreyWins();
                TimeLeft = 0;
                TimerOn = false;
            }
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1; 
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    IEnumerator BlinkText(int blinkCount, float blinkSpeed)
    {
        isBlinking = true;
        for (int i = 0; i < blinkCount; i++)
        {
            yield return FadeText(0, blinkSpeed);

            yield return FadeText(1, blinkSpeed);
        }
        isBlinking = false;
    }

    IEnumerator BlinkUntilEnd(float blinkSpeed)
    {
        isBlinking = true;
        while (TimeLeft > 0)
        {   
            yield return FadeText(0, blinkSpeed);
            
            yield return FadeText(1, blinkSpeed);
        }
        isBlinking = false;
    }

    IEnumerator FadeText(float targetAlpha, float duration)
    {
        Color originalColor = TimerTxt.color;
        float startAlpha = TimerTxt.color.a;
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, time / duration);
            TimerTxt.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        TimerTxt.color = new Color(originalColor.r, originalColor.g, originalColor.b, targetAlpha);
    }
}
