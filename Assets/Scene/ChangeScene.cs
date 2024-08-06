using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーン変更処理を使用

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Game_start()
    {
        if(SceneManager.GetActiveScene().name == "TitleScene")
        {
            SceneManager.LoadScene("GameScene");
            Debug.Log("ゲームシーンに切り替え");
        }
    }

    public void GameEnd()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲーム終了
#endif
    }

    public void Re_start()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            SceneManager.LoadScene("GameScene");
            Debug.Log("ゲームシーンに切り替え");
        }
    }

    public void Title()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            SceneManager.LoadScene("TitleScene");
            Debug.Log("タイトルシーンに切り替え");
        }
    }
}
