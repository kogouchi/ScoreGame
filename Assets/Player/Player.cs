using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤー側からターゲットの位置を取得する
//マウスが押された時のみプレイヤー移動させる
//プレイヤーRigidbody2D「Linear Drag」の数値を「15」変更
//プレイヤーRigidbody2D「Constraints」の「z」をチェックを外す
public class Player : MonoBehaviour
{
    [SerializeField] public GameObject target_obj;//ターゲット(クリック先オブジェクト)を取得
    [SerializeField] public Rigidbody2D rb2d;//Rigidbody2D
    [SerializeField] public Collider2D co2d;//Collider2D

    public bool isGround;//ジャンプできる状態 = true, ジャンプできない状態 = false
    public float clickspeed;//プレイヤーがターゲットに移動するスピード
    public float jumppower;//ジャンプ力
    public bool isTouch;//クリックされた状態 = true, クリックされていない状態 = false


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
        jumppower = 600.0f;//ジャンプの高さ
        target_obj = GameObject.Find("target");//オブジェクトの取得
        isTouch = false;//クリックしているかどうか
        isGround = false;//地面についているかどうか
        rb2d = target_obj.GetComponent<Rigidbody2D>();//Rigidbody2Dの取得
        co2d = target_obj.GetComponent<Collider2D>();//Collider2Dの取得
        co2d.isTrigger = true;
        transform.position = new Vector2(transform.position.x, -3);//プレイヤーの初期位置
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerJump();
        //PlayerClickMove();
        ClickMove();
    }

    /// <summary>
    /// 移動処理
    /// </summary>
    private void ClickMove()
    {
        if (isGround && !co2d.isTrigger)
        {
            //スペースキーが押された場合
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb2d.AddForce(target_obj.transform.up * jumppower);//AddForce() 力を加える + ターゲットごと動かす
                Debug.Log("ジャンプした");
            }
            else co2d.isTrigger = true;
        }
        //左右移動処理（マウスフラグ）
        if (isTouch == false)
        {
            //プレイヤー座標にターゲットの座標に変換
            //MoveTowards(移動したいオブジェクトの位置, ターゲットの位置, 移動速度)
            transform.position = Vector3.MoveTowards(transform.position, target_obj.transform.position, clickspeed);
        }
    }

    /// <summary>
    /// クリック移動処理
    /// </summary>
    private void PlayerClickMove()
    {
        //左右移動処理（マウスフラグ）
        if (isTouch == false)
        {
            //プレイヤー座標にターゲットの座標に変換
            //MoveTowards(移動したいオブジェクトの位置, ターゲットの位置, 移動速度)
            transform.position = Vector3.MoveTowards(transform.position, target_obj.transform.position, clickspeed);
        }
    }

    /// <summary>
    /// ジャンプ処理
    /// </summary>
    private void PlayerJump()
    {
        //isGroundがtrueの場合
        if (isGround)
        {
            //スペースキーが押された場合
            if (Input.GetKeyDown(KeyCode.Space))
            {
                co2d.isTrigger = false;
                rb2d.AddForce(target_obj.transform.up * jumppower);//AddForce() 力を加える + ターゲットごと動かす
                Debug.Log("ジャンプした");
            }

            co2d.isTrigger = true;
        }
    }


    //当たり判定(衝突判定)-------------------
    //OnCollisionEnter2D=接触した時のみ呼び出される
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //プレイヤーとターゲット(クリック先オブジェクト)が当たった場合
        if (collision.gameObject.tag == "Target")
        {
            isTouch = true;
        }
        //プレイヤーと追従エネミーが当たった場合
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);//プレイヤー削除
        }
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
    //---------------------------------------
}