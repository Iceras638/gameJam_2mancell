using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundFall : MonoBehaviour
{
    //public GameObject fall;
    bool hitFlag, fallFlag;
    float second,alpha,second2;
    [SerializeField]
    public float limit,limit2;

    GameObject waveObj;
    waveManager waveManage;

    GameObject childGround,childNone;


    // Start is called before the first frame update
    void Start()
    {
        waveObj = GameObject.Find("WaveManager");
        waveManage = waveObj.GetComponent<waveManager>();

        childGround = transform.GetChild(0).gameObject;
        childNone = transform.GetChild(1).gameObject;

        hitFlag = false;
        fallFlag = false;
        alpha = 1;
        second =0;
        limit = waveManage.GroundTime;
    }

    // Update is called once per frame
    void Update()
    {
        childGround.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
        limit = waveManage.GroundTime;

        if (hitFlag)
        {
            second += Time.deltaTime;
            alpha -= 0.006f / limit;
            if(second > limit)
            {
                childNone.SetActive(true);
                childGround.SetActive(false);
                fallFlag = true;
                //Debug.Log("aaa");
                //Instantiate(fall, transform.position, Quaternion.identity);
                alpha = 1;

                second = 0;
                hitFlag = false;


            }
        }
        if(fallFlag == true)
        {
            second2 += Time.deltaTime;
            if(second2 > limit2)
            {
                //Debug.Log("aaa");

                childNone.SetActive(false);
                childGround.SetActive(true);
                second2 = 0;
                fallFlag = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "MovePlayer") 
        {
            hitFlag = true;
        }
    }

    public void RelayOnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "MovePlayer")
        {
            hitFlag = true;
        }

    }

    public void RelayOnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "MovePlayer")
        {
            hitFlag = true;
        }

    }
}
