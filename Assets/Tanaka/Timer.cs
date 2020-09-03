using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private int Minute;
    [SerializeField]
    private float Seconds;

    private float oldSeconds;
    private Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        Minute = 0;
        Seconds = 0f;
        //microSeconds = 0f;
        oldSeconds = 0f;
        timerText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Seconds += Time.deltaTime;
        if(Seconds>=60f)
        {
            Minute++;
            Seconds = Seconds - 60;
        }

        if((int)Seconds != (int)oldSeconds)
        {
            timerText.text = Minute.ToString("00") + ":" + ((int)Seconds).ToString("00");
        }
        oldSeconds = Seconds;
    }
}
