using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange2 : MonoBehaviour
{
    GameObject ManageObject;
    SceneFadeManager fadeManager;
    public bool GameOverFlag = false;
    bool trigger;
    public AudioClip system;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        ManageObject = GameObject.Find("ManagerObj");
        fadeManager = ManageObject.GetComponent<SceneFadeManager>();
        trigger = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (trigger == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                audioSource.PlayOneShot(system);

                fadeManager.fadeOutStart(0, 0, 0, 0, "GamePlay7_7");
                trigger = true;
            }

        }

    }
}
