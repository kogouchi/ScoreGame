using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//ターゲット(マウス左クリック先のこと)
public class TargetMove : MonoBehaviour
{
    private Vector3 mouse_pos; //マウス座標
    private Vector3 obj_pos; //ターゲット座標

    #region 参考サイト
    /* 参考サイト
    オブジェクトをクリックした座標へ移動させる
    https://futabazemi.net/unity/click_xpos_move */
    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //マウス左クリックが押された場合
        if(Input.GetMouseButtonDown(0))
        {
            mouse_pos = Input.mousePosition;//マウスの座標を取得
            //Debug.Log("現在のマウス座標=" + mouse_pos);//マウス位置確認
            obj_pos = Camera.main.ScreenToWorldPoint(new Vector3(mouse_pos.x, obj_pos.y, 10.0f));
            //とりあえずy座標は地面の上くらいにする（あとで変更するか、位置固定にする）
            obj_pos.y = -8.5f;//y座標は動かせない（このy座標はプレイヤーy座標となる）
            //ワールド座標をオブジェクトの座標に設定
            this.transform.position = obj_pos;
            //Debug.Log("ターゲット座標=" + obj_pos);//ターゲット位置確認
        }
    }
}