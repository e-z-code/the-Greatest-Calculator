using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimecountRanking : MonoBehaviour
{
    AudioSource audioSource;/////////////소리

    public float countdownSeconds = 60;
    private TextMeshProUGUI timeText;

    private bool timeend;
    private bool timeends;/////////////소리

    public GameObject stage;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();/////////////소리
        timeText = GetComponent<TextMeshProUGUI>();
        timeend = true;
        timeends = true;/////////////소리
    }

    void Update()
    {
        if(stage.GetComponent<RankingStage>().fortime == 1)
            countdownSeconds -= Time.deltaTime;

        var span = new TimeSpan(0, 0, (int)countdownSeconds);
        timeText.text = span.ToString(@"mm\:ss");
        if (timeend == true){
            if (countdownSeconds <= 0) //시간 초과 fail
            {
                Stagetimeout();
                Invoke("End", 5f);
                timeend = false;
            }
        }
        if (timeends == true){/////////////소리
            if (countdownSeconds <= 6) 
            {
               audioSource.Play();
               timeends = false;
            }
        }
    }
    void Stagetimeout()
    {
        GameObject.Find("Stage").GetComponent<RankingStage>().stage = 3;
        GameObject.Find("Stage").GetComponent<RankingStage>().stagemove = false;
        stage.GetComponent<RankingStage>().TimeOut();
    }

    void End()
    {
        //SceneManager.LoadScene("Stagehome");
    }
}