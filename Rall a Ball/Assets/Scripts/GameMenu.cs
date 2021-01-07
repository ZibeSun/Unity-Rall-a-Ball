using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public void OnStart()
    {
        SceneManager.LoadScene("mini game");
    }

    public void OnExitGame()
    {
#if UNITY_EDITOR            
        UnityEditor.EditorApplication.isPlaying=false;    //若在unity编辑器中运行则退出编辑器游戏模式；
#else
        Application.Quit();                               //若在客户端运行则退出游戏；
#endif
    }
}
