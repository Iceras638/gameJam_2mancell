using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waveManager : MonoBehaviour
{
    public float BulletSpeed,
        EnemySpawnInterval, EnemySpawnIntervalDown,
        EnemySpeed, EnemySpeedUp,
        GroundTime, GroundTimeDown,
        SpeedUpTime;
    float second,speedlv;
    [SerializeField]
    GameObject speedLv = null;
    // Start is called before the first frame update
    void Start()
    {
        speedlv = 1;
    }

    // Update is called once per frame
    void Update()
    {
        second += Time.deltaTime;
        if(second >= SpeedUpTime)
        {
            EnemySpawnInterval -= EnemySpawnIntervalDown;
            if(EnemySpawnInterval <=  0.1f)
            {
                EnemySpawnInterval = 0.1f;
            }
            EnemySpeed += EnemySpeedUp;
            GroundTime -= GroundTimeDown;
            if(GroundTime <= 0.5f)
            {
                GroundTime = 0.5f;
            }
            speedlv++;

            Text speedLvText = speedLv.GetComponent<Text>();
            speedLvText.text = "Speed Lv:" + speedlv;
            second = 0;
        }


    }
}
