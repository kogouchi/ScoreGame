using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Player.cs
/*左右移動↓
プレイヤー側からターゲットの位置を取得
マウスが押された時のみプレイヤー移動 */
/*ジャンプ↓

*/
#endregion

public class Player : MonoBehaviour
{
    public GameObject target_obj;//ターゲット(クリック先オブジェクト)を取得
    public int jumpnum;//ジャンプを数える(2段階ジャンプする予定)
    //public int jumpcnt;//ジャンプした数を数える
    public float speed;//プレイヤーがターゲットに移動するスピード
    public float jumping;//ジャンプ
    public bool isTouch;//ターゲットの位置でない状態 = true, ターゲットの位置の状態 = false

    //private Vector3 worldpos;
    private Rigidbody2D rb2d;//Rigidbody2Dの格納
    #region 参考サイト
    /* 参考サイト
    オブジェクトをクリックした座標へ移動させる
    https://futabazemi.net/unity/click_xpos_move */
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.025f;//移動速度
        //jumpcnt = 0;
        jumpnum = 2;//ジャンプ回数
        jumping = 20.0f;//ジャンプ力(のちに画面の３分の１分に変更させる)
        isTouch = false;//ターゲットの位置の状態

        target_obj = GameObject.Find("target");//ターゲットオブジェクト
        rb2d = GetComponent<Rigidbody2D>();//Rigidbody2Dを取得

    }

    //当たり判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //プレイヤーとターゲット(クリック先オブジェクト)が当たった場合
        if (collision.gameObject.name == "target")
        {
            isTouch = true;//ターゲットの位置でない状態
        }
    }

    // Update is called once per frame
    void Update()
    {
        //ジャンプ処理
        //ジャンプした回数がjumpnumより少ない場合 &&
        //スペースキーが押された場合
        if (Input.GetKey(KeyCode.Space))// && jumpcnt < jumpnum)
        {
            //transform.positionを使うのではなくaddForce()を使って力を加える
            //Vector3 worldpos = this.transform.position;
            rb2d.AddForce(new Vector3(0, jumping, 0), ForceMode2D.Force);//AddForce(新しく位置を生成)
            //GetComponent<Rigidbody2D>().MovePosition(transform.position + new Vector3(0, jumping * jumpcnt, 0));
            
            Debug.Log("ジャンプ位置" + jumping);
            //jumpcnt++;//ジャンプした回数カウント
        }
        //プレイヤーが地面に当たった場合
        if(transform.position.y == target_obj.transform.position.y)
        {
            //jumpcnt = 0;//カウントを0に戻す
        }

        PlayerMove();//プレイヤー移動処理関連
    }

    

    //現状：下記は移動処理(のちジャンプ処理も関数内に入れる予定)
    void PlayerMove()
    {
        //左右移動処理
        //ターゲットの位置の状態
        if (isTouch == false)
        {
            //プレイヤー座標にターゲットの座標に変換
            //MoveTowards(移動したいオブジェクトの位置, ターゲットの位置, 移動速度)
            transform.position = Vector3.MoveTowards(transform.position, target_obj.transform.position, speed);
        }
    }
}