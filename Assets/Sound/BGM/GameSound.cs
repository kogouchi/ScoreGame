using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーン切り替え時使用

public class GameSound : MonoBehaviour
{
    [SerializeField] public AudioSource[] audios;//オーディオソース型
    //[SerializeField] public Object[] audioClips;//BGMデータ
    
    private int rnd;//ランダム変数
    private bool isPlay;//再生フラグ

    #region 参考サイト
    /* オーディオ再生
     * https://qiita.com/Maru60014236/items/94a017ae59306929dbfb */
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        isPlay = false;//再生フラグ
        RndSound();//BGM再生
    }

    // Update is called once per frame
    void Update()
    {
        GamePlay();//ゲームプレイ中（デバッグ用処理）
    }

    /// <summary>
    /// BGM再生
    /// </summary>
    private void RndSound()
    {
        rnd = Random.Range(0, 5);//ランダム生成(最小値, 最大値-1の値)
        for(int i = 0; i < 5; i++)
        {
            if (rnd == i)
            {
                audios[rnd].Play();//再生
                Debug.Log(rnd + " 番目のBGMを再生");
                audios[rnd].loop = true;//ループを有効化
            }
            else audios[i].Stop();//停止
        }
    }

    /// <summary>
    /// ゲームプレイ中
    /// </summary>
    public void GamePlay()
    {
        //現在がゲームシーンの場合
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            //Rキーが押された場合（デバッグ用）
            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene("GameScene");//ゲームシーン切り替え
                                                    //Eキーが押された場合（デバッグ用）
            if (Input.GetKeyDown(KeyCode.E))
                game_end();
            //Escapeが押された場合（デバッグ用）
            if (Input.GetKeyDown(KeyCode.Escape))
                SceneManager.LoadScene("TitleScene");//タイトルシーン切り替え
        }
    }

    private void game_end()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲーム終了
#endif
    }
}
