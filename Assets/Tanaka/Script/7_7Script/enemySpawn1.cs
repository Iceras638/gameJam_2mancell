﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemySpawn1 : MonoBehaviour
{
    public GameObject Uenemy,Renemy,Lenemy,Denemy;
    int number = 35;
    float second;
    public float intarval;
    GameObject waveObj;
    waveManager waveManage;
    public float killCount;
    public bool groundFlag;
    [SerializeField]
    GameObject slider;
    Slider coundGauge;
    public AudioClip cloud;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        waveObj = GameObject.Find("WaveManager");
        waveManage = waveObj.GetComponent<waveManager>();
        coundGauge = slider.GetComponent<Slider>();
        intarval = waveManage.EnemySpawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        coundGauge.value = killCount;
        groundFlag = false;
        if(killCount >= 10)
        {
            audioSource.PlayOneShot(cloud);

            groundFlag = true;
            killCount = 0;
        }

        second += Time.deltaTime;
        intarval = waveManage.EnemySpawnInterval;
        if(second >= intarval)
        {
            int rnd = Random.Range(0, number);

            switch(rnd)
            {
                case 1:
                    Instantiate(Uenemy, transform.position = new Vector3(-2.4f, 5.6f, 0), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(Uenemy, transform.position = new Vector3(-1.6f, 5.6f, 0), Quaternion.identity);
                    break;
                case 3:
                    Instantiate(Uenemy, transform.position = new Vector3(-0.8f, 5.6f, 0), Quaternion.identity);
                    break;
                case 4:
                    Instantiate(Uenemy, transform.position = new Vector3(0f, 5.6f, 0), Quaternion.identity);
                    break;
                case 5:
                    Instantiate(Uenemy, transform.position = new Vector3(0.8f, 5.6f, 0), Quaternion.identity);
                    break;
                case 6:
                    Instantiate(Uenemy, transform.position = new Vector3(1.6f, 5.6f, 0), Quaternion.identity);
                    break;
                case 7:
                    Instantiate(Uenemy, transform.position = new Vector3(2.4f, 5.6f, 0), Quaternion.identity);
                    break;
                case 8:
                    Instantiate(Renemy, transform.position = new Vector3(5.6f, 2.4f, 0), Quaternion.identity);
                    break;
                case 9:
                    Instantiate(Renemy, transform.position = new Vector3(5.6f, 1.6f, 0), Quaternion.identity);
                    break;
                case 10:
                    Instantiate(Renemy, transform.position = new Vector3(5.6f, 0.8f, 0), Quaternion.identity);
                    break;
                case 11:
                    Instantiate(Renemy, transform.position = new Vector3(5.6f, 0, 0), Quaternion.identity);
                    break;
                case 12:
                    Instantiate(Renemy, transform.position = new Vector3(5.6f, -0.8f, 0), Quaternion.identity);
                    break;
                case 13:
                    Instantiate(Renemy, transform.position = new Vector3(5.6f, -1.6f, 0), Quaternion.identity);
                    break;
                case 14:
                    Instantiate(Renemy, transform.position = new Vector3(5.6f, -2.4f, 0), Quaternion.identity);
                    break;
                case 15:
                    Instantiate(Lenemy, transform.position = new Vector3(-5.6f, 2.4f, 0), Quaternion.identity);
                    break;
                case 16:
                    Instantiate(Lenemy, transform.position = new Vector3(-5.6f, 1.6f, 0), Quaternion.identity);
                    break;
                case 17:
                    Instantiate(Lenemy, transform.position = new Vector3(-5.6f, 0.8f, 0), Quaternion.identity);
                    break;
                case 18:
                    Instantiate(Lenemy, transform.position = new Vector3(-5.6f, 0, 0), Quaternion.identity);
                    break;
                case 19:
                    Instantiate(Lenemy, transform.position = new Vector3(-5.6f, -0.8f, 0), Quaternion.identity);
                    break;
                case 20:
                    Instantiate(Lenemy, transform.position = new Vector3(-5.6f, -1.6f, 0), Quaternion.identity);
                    break;
                case 21:
                    Instantiate(Lenemy, transform.position = new Vector3(-5.6f, -2.4f, 0), Quaternion.identity);
                    break;
                case 22:
                    Instantiate(Denemy, transform.position = new Vector3(-2.4f, -5.6f, 0), Quaternion.identity);
                    break;
                case 23:
                    Instantiate(Denemy, transform.position = new Vector3(-1.6f, -5.6f, 0), Quaternion.identity);
                    break;
                case 24:
                    Instantiate(Denemy, transform.position = new Vector3(-0.8f, -5.6f, 0), Quaternion.identity);
                    break;
                case 25:
                    Instantiate(Denemy, transform.position = new Vector3(0, -5.6f, 0), Quaternion.identity);
                    break;
                case 26:
                    Instantiate(Denemy, transform.position = new Vector3(0.8f, -5.6f, 0), Quaternion.identity);
                    break;
                case 27:
                    Instantiate(Denemy, transform.position = new Vector3(1.6f, -5.6f, 0), Quaternion.identity);
                    break;
                case 28:
                    Instantiate(Denemy, transform.position = new Vector3(2.4f, -5.6f, 0), Quaternion.identity);
                    break;

            }
            second = 0;
        }
       
    }
}