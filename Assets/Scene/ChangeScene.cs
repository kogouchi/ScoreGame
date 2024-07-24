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

    public void game_start()
    {
        SceneManager.LoadScene("GameScene");
        Debug.Log("ゲームシーンに切り替え");
    }

    public void game_end()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲーム終了
#endif
    }
}
