using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーキー＋ジャンプ操作
public class PlayerKey : MonoBehaviour
{
    private Rigidbody2D rb2d;//Rigidbody2D参照
    private float x_speed;//移動速度
    private float jumppower = 800.0f;//ジャンプ力
    private bool isGround = false;//ジャンプできる状態 = true, ジャンプできない状態 = false

    #region 参考サイト
    /* 移動処理
     * https://feynman.co.jp/unityforest/game-create-lesson/2d-action-game/character-making/ */
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();//Rigidbody2D取得
    }

    // Update is called once per frame
    void Update()
    {
        KeyMove();
    }

    /// <summary>
    /// 移動処理
    /// </summary>
    private void KeyMove()
    {
        //スペースキーが押された場合
        if (Input.GetKeyDown(KeyCode.Space) && isGround) 
            rb2d.AddForce(transform.up * jumppower);//AddForce() 力を加える + ターゲットごと動かす
        //右矢印キーが押された場合
        else if (Input.GetKey(KeyCode.RightArrow)) 
            x_speed = 8.0f;
        //左矢印キーが押された場合
        else if (Input.GetKey(KeyCode.LeftArrow))
            x_speed = -8.0f;
        else
            x_speed = 0.0f;
    }

    //FixedUpdate(一定時間ごとに１度ずつ実行・物理演算用）
    private void FixedUpdate()
    {
        Vector2 velocity = rb2d.velocity;//移動速度ベクトルを現在値から取得
        velocity.x = x_speed;//X方向の速度を入力から決定
        rb2d.velocity = velocity;//計算した移動速度ベクトルをrb2dに反映
    }

    //OnCollisionStay2D=衝突中毎フレーム呼ばれる
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }
    //OnCollisionExit2D=衝突していた状態から離れたタイミングで呼ばれる
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = false;
        }
    }

}