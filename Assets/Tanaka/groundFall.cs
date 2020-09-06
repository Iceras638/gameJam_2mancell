using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundFall : MonoBehaviour
{
    public GameObject fall;
    bool hitFlag;
    float second,color;
    [SerializeField]
    public float limit;

    GameObject waveObj;
    waveManager waveManage;


    // Start is called before the first frame update
    void Start()
    {
        waveObj = GameObject.Find("WaveManager");
        waveManage = waveObj.GetComponent<waveManager>();

        hitFlag = false;
        color = 1;
        second =0;
        limit = waveManage.GroundTime;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().color = new Color(color, color, color, 1);
        limit = waveManage.GroundTime;

        if (hitFlag)
        {
            second += Time.deltaTime;
            color -= 0.006f / limit;
            if(second > limit)
            {
                //Debug.Log("aaa");
                Instantiate(fall, transform.position, Quaternion.identity);
                color = 1;

                second = 0;
                hitFlag = false;


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
}
