using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//一定の距離でエネミーを出現
public class FromAboveEnemyFormation : MonoBehaviour
{
    public GameObject[] enemy_obj;//エネミーオブジェクト取得
    private int rnd;//ランダム生成

    #region 参考サイト
    /* 参考サイト
     * コルーチンの使い方
     * https://umistudioblog.com/coroutinehowto/ */
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //startで配列の中からランダムに呼び出すようにする→コルーチン開始
        //rnd = Random.Range(0, 2);//ランダム生成(最小値, 最大値-1の値)
        //Debug.Log("ランダム値 = " + rnd);//ランダム生成値の確認

        //コルーチン開始
        //StartCoroutine(EnemyDown());
        StartCoroutine(EnemyPursue());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// コルーチン処理
    /// 上から落ちてくるエネミーのランダム生成
    /// </summary>
    /// <returns>生成する秒数</returns>
    private IEnumerator EnemyDown()
    {
        rnd = Random.Range(0, 2);//ランダム生成(最小値, 最大値-1の値)
        //Debug.Log("ランダム値 = " + rnd);//ランダム生成値の確認

        if (rnd == 0)
        {
            for (int i = 0; i <= 6; i++)
            {
                //上から落ちてくるエネミーの生成
                Instantiate(enemy_obj[0], new Vector2(-15.0f + (i * 5.0f), 8.5f), Quaternion.identity);
                //1つ生成したら待つ
                yield return new WaitForSeconds(1.0f);//何秒待つか
            }
        }
        else if (rnd == 1)
        {
            for (int i = 0; i <= 6; i++)
            {
                //上から落ちてくるエネミーの生成
                Instantiate(enemy_obj[0], new Vector2(15.0f - (i * 5.0f), 8.5f), Quaternion.identity);
                //1つ生成したら待つ
                yield return new WaitForSeconds(1.0f);//何秒待つか
            }
        }
    }

    /// <summary>
    /// コルーチン処理
    /// 左右から追従してくるエネミーのランダム生成
    /// </summary>
    /// <returns>生成する秒数</returns>
    private IEnumerator EnemyPursue()
    {
        rnd = Random.Range(0, 2);//ランダム生成(最小値, 最大値-1の値)
        //Debug.Log("ランダム値 = " + rnd);//ランダム生成値の確認

        if (rnd == 0)
        {
            yield return new WaitForSeconds(1.0f);//何秒待つか
            //左右からプレイヤーの方向へ向かってくるエネミーの生成
            Instantiate(enemy_obj[1], new Vector2(-16.5f, 0.0f), Quaternion.identity);
        }
        else if (rnd == 1)
        {
            yield return new WaitForSeconds(1.0f);//何秒待つか
            //左右からプレイヤーの方向へ向かってくるエネミーの生成
            Instantiate(enemy_obj[1], new Vector2(16.5f, 0.0f), Quaternion.identity);
        }
    }
}
