using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; 

public class TimerCountdown : MonoBehaviour
{

    //start time value
    [SerializeField] float startTime;

    //current time 
    float currentTime;

    //float currentScore = 0;

    bool timerStarted = false;

    [SerializeField] TMP_Text timerText;


    //IEnumerator TimerTake()
    //{
    //    takingAway = true; 

    //}

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
        timerStarted = true;
        timerText.text = currentTime.ToString();
        //scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStarted)
        {
            //subtracting the previous frames duration 
            currentTime -= Time.deltaTime; 

            if(currentTime <= 0)
            {

                Debug.Log("timer reached zero");
                ChangeScene();

                timerStarted = false;
                currentTime = 0; 
            }

            timerText.text = currentTime.ToString("f1");
            //scoreText.text = currentScore.ToString("f0");
        }
    }

        public void ChangeScene()
    {
        //Debug.Log("Scene Changed");
        SceneManager.LoadScene("UI"); 
    }

}
