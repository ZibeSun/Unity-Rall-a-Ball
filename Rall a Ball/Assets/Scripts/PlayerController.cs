using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;    //使用 UnityEngine.UI 命名空间；
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;              //定义一个公共单精度浮点变量 speed；
    public Text countText;           //声明一个公共 Text 文本组件 countText；
    public Text winText;             //声明一个公共 Text 文本组件 winText；
    private Rigidbody rb;            //声明一个私有 rigidbody 刚体组件 rb；
    public GameObject endUI;
    public GameObject Pickups;

    private int count;               //定义一个私有整型变量 count；

    //场景加载好，开始的时候执行一次 （用来初始化数据），一定会在Update系列函数前面
    void Start()
    {
        rb = GetComponent<Rigidbody>();  //将游戏对象 Player 附加的 rigidbody 刚体组件返回给 rb；
        count = 0;                   //游戏开始时将 count 初始化为0；
        SetCountText();              //调用自定义函数 SetCountText 初始化游戏界面显示信息；
        winText.text = "";           //初始化 Text 组件 winText 中的text属性；
        endUI.SetActive(false);
        Pickups.SetActive(true);
        rb.transform.position = new Vector3(0.0f, 0.5f, 0.0f);
    }

    // Update is called once per frame
    //固定的刷新率 0.02s 执行一次，主要用来执行物理模拟的脚本
    void FixedUpdate()
    {
        //PC操作
        //float moveHorizontal = Input.GetAxis("Horizontal"); 
        //float moveVertical = Input.GetAxis("Vertical"); 

        //手机操作
        //接收来自手机重力传感器的输入；
        float moveHorizontal = Input.acceleration.x;   
        float moveVertical = Input.acceleration.y;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);    //创建一个 Vector3 类对象 movement，并使用来自键盘的输入作为参数输入构造函数Vector3进行初始化；

        rb.AddForce(movement*speed);                          //调用刚体组件 rb 的 AddForce 函数向刚体添加力，力的方向为3D向量 movement ，乘以一个 speed 来控制小球移动的速度；
    }

    //当两个 GameObjects 碰撞时，OnTriggerEnter 函数执行。
    //注：两个 GameObjects 都必须包含 Collider 组件和 Rigidbody 组件。且其中一个必须启用 Collider.isTrigger，即设置为触发器。
    void OnTriggerEnter(Collider other)           //OnTriggerEnter的输入参数为碰撞对象的 Collider 组件；
    {
        if(other.gameObject.CompareTag("Pick Up")) //判断碰撞对象是否使用了"Pick Up"标记；
        {
            other.gameObject.SetActive(false);    //停用碰撞对象；
            count+=10;                            //小球每次碰撞到正方体+10分；
            SetCountText();                       //小球每次与正方体碰撞就更新一次分数显示；
        }
    }

    void SetCountText()             //自定义函数SetCountText来显示信息；
    {
        countText.text = "得分：" + count.ToString();     //显示得分信息；使用.ToString将整型变量 count 转换成字符型变量输出；
        if (count>=100)                                   //当得分达到100时；
        {
            winText.text = "！！！赢啦！！！";                   //显示游戏胜利；
            endUI.SetActive(true);
        }
    }

    public void OnRestart()
    {
        SceneManager.LoadScene("mini game");
    }

    public void OnMainMenu()
    {
        SceneManager.LoadScene("menu");
    }

    public void OnMenu()
    {
        endUI.SetActive(true);
    }
}
