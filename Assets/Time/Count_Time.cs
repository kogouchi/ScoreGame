using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//シーン変更処理を使用

public class Count_Time : MonoBehaviour
{
    [SerializeField] public GameObject player_obj;//プレイヤーを取得
    [SerializeField] public GameObject bounceEnemy_obj;//エネミーを取得
    public Text timeText;//時間を表示するText型の変数
    public float countup = 0.0f;//カウントアップ

    private bool isGameOver;

    #region 参考サイト
    /* InvokeRepeating の使い方
     * https://qiita.com/toRisouP/items/e6d4f114d434ee588044 */
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;//ゲームが続いている状態
        //Bounce_Enemyを1.0f秒後に呼び出し、以降は10,0f秒毎に実行
        InvokeRepeating(nameof(BounceEnemyGenerate), 1.0f, 10.0f);
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

        if (!player_obj)
        {
            timeText.text = "" + countup.ToString("f1") + "";
            isGameOver = true;
            SceneManager.LoadScene("ScoreScene");
            Debug.Log("スコアシーンに切り替え");
        }
    }

    /// <summary>
    /// 動き続けるエネミー生成処理
    /// </summary>
    void BounceEnemyGenerate()
    {
        Instantiate(bounceEnemy_obj, new Vector2(0.0f, 0.0f), Quaternion.identity);
    }
}
