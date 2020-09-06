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
    float second;
    [SerializeField]
    Text speedLv;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        second += Time.deltaTime;
        if(second >= SpeedUpTime)
        {
            EnemySpawnInterval -= EnemySpawnIntervalDown;
            EnemySpeed += EnemySpeedUp;
            GroundTime -= GroundTimeDown;
            second = 0;
        }
    }
}
