using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤー側からターゲットの位置を取得する
//マウスが押された時のみプレイヤー移動させる
public class Player : MonoBehaviour
{
    public GameObject target_obj;//ターゲット(クリック先オブジェクト)を取得
    public float speed;//プレイヤーがターゲットに移動するスピード
    public float jumppower;//ジャンプ力
    public bool isTouch;//クリックされた状態 = true, クリックされていない状態 = false

    private Rigidbody2D rb;//Rigidbody2Dを取得
    private bool isGround;//ジャンプできる状態 = true, ジャンプできない状態 = false

    #region 参考サイト
    /* オブジェクトをクリックした座標へ移動させる
     * https://futabazemi.net/unity/click_xpos_move */
    /* プレイヤージャンプ addForce()を使用したもの
     * https://fineworks-fine.hatenablog.com/entry/2022/05/12/073000 */
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.2f;
        jumppower = 1600.0f;
        target_obj = GameObject.Find("target");
        isTouch = false;
        isGround = false;//追加
        rb = this.GetComponent<Rigidbody2D>();//追加
    }



    // Update is called once per frame
    void Update()
    {
        PlayerJump();//ジャンプ処理
        PlayerMove();//移動処理関連
    }

    //PlayerMove＝左右移動とジャンプ処理
    void PlayerMove()
    {
        //左右移動処理（マウスフラグ）
        if (isTouch == false)
        {
            //プレイヤー座標にターゲットの座標に変換
            //MoveTowards(移動したいオブジェクトの位置, ターゲットの位置, 移動速度)
            transform.position = Vector3.MoveTowards(transform.position, target_obj.transform.position, speed);
        }
    }

    void PlayerJump()
    {
        if (isGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Vector3 force = new Vector3(0, jumppower, 0);
                Debug.Log("jump = " + force);
                rb.AddForce(force);
            }
        }
    }






    //当たり判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //プレイヤーとターゲット(クリック先オブジェクト)が当たった場合
        if (collision.gameObject.name == "target")
        {
            isTouch = true;
        }
    }
    //下記ジャンプ処理に使用
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "ground")
        {
            isGround = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "ground")
        {
            isGround = false;
        }
    }


}