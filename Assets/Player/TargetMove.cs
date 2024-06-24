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

    void Update()
    {
        //マウス左クリックが押された時
        if(Input.GetMouseButtonDown(0))
        {
            mouse_pos = Input.mousePosition;//マウスの座標を取得
            //Debug.Log("現在のマウス座標=" + mouse_pos);//マウス位置確認
            //スクリーン座標をワールド座標に変換
            obj_pos = Camera.main.ScreenToWorldPoint(new Vector3(mouse_pos.x, 0.0f, 10.0f));
            //オブジェクトy軸を0に設定
            obj_pos.y = 0.0f;
            //ワールド座標をオブジェクトの座標に設定
            this.transform.position = obj_pos;
            //Debug.Log("ターゲット座標=" + obj_pos);//オブジェクト位置確認
        }
    }
}