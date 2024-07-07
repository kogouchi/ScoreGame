using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//上から降ってくるエネミー
//エネミーのRigidbody2Dの「Constraints」の「Freeze Rotation」の z にチェックを入れる（回転を防ぐため）
public class FromAbove_Enemy : MonoBehaviour
{
    public float enemyspeed;//落下速度
    public bool isTouch;//接触フラグ

    private Vector2 enemypos;//エネミー位置

    // Start is called before the first frame update
    void Start()
    {
        enemyspeed = 0.1f;//落下速度
        isTouch = false;//接触フラグ
    }

    // Update is called once per frame
    void Update()
    {
        FromAboveEnemyMove();
    }

    //落下物本体
    void FromAboveEnemyMove()
    {
        //接触した場合
        if (isTouch)
        {
            enemyspeed = 0.0f;//エネミーを停止させる
            Destroy(gameObject, 1.0f);//エネミー削除
        }
        else
        {
            //現在のエネミー位置取得
            enemypos = transform.position;
            //エネミー位置のy軸の変更
            this.transform.position = new Vector2(enemypos.x, enemypos.y - enemyspeed);
        }
    }

    //地面との衝突判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //もし地面と衝突した場合
        if (collision.collider.name == "ground")
        {
            isTouch = true;//フラグをtrueに返す
        }
    }
}
