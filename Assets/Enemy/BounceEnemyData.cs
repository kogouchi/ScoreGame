using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceEnemyData : MonoBehaviour
{
    [SerializeField] GameObject Bounce_obj;//エネミー取得
    public Count_Time count_time;//countup の値の取得
    private float bCount = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //制限時間が1すぎた場合1つ生成
        bCount = count_time.CountUP;//プロパティの取得
        Debug.Log(bCount);//ログで確認

        //if(bCount)
        //{
        //StartCoroutine(BounceData());//コルーチン開始
        //}
    }

    /// <summary>
    /// 常に動き続けるエネミーの生成
    /// </summary>
    /// <returns>エネミー生成時1.0待つ</returns>
    private IEnumerator BounceData()
    {
        Instantiate(Bounce_obj, new Vector2(0.0f, 0.0f), Quaternion.identity);
        yield return new WaitForSeconds(1.0f);
    }
}
