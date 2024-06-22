using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//プレイヤーの左右移動＋ジャンプ
public class Player : MonoBehaviour
{
    Vector3 mouse_pos, world_pos;//座標用の変数

    #region 参考サイト
    /* 参考サイト
    オブジェクトをクリックした座標へ移動させる
    https://tanisugames.com/mouse-move/ */
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouse_pos = Input.mousePosition;//マウス座標の取得
        world_pos = Camera.main.ScreenToWorldPoint(new Vector3(mouse_pos.x, mouse_pos.y, 10.0f));//スクリーン座標をワールド座標に変換
        transform.position = world_pos;//ワールド座標を自身の座標に設定
    }

    private void Move()
    {

    }
}
