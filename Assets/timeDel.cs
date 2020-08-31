using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeDel : MonoBehaviour
{
    float second;
    public float limit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        second += Time.deltaTime;
        if(second > limit)
        {
            second = 0;
            Destroy(gameObject);
        }
    }
}
