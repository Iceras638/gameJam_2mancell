using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultTime : MonoBehaviour
{
    public GameObject time;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Text timeText = time.GetComponent<Text>();
        timeText.text = Timer.Minute.ToString("00") + ":" + ((int)Timer.Seconds).ToString("00");
    }
}
