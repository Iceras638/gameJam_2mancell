using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public GameObject Uenemy,Renemy,Lenemy,Denemy;
    int number = 35;
    float second;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        second += Time.deltaTime;

        if(second >= 1)
        {
            int rnd = Random.Range(0, number);

            switch(rnd)
            {
                case 1:
                    Instantiate(Uenemy, transform.position = new Vector3(-3.2f, 4, 0), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(Uenemy, transform.position = new Vector3(-2.4f, 4, 0), Quaternion.identity);
                    break;
                case 3:
                    Instantiate(Uenemy, transform.position = new Vector3(-1.6f, 4, 0), Quaternion.identity);
                    break;
                case 4:
                    Instantiate(Uenemy, transform.position = new Vector3(-0.8f, 4, 0), Quaternion.identity);
                    break;
                case 5:
                    Instantiate(Uenemy, transform.position = new Vector3(0f, 4, 0), Quaternion.identity);
                    break;
                case 6:
                    Instantiate(Uenemy, transform.position = new Vector3(0.8f, 4, 0), Quaternion.identity);
                    break;
                case 7:
                    Instantiate(Uenemy, transform.position = new Vector3(1.6f, 4, 0), Quaternion.identity);
                    break;
                case 8:
                    Instantiate(Uenemy, transform.position = new Vector3(2.4f, 4, 0), Quaternion.identity);
                    break;
                case 9:
                    Instantiate(Uenemy, transform.position = new Vector3(3.2f, 4, 0), Quaternion.identity);
                    break;
                case 10:
                    Instantiate(Renemy, transform.position = new Vector3(4f, 3.2f, 0), Quaternion.identity);
                    break;
                case 11:
                    Instantiate(Renemy, transform.position = new Vector3(4f, 2.4f, 0), Quaternion.identity);
                    break;
                case 12:
                    Instantiate(Renemy, transform.position = new Vector3(4f, 1.6f, 0), Quaternion.identity);
                    break;
                case 13:
                    Instantiate(Renemy, transform.position = new Vector3(4f, 0.8f, 0), Quaternion.identity);
                    break;
                case 14:
                    Instantiate(Renemy, transform.position = new Vector3(4f, 0, 0), Quaternion.identity);
                    break;
                case 15:
                    Instantiate(Renemy, transform.position = new Vector3(4f, -0.8f, 0), Quaternion.identity);
                    break;
                case 16:
                    Instantiate(Renemy, transform.position = new Vector3(4f, -1.6f, 0), Quaternion.identity);
                    break;
                case 17:
                    Instantiate(Renemy, transform.position = new Vector3(4f, -2.4f, 0), Quaternion.identity);
                    break;
                case 18:
                    Instantiate(Renemy, transform.position = new Vector3(4f, -3.2f, 0), Quaternion.identity);
                    break;
                case 19:
                    Instantiate(Lenemy, transform.position = new Vector3(-4f, 3.2f, 0), Quaternion.identity);
                    break;
                case 20:
                    Instantiate(Lenemy, transform.position = new Vector3(-4f, 2.4f, 0), Quaternion.identity);
                    break;
                case 21:
                    Instantiate(Lenemy, transform.position = new Vector3(-4f, 1.6f, 0), Quaternion.identity);
                    break;
                case 22:
                    Instantiate(Lenemy, transform.position = new Vector3(-4f, 0.8f, 0), Quaternion.identity);
                    break;
                case 23:
                    Instantiate(Lenemy, transform.position = new Vector3(-4f, 0, 0), Quaternion.identity);
                    break;
                case 24:
                    Instantiate(Lenemy, transform.position = new Vector3(-4f, -0.8f, 0), Quaternion.identity);
                    break;
                case 25:
                    Instantiate(Lenemy, transform.position = new Vector3(-4f, -1.6f, 0), Quaternion.identity);
                    break;
                case 26:
                    Instantiate(Lenemy, transform.position = new Vector3(-4f, -2.4f, 0), Quaternion.identity);
                    break;
                case 27:
                    Instantiate(Lenemy, transform.position = new Vector3(-4f, -3.2f, 0), Quaternion.identity);
                    break;
                case 28:
                    Instantiate(Denemy, transform.position = new Vector3(-3.2f, -4, 0), Quaternion.identity);
                    break;
                case 29:
                    Instantiate(Denemy, transform.position = new Vector3(-2.4f, -4, 0), Quaternion.identity);
                    break;
                case 30:
                    Instantiate(Denemy, transform.position = new Vector3(-1.6f, -4, 0), Quaternion.identity);
                    break;
                case 31:
                    Instantiate(Denemy, transform.position = new Vector3(-0.8f, -4, 0), Quaternion.identity);
                    break;
                case 32:
                    Instantiate(Denemy, transform.position = new Vector3(0f, -4, 0), Quaternion.identity);
                    break;
                case 33:
                    Instantiate(Denemy, transform.position = new Vector3(0.8f, -4, 0), Quaternion.identity);
                    break;
                case 34:
                    Instantiate(Denemy, transform.position = new Vector3(1.6f, -4, 0), Quaternion.identity);
                    break;
                case 35:
                    Instantiate(Denemy, transform.position = new Vector3(2.4f, -4, 0), Quaternion.identity);
                    break;
                case 36:
                    Instantiate(Denemy, transform.position = new Vector3(3.2f, -4, 0), Quaternion.identity);
                    break;

            }
            second = 0;
        }
       
    }
}
