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
    コルーチンの使い方
    https://umistudioblog.com/coroutinehowto/ */
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rnd = Random.Range(0, 2);//ランダム生成(最小値, 最大値-1の値)
        Debug.Log("ランダム値 = " + rnd);//ランダム生成値の確認
        StartCoroutine(EnemyDown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator EnemyDown()
    {
        if(rnd == 0)
        {
            for (int i = 0; i < 10; i++)
            {
                //上から落ちてくるエネミーの生成
                Instantiate(enemy_obj[0], new Vector3(-16.0f + (i * 4.0f), 8.5f, 0.0f), Quaternion.identity);
                //1つ生成したら待つ
                yield return new WaitForSeconds(1.0f);//何秒待つか
            }
        }
        else if (rnd == 1)
        {
            for (int i = 0; i < 10; i++)
            {
                //上から落ちてくるエネミーの生成
                Instantiate(enemy_obj[0], new Vector3(16.0f - (i * 4.0f), 8.5f, 0.0f), Quaternion.identity);
                //1つ生成したら待つ
                yield return new WaitForSeconds(1.0f);//何秒待つか
            }
        }
    }
}
