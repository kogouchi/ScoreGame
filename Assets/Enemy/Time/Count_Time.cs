using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Count_Up : MonoBehaviour
{
    [SerializeField] public GameObject player_obj;//プレイヤーを取得
    public Text timeText;//時間を表示するText型の変数

    private float countup = 0.0f;//カウントアップ
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
        if(isGameOver)
        {
            return;
        }
        else
        {
            countup += Time.deltaTime;//時間をカウント
            //ToString→書式設定。標準書式 f = 小数型。最後に数字を書くと小数の桁分表示
            timeText.text = countup.ToString("f1");//時間を表示
        }

        if(!player_obj)
        {
            timeText.text = "" + countup.ToString("f1") + "";
            isGameOver = true;
        }
    }
}
