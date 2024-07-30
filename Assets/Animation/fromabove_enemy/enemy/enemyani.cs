using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyani : MonoBehaviour
{
    public GameObject[] enemy_obj;//エネミーオブジェクト取得
    private int rnd;//ランダム生成

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(EnemyDownAni());
    }

    private IEnumerator EnemyDownAni()
    {
        //rnd = Random.Range(0, 2);//ランダム生成(最小値, 最大値-1の値)
        ////Debug.Log("ランダム値 = " + rnd);//ランダム生成値の確認
        //
        //if (rnd == 0)
        //{
        //    //上から落ちてくるエネミーの生成
        //    Instantiate(enemy_obj[0], new Vector2(0.0f, 0.0f), Quaternion.identity);
        //    yield return new WaitForSeconds(1.0f);//何秒待つか
        //}
        //else if (rnd == 1)
        //{
            for(int i = 0; i <= 7; i++)
            {
                //エネミー生成
                Instantiate(enemy_obj[i]);
                yield return new WaitForSeconds(1.0f);//何秒待つか
            }
        //}
    }
}
