using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    float speed;

    //Animator animator;   // アニメーション


    // Use this for initialization
    void Start()
    {
        target = transform.position;
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        // ① 移動中かどうかの判定。移動中でなければ入力を受付
        if (transform.position == target)
        {
            SetTargetPosition();
        }
        Move();
    }

    // ② 入力に応じて移動後の位置を算出
    void SetTargetPosition()
    {
        prevPos = target;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            target = transform.position - MOVEX;
            Instantiate(bullet,transform.position,Quaternion.identity);
            x = speed;
            y = 0;
            return;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            target = transform.position + MOVEX;
            Instantiate(bullet, transform.position, Quaternion.identity);
            x = -speed;
            y = 0;

            return;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            target = transform.position - MOVEY;
            Instantiate(bullet, transform.position, Quaternion.identity);
            x = 0;
            y = speed;

            return;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            target = transform.position + MOVEY;
            Instantiate(bullet, transform.position, Quaternion.identity);
            x = 0;
            y = -speed;

            return;
        }
    }

    // WalkParam  0;下移動　1;右移動　2:左移動　3:上移動
    void SetAnimationParam(int param)
    {
        //animator.SetInteger("WalkParam", param);
    }

    // ③ 目的地へ移動する
    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, step * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Uenemy")
        {
            target = transform.position - MOVEY * 10;

        }
        if (collision.gameObject.tag == "Renemy")
        {
            target = transform.position - MOVEX * 10;

        }
        if (collision.gameObject.tag == "Lenemy")
        {
            target = transform.position + MOVEX * 10;

        }
        if (collision.gameObject.tag == "Denemy")
        {
            target = transform.position + MOVEY * 10;

        }

        if(collision.gameObject.tag == "none")
        {
            target = prevPos;

        }

        if (collision.gameObject.tag =="Wall")
        {
            target = transform.position;
        }
    }
}