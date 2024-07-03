using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤー側からターゲットの位置を取得する
//マウスが押された時のみプレイヤー移動させる
//プレイヤーRigidbody2D「Linear Drag」の数値を「15」変更
//プレイヤーRigidbody2D「Constraints」の「z」をチェックを外す
public class Player : MonoBehaviour
{
    public GameObject target_obj;//ターゲット(クリック先オブジェクト)を取得
    public float clickspeed;//プレイヤーがターゲットに移動するスピード
    public float keyspeed;//プレイヤーがキーで移動する
    public float jumppower;//ジャンプ力
    public bool isTouch;//クリックされた状態 = true, クリックされていない状態 = false
    public Rigidbody2D rb2d;//Rigidbody2D
    public Vector3 getpos;//現在のプレイヤー座標取得
    
    private bool isGround;//ジャンプできる状態 = true, ジャンプできない状態 = false

    #region 参考サイト
    /* オブジェクトをクリックした座標へ移動させるサイト
     * https://futabazemi.net/unity/click_xpos_move */
    /* プレイヤージャンプ addForce()を使用したサイト
     * https://fineworks-fine.hatenablog.com/entry/2022/05/12/073000 */
    /* Collision系とTrigger系について詳しく書かれているサイト
     * https://watablog.tech/2019/10/11/post-590/ */
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        clickspeed = 0.05f;//移動速度
        keyspeed = 0.0f;
        jumppower = 800.0f;//ジャンプの高さ
        target_obj = GameObject.Find("target");
        isTouch = false;//クリックしているかどうか
        isGround = false;//地面についているかどうか
        rb2d = this.GetComponent<Rigidbody2D>();//Rigidbody2Dの取得
    }

    // Update is called once per frame
    void Update()
    {
        PlayerJump();//ジャンプ処理
        PlayerArrowKeyMove();//矢印キー移動処理
        PlayerClickMove();//クリック移動処理
    }

    //各関数---------------------------------
    //クリック移動処理関数
    void PlayerClickMove()
    {
        //左右移動処理（マウスフラグ）
        if (isTouch == false)
        {
            //プレイヤー座標にターゲットの座標に変換
            //MoveTowards(移動したいオブジェクトの位置, ターゲットの位置, 移動速度)
            transform.position = Vector3.MoveTowards(transform.position, target_obj.transform.position, clickspeed);
        }
    }
    //矢印キー移動処理関数
    void PlayerArrowKeyMove()
    {
        //現在の位置情報を取得
        getpos = this.gameObject.transform.position;
        //右矢印キーが押された場合
        if (Input.GetKey(KeyCode.RightArrow))
        {
            keyspeed = 0.1f;
        }
        //左矢印キーが押された場合
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            keyspeed = -0.1f;
        }
        else
        {
            keyspeed = 0.0f;
        }
        //現在の位置からx方向のみkeyspeedを足す
        this.gameObject.transform.position = new Vector3(getpos.x + keyspeed, getpos.y, getpos.z);
    }
    //ジャンプ処理
    void PlayerJump()
    {
        //isGroundがtrueの場合
        if (isGround)
        {
            //スペースキーが押された場合
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Debug.Log("ジャンプした");
                rb2d.AddForce(new Vector3(0, jumppower, 0));//AddForce() 力を加える
            }
        }
    }
    //---------------------------------------


    //当たり判定(衝突判定)-------------------
    //OnCollisionEnter2D=接触した時のみ呼び出される
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //プレイヤーとターゲット(クリック先オブジェクト)が当たった場合
        if (collision.gameObject.name == "target")
        {
            isTouch = true;
        }
    }
    //OnCollisionStay2D=衝突中毎フレーム呼ばれる
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "ground")
        {
            isGround = true;
        }
    }
    //OnCollisionExit2D=衝突していた状態から離れたタイミングで呼ばれる
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "ground")
        {
            isGround = false;
        }
    }
    //---------------------------------------
}