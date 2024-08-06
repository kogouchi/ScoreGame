using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーン切り替え時使用

public class GameSound : MonoBehaviour
{
    [SerializeField] public AudioSource[] audios;//オーディオソース型

    private int rndmin;//最小乱数
    private int rndmax;//最大乱数
    private int rnd;//ランダム変数
    private bool isPlay;//再生フラグ

    #region 参考サイト
    /* オーディオ再生
     * https://qiita.com/Maru60014236/items/94a017ae59306929dbfb */
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rndmin = 0;//最小乱数
        rndmax = 0;//最大乱数
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
    public void RndSound()
    {
        //現在がタイトルシーンの場合
        if (SceneManager.GetActiveScene().name == "TitleScene") rndmax = 2;
        //現在がゲームシーンの場合
        if (SceneManager.GetActiveScene().name == "GameScene") rndmax = 5;

        rnd = Random.Range(rndmin, rndmax);//ランダム生成(最小値, 最大値-1の値)
        for(int i = 0; i < rndmax; i++)
        {
            if (rnd == i)
            {
                audios[rnd].Play();//再生
                //Debug.Log(rnd + " 番目のBGMを再生");
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
        //現在がタイトルシーンの場合
        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            //Escapeが押された場合（デバッグ用）
            if (Input.GetKeyDown(KeyCode.Escape))
                SceneManager.LoadScene("TitleScene");//タイトルシーン切り替え
        }

        //現在がゲームシーンの場合
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            //Rキーが押された場合（デバッグ用）
            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene("GameScene");//ゲームシーン切り替え
                                                    //Eキーが押された場合（デバッグ用）
            if (Input.GetKeyDown(KeyCode.E))
                GameEnd();
            //Escapeが押された場合（デバッグ用）
            if (Input.GetKeyDown(KeyCode.Escape))
                SceneManager.LoadScene("TitleScene");//タイトルシーン切り替え
        }
    }

    private void GameEnd()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲーム終了
#endif
    }
}
