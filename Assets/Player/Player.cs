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
    public Rigidbody2D rb;//Rigidbody2Dを取得

    private bool isJumping;//ジャンプできる状態 = true, ジャンプできない状態 = false
    private Vector3 now_pos;//現在の位置

    #region 参考サイト
    /* 参考サイト
    オブジェクトをクリックした座標へ移動させる
    https://futabazemi.net/unity/click_xpos_move */
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.025f;
        jumppower = 4.0f;
        target_obj = GameObject.Find("target");
        isTouch = false;
        isJumping = false;
        //transform.position = new Vector3(0.0f, 3.0f, 0.0f);
    }

    //当たり判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //プレイヤーとターゲット(クリック先オブジェクト)が当たった場合
        if (collision.gameObject.name == "target")
        {
            isTouch = true;
        }
        //地面とプレイヤーが当たった場合
        if(collision.gameObject.name == "floor")
        {
            isJumping = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        now_pos = gameObject.transform.position;//現在の位置情報取得(ジャンプする時に戻ってこなければいけないため)
        PlayerMove();//プレイヤー移動処理関連
    }

    private void FixedUpdate()
    {
        //ジャンプ処理
        //スペースキーが押された場合
        if (Input.GetKey(KeyCode.Space) && !isJumping)
        {
            //transform.positionを使うのではなくaddForce()を使って力を加える
            
            //GetComponent<Rigidbody2D>().AddForce(0, 0, 0);
            //rb.AddForce(transform.up * speed, ForceMode2D.Impulse);//試し
            Debug.Log("ジャンプ");
            isJumping = true;
        }
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
}