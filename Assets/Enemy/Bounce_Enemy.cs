using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//常に跳ね返っているエネミー
//スクリプト追加時 Rigidbody2D の Gravity Scale を 0 にする
//＋制限時間が長くなっていくほど増やしていく？
public class Bounce_Enemy : MonoBehaviour
{
    public float speed = 10.0f;
    new Rigidbody2D rigidbody;

    #region 参考サイト
    /* オブジェクト跳ね返る
     * https://hu-gsd.com/lecture/unity-block-1/ */
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody2Dにアクセスして変数保持
        rigidbody = GetComponent<Rigidbody2D>();
        //右斜め45度に進む
        rigidbody.velocity = new Vector3(speed, -speed, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
