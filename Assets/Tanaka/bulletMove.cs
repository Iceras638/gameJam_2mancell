using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMove : MonoBehaviour
{
    GameObject player;
    playerMove script;
    float x, y;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        script = player.GetComponent<playerMove>();
        x = script.x;
        y = script.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(x, y);
        Destroy(gameObject, 100);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Uenemy"||
            collision.gameObject.tag == "Renemy" ||
            collision.gameObject.tag == "Denemy" ||
            collision.gameObject.tag == "Lenemy" )
        {
            Destroy(gameObject);
        }
    }
}
