using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤー側からターゲットの位置を取得する
//マウスが押された時のみプレイヤー移動させる
public class Player : MonoBehaviour
{
    public GameObject target;//ターゲット(クリック先オブジェクト)を取得
    public float speed;//プレイヤーがターゲットに移動するスピード
    public bool isTouch;//クリックされた状態 = true, クリックされていない状態 = false

    #region 参考サイト
    /* 参考サイト
    オブジェクトをクリックした座標へ移動させる
    https://futabazemi.net/unity/click_xpos_move */
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.1f;//のちUnity上で変更できるようにする
        target = GameObject.Find("target_obj");
        isTouch = false;
    }

    //当たり判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //プレイヤーとターゲット(クリック先オブジェクト)
        if (collision.gameObject.name == "target_obj")
        {
            isTouch = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouch == false)
        {
            //プレイヤー座標にターゲットの座標に変換
            //MoveTowards(移動したいオブジェクトの位置, ターゲットの位置, 移動速度)
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
        }
    }
}