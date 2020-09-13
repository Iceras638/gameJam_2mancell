using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMove : MonoBehaviour
{
    Vector3 MOVEX = new Vector3(0.8f, 0, 0); // x軸方向に１マス移動するときの距離
    Vector3 MOVEY = new Vector3(0, 0.8f, 0); // y軸方向に１マス移動するときの距離

    float step = 5f;     // 移動速度
    Vector3 target;      // 入力受付時、移動後の位置を算出して保存 
    Vector3 prevPos;     // 何らかの理由で移動できなかった場合、元の位置に戻すため移動前の位置を保存

    public GameObject bullet;
    public float x, y;
    [SerializeField]
    float speed,second;
    int damage;
    bool knockbackFlag, shotFlag,deadFlag;

    GameObject ManageObject,waveObj;
    SceneFadeManager fadeManager;
    waveManager waveManage;

    Animator animator;   // アニメーション

    public AudioClip playerShotAudio,playerFallAudio,playerKnockbackAudio;
    private AudioSource audioSource;


    // Use this for initialization
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        ManageObject = GameObject.Find("ManagerObj");
        fadeManager = ManageObject.GetComponent<SceneFadeManager>();
        waveObj = GameObject.Find("WaveManager");
        waveManage=waveObj.GetComponent<waveManager>();

        speed = waveManage.BulletSpeed;

        damage = 1;
        target = transform.position;
        animator = GetComponent<Animator>();
        knockbackFlag = false;
        deadFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        speed = waveManage.BulletSpeed;
        if(knockbackFlag == true)
        {
            gameObject.tag = "UpPlayer";
        }
        if(knockbackFlag == false)
        {
            gameObject.tag = "Player";
        }

        // ① 移動中かどうかの判定。移動中でなければ入力を受付
        if (transform.position == target)
        {
            if(deadFlag==false)
            {
                knockbackFlag = false;
                SetTargetPosition();

            }
        }
        else
        {
            //gameObject.tag = "MovePlayer";
        }
        //if (deadFlag == true)
        //{
            //Debug.Log("aaa"); 
            //second += Time.deltaTime;
            //if (second > 2)
            //{
                //fadeManager.fadeOutStart(0, 0, 0, 0, "Result");
            //}
        //}

        Move();

    }

    // ② 入力に応じて移動後の位置を算出
    void SetTargetPosition()
    {
        prevPos = target;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            audioSource.clip = playerShotAudio;
            audioSource.Play();
            target = transform.position - MOVEX;
                Instantiate(bullet, transform.position, Quaternion.Euler(0,0,90));
            SetAnimationParam(1);
            x = speed;
            y = 0;
            return;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            audioSource.clip = playerShotAudio;
            audioSource.Play();

            target = transform.position + MOVEX;
                Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 90));
            SetAnimationParam(2);

            x = -speed;
            y = 0;

            return;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            audioSource.clip = playerShotAudio;
            audioSource.Play();

            target = transform.position - MOVEY;
                Instantiate(bullet, transform.position, Quaternion.identity);
            SetAnimationParam(3);

            x = 0;
            y = speed;

            return;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            audioSource.clip = playerShotAudio;
            audioSource.Play();

            target = transform.position + MOVEY;
                Instantiate(bullet, transform.position, Quaternion.identity);
            SetAnimationParam(0);

            x = 0;
            y = -speed;

            return;
        }
    }

    // WalkParam  0;下移動　1;右移動　2:左移動　3:上移動
    void SetAnimationParam(int param)
    {
        animator.SetInteger("WalkParam", param);
    }

    // ③ 目的地へ移動する
    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, step * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.gameObject.tag == "Player" || this.gameObject.tag == "MovePlayer") 
        {
            if (collision.gameObject.tag == "Uenemy")
            {
                audioSource.clip = playerKnockbackAudio;
                audioSource.Play();

                knockbackFlag = true;
                target = prevPos;
                if (transform.position == prevPos)
                {
                    SetAnimationParam(3);
                    target = transform.position - MOVEY * 10;
                }
                damage++;

            }
            if (collision.gameObject.tag == "Renemy")
            {
                audioSource.clip = playerKnockbackAudio;
                audioSource.Play();

                knockbackFlag = true;

                target = prevPos;
                if (transform.position == prevPos)
                {
                    SetAnimationParam(1);
                    target = transform.position - MOVEX * 10;
                }
                damage++;

            }
            if (collision.gameObject.tag == "Lenemy")
            {
                audioSource.clip = playerKnockbackAudio;
                audioSource.Play();

                knockbackFlag = true;

                target = prevPos;
                if (transform.position == prevPos)
                {
                    SetAnimationParam(2);
                    target = transform.position + MOVEX * 10;
                }
                damage++;

            }
            if (collision.gameObject.tag == "Denemy")
            {
                audioSource.clip = playerKnockbackAudio;
                audioSource.Play();

                knockbackFlag = true;

                target = prevPos;
                if (transform.position == prevPos)
                {
                    SetAnimationParam(0);
                    target = transform.position + MOVEY * 10;
                }
                damage++;

            }

        }

        if (collision.gameObject.tag == "none")
        {
            if (knockbackFlag == false) 
            {
                audioSource.clip = playerFallAudio;
                audioSource.Play();

                deadFlag = true;
                //step = 0;
                prevPos = collision.gameObject.transform.position;
                target = prevPos;
                //target = transform.position;
                //second += Time.deltaTime;
                //if(second>2)
                //{
                //    fadeManager.fadeOutStart(0, 0, 0, 0, "Result");

                //}
                fadeManager.fadeOutStart(0, 0, 0, 0, "Result");
            }

        }

        if(collision.gameObject.tag == "NearWall")
        {
            prevPos = collision.gameObject.transform.position;
        }

        if (collision.gameObject.tag =="Wall")
        {
            target = prevPos;
            knockbackFlag = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "none")
        {
            if (knockbackFlag == false)
            {
                if(deadFlag ==false)
                {
                    audioSource.clip = playerFallAudio;
                    audioSource.Play();

                    //step = 0;
                    prevPos = collision.gameObject.transform.position;
                    target = prevPos;
                    //target = transform.position;
                    //second += Time.deltaTime;
                    //if(second>2)
                    //{
                    //    fadeManager.fadeOutStart(0, 0, 0, 0, "Result");

                    //}
                    fadeManager.fadeOutStart(0, 0, 0, 0, "Result");
                    deadFlag = true;

                }
            }

        }
    }
}