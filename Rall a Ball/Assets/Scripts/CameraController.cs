using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;         //声明一个公共 GameObject 游戏对象 player；

    private Vector3 offset;           //声明一个私有 Vector3 类对象 offset；

    // Start is called before the first frame update
    // 场景加载好，开始的时候执行一次 （用来初始化数据），一定会在Update系列函数前面
    void Start()
    {
        offset = transform.position - player.transform.position;    //游戏开始时初始化offset 向量，offset 向量=摄像机的坐标-小球的坐标；
    }

    // Update is called once per frame
    // 每一帧执行一次，跟在Update后面执行；
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;    //摄像机的位置=小球的坐标+offset 向量；
    }
}
