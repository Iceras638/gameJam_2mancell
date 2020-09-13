using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove1 : MonoBehaviour
{
    public float speed,speed2;
    float second;
    bool stopFlag;
    [SerializeField]
    GameObject deadParticle,hitParticle;
    GameObject waveObj,spawnObj;
    waveManager waveManage;
    enemySpawn1 spawnManage;
    public AudioClip enemyDeadAudio;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        waveObj = GameObject.Find("WaveManager");
        waveManage = waveObj.GetComponent<waveManager>();
        spawnObj = GameObject.Find("EnemySpawn");
        spawnManage = spawnObj.GetComponent<enemySpawn1>();

        speed = waveManage.EnemySpeed;
        speed2 = waveManage.EnemySpeed;

        stopFlag = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(stopFlag == true)
        {
            second += Time.deltaTime;
            if(second >= 3)
            {
                speed = speed2;
                stopFlag = false;
                second = 0;
            }
        }
        else
        {
            speed = waveManage.EnemySpeed;
            speed2 = waveManage.EnemySpeed;

        }

        if (this.tag == "Uenemy")
        {
            transform.position += new Vector3(0, -speed);
        }
        if (this.tag == "Renemy")
        {
            transform.position += new Vector3(-speed, 0);

        }
        if (this.tag == "Lenemy")
        {
            transform.position += new Vector3(speed, 0);

        }
        if (this.tag == "Denemy")
        {
            transform.position += new Vector3(0, speed);

        }

        if(transform.position.x > 15 || transform.position.x < -15
            || transform.position.y > 15 || transform.position.y < -15)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet") 
        {
            audioSource.PlayOneShot(enemyDeadAudio);

            Instantiate(deadParticle, transform.position, Quaternion.identity);
            spawnManage.killCount++;
            scoreManager.score += 300;
            transform.position = new Vector3(10, 0, 0);
            stopFlag = true;
            //gameObject.SetActive(false);
            Destroy(gameObject,2);
        }
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(hitParticle, transform.position, Quaternion.identity);

            speed2 = speed;
            speed = 0;
            stopFlag = true;
        }
    }

}
