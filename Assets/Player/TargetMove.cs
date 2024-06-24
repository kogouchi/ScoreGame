using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//GameObj
//ターゲット(クリック先)
public class TargetMove : MonoBehaviour
{
    Vector3 mousePos, pos; //マウスとゲームオブジェクトの座標データを格納

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //マウスの座標を取得する
            mousePos = Input.mousePosition;
            //マウス位置を確認
            Debug.Log(mousePos);
            //スクリーン座標をワールド座標に変換する
            pos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, 10f, 10f));
            //ワールド座標をゲームオブジェクトの座標に設定する
            transform.position = pos;
        }
    }

    //private Vector3 mouse_pos;//マウス座標
    //private Vector3 target_pos;//オブジェクト座標
    //
    //#region 参考サイト
    ///* 参考サイト
    //オブジェクトをクリックした座標へ移動させる
    //https://futabazemi.net/unity/click_xpos_move */
    //#endregion
    //
    //// Start is called before the first frame update
    //void Start()
    //{
    //
    //}
    //
    //// Update is called once per frame
    //void Update()
    //{
    //    //マウス左クリックが押さえれた場合
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        mouse_pos = Input.mousePosition;//マウス座標の取得
    //        mouse_pos.z = 10.0f;
    //        target_pos = Camera.main.ScreenToViewportPoint(mouse_pos);//スクリーン座標をオブジェクト座標に変換
    //        transform.position = new Vector3(target_pos.x, 0, 0);
    //    }
    //}
}