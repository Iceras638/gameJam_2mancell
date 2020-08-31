using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet") 
        {
            Destroy(gameObject);
        }
    }
}
