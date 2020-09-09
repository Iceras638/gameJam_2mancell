using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildColliderTrigger : MonoBehaviour
{

    groundFall colliderTriggerParent;

    // Use this for initialization
    void Start()
    {
        GameObject objColliderTriggerParent = gameObject.transform.parent.gameObject;
        colliderTriggerParent = objColliderTriggerParent.GetComponent<groundFall>();
    }


    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        colliderTriggerParent.RelayOnTriggerEnter2D(collision);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        colliderTriggerParent.RelayOnTriggerStay2D(collision);
    }
}