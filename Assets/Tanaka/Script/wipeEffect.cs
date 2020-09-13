using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wipeEffect : MonoBehaviour
{
    [SerializeField]
    private Camera myCamera;
    private Material material;

    /// <summary>
    /// シーン上の覗き穴Effect対象のGameObjectの配列
    /// </summary>
    [SerializeField]
    private GameObject[] cubeArray;

    /// <summary>
    /// 処理中フラグ
    /// </summary>
    private bool isProcess;

    /// <summary>
    /// 最終的な半径の大きさ
    /// </summary>
    [SerializeField, Range(0.1f, 1.0f)]
    private float destinationRadius;

    /// <summary>
    /// 半径の一時変数
    /// </summary>
    private float _radius;

    GameObject currentTarget;
    int index = 0;

    void Start()
    {
        material = new Material(Shader.Find("Custom/CircleFadeOut"));
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (isProcess)
        {
            UpdateMaterial();
            Graphics.Blit(source, destination, material);
        }
    }

    void UpdateMaterial()
    {
        Vector3 screenPoint = myCamera.WorldToScreenPoint(currentTarget.transform.position);

        float currentRadius = Screen.height * _radius;
        material.SetFloat("_HoleCenterX", screenPoint.x);
        material.SetFloat("_HoleCenterY", screenPoint.y);
        material.SetFloat("_Radius", currentRadius);
    }

    /// <summary>
    /// 指定されたGameObjectのスクリーン上の座標の周りを黒塗りにする
    /// </summary>
    /// <param name="target">Target.</param>
    void StartTargetWipeEffect(GameObject target)
    {
        isProcess = true;
        _radius = 2.0f;
        currentTarget = target;
        //DOTween.To(r => _radius = r, _radius, destinationRadius, 1.0f)
            //.OnComplete(() => {
                Debug.Log("WipeEffect Process End!");
            //});
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //StartTargetWipeEffect(cubeArray[index % cubeArray.Length]);
            //index++;
        }
    }
}