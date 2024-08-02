using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//シーン変更処理を使用

public class Count_Time : MonoBehaviour
{
    [SerializeField] public GameObject player_obj;//プレイヤーを取得
    public Text timeText;//時間を表示するText型の変数
    public float countup = 0.0f;//カウントアップ

    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;//ゲームが続いている状態
    }

    // Update is called once per frame
    void Update()
    {
        //ゲームオーバーになった場合
        if(isGameOver) return;
        else
        {
            countup += Time.deltaTime;//時間をカウント
            //ToString→書式設定。標準書式 f = 小数型
            timeText.text = countup.ToString("f1");//時間を表示
        }

        if(!player_obj)
        {
            timeText.text = "" + countup.ToString("f1") + "";
            isGameOver = true;

            SceneManager.LoadScene("ScoreScene");
            Debug.Log("スコアシーンに切り替え");
        }
    }

    //プロパティー設定（countupをBounce_Enemydata で呼び出すため）
    public float CountUP
    {
        get { return this.countup; }//取得用
        private set { this.countup = value; }//値入力用
    }
}
