﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public static float score;
    public GameObject scoreText = null;
    float second;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        second += Time.deltaTime;
        if(second >= 1)
        {
            score += 100;
            second = 0;
        }
        Text text = scoreText.GetComponent<Text>();
        text.text = ""+score;
    }
}
