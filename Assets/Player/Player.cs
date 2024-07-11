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

    private Rigidbody2D rb2d;//Rigidbody2D
    private bool isGround;//ジャンプできる状態 = true, ジャンプできない状態 = false
    private bool isDestroy;//プレイヤー削除

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
        keyspeed = 0.1f;
        jumppower = 800.0f;//ジャンプの高さ
        target_obj = GameObject.Find("target");//オブジェクトの取得
        isTouch = false;//クリックしているかどうか
        isGround = false;//地面についているかどうか
        isDestroy = false;//削除するかどうか
        rb2d = this.GetComponent<Rigidbody2D>();//Rigidbody2Dの取得
    }

    // Update is called once per frame
    void Update()
    {
        if (isDestroy) Destroy(gameObject);//プレイヤー削除

        PlayerJump();
        PlayerArrowKeyMove();
        PlayerClickMove();
    }

    /// <summary>
    /// 矢印キー移動処理
    /// </summary>
    private void PlayerArrowKeyMove()
    {
        //右矢印キーが押された場合
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector2 pos = transform.position;//現在の位置情報取得
            pos.x += 0.05f;
            target_obj.transform.position = pos;//ターゲットごと動かす
        }
        //左矢印キーが押された場合
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector2 pos = transform.position;//現在の位置情報取得
            pos.x -= 0.05f;
            target_obj.transform.position = pos;//ターゲットごと動かす
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
                //Debug.Log("ジャンプした");
                rb2d.AddForce(new Vector3(0, jumppower, 0));//AddForce() 力を加える
            }
        }
    }


    //当たり判定(衝突判定)-------------------
    //OnCollisionEnter2D=接触した時のみ呼び出される
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //プレイヤーとターゲット(クリック先オブジェクト)が当たった場合
        if (collision.gameObject.name == "target")
        {
            isTouch = true;
        }
        //プレイヤーと追従エネミーが当たった場合→プレハブ化しエネミーを一括管理するためのち変更
        if (collision.gameObject.name == "follow_enemy")
        {
            isDestroy = true;
        }
    }
    //OnCollisionStay2D=衝突中毎フレーム呼ばれる
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "ground")
        {
            isGround = true;
        }
    }
    //OnCollisionExit2D=衝突していた状態から離れたタイミングで呼ばれる
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "ground")
        {
            isGround = false;
        }
    }
    //---------------------------------------
}