using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    GameObject ManageObject;
    SceneFadeManager fadeManager;
    public bool GameOverFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        ManageObject = GameObject.Find("ManagerObj");
        fadeManager = ManageObject.GetComponent<SceneFadeManager>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fadeManager.fadeOutStart(0, 0, 0, 0, "GamePlay");

        }

    }
}
