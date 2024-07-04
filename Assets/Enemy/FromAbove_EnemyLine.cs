using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//下記のC#現在使用していない
//エネミー落下ライン
public class FromAbove_EnemyLine : MonoBehaviour
{
    public float line;//予測ライン

    private Vector2 linepos;//ライン位置
    
    // Start is called before the first frame update
    void Start()
    {
        line = 0.01f;//エネミーが落下する前の予測線速度
    }

    // Update is called once per frame
    void Update()
    {
        //現在のライン位置取得
        linepos = transform.position;
        //エネミー位置のy軸の変更
        this.transform.position = new Vector2(linepos.x, linepos.y - line);
    }

    //地面との衝突判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //もし地面と衝突した場合
        if (collision.collider.name == "ground")
        {
            Destroy(gameObject, 1.5f);//ラインの削除
        }
    }
}
