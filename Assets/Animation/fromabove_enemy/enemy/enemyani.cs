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
        StartCoroutine(EnemyDownAni());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator EnemyDownAni()
    {
        rnd = Random.Range(0, 2);//ランダム生成(最小値, 最大値-1の値)
        //Debug.Log("ランダム値 = " + rnd);//ランダム生成値の確認
        
        if(rnd == 0)
        {
            for (int i = 0; i <= 6; i++)
            {
                Instantiate(enemy_obj[i], new Vector2(0.0f, 0.0f), Quaternion.identity);
                yield return new WaitForSeconds(1.5f);
            }
        }
        else
        {
            for (int i = 6; i >= 0; i--)
            {
                Instantiate(enemy_obj[i], new Vector2(0.0f, 0.0f), Quaternion.identity);
                yield return new WaitForSeconds(1.5f);
            }
        }
    }
}