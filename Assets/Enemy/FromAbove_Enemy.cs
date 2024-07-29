using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//上から降ってくるエネミー
//エネミーのRigidbody2Dの「Constraints」の「Freeze Rotation」の z にチェックを入れる（回転を防ぐため）
public class FromAbove_Enemy : MonoBehaviour
{
    public float enemyspeed;//落下速度
    public bool isTouch;//接触フラグ
    public bool isAnimation;//アニメーションフラグ
    
    private Animator animator;//アニメーションの取得
    private Rigidbody2D rb2d;//Rigidbody2D
    private Vector2 enemy_pos;//エネミー位置

    #region 参考サイト
    /* 重力の有効化について
     * https://qiita.com/kouheyHEY/items/d75028968a0718ca972a */
    /* キーフレームアニメーション
     * https://docs.unity3d.com/ja/2022.3/Manual/animeditor-AnimatingAGameObject.html */
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        enemyspeed = 0.05f;//落下速度
        isTouch = false;//接触フラグ
        isAnimation = false;//アニメーションフラグ
        rb2d = this.GetComponent<Rigidbody2D>();//Rigidbody2Dの取得
        //rb2d.isKinematic = true;//重力を一時無効化
        rb2d.velocity = new Vector2(rb2d.velocity.x, 0.0f);//座標の指定
        animator = gameObject.GetComponent<Animator>();//animatorコンポーネントを設定
    }

    // Update is called once per frame
    void Update()
    {
        FromAboveEnemyMove();
    }

    /// <summary>
    /// 落下物本体動作
    /// </summary>
    /// <returns>敵の削除</returns>
    private void FromAboveEnemyMove()
    {
        //接触した場合
        if (isTouch && isAnimation)
        {
            enemyspeed = 0.0f;//エネミーを停止させる
            if (gameObject) Destroy(gameObject, 0.5f);//エネミー削除
        }
        else
        {
            gameObject.transform.localPosition = new Vector2(6.0f, 8.4f);
            animator.SetBool("boolPos", true);//bool型のパラメータであるboolPosをTrueに変更
            //Debug.Log("アニメーション処理中");
            isAnimation = true;
        }
    }

    /// <summary>
    /// アニメーションオブジェクト位置の処理
    /// </summary>
    /// <param name="layerIndex"></param>
    //private void OnAnimatorIK(int layerIndex)
    //{
    //    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
    //}

    //地面との衝突判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //もし地面と衝突した場合
        if (collision.collider.tag == "Ground")
        {
            isTouch = true;//フラグをtrueに返す
        }
    }
}
