using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーに一時的に追従させる
public class Follow_Enemy : MonoBehaviour
{
    //インスペクター(オブジェクトがアクティブか非アクティブか見るにはインスペクターにする必要がある)
    [SerializeField] public GameObject player_obj;//プレイヤーを取得(プレイヤーの位置を保存するため)
    public float enemyspeed;//落下速度
    
    private float rnd;//ランダム生成

    #region 参考サイト
    /* オブジェクトアクティブ、非アクティブの状態を調べる
     * https://gamefbb.com/%E3%80%90unity%E3%80%91gameobject%E3%81%8C%E5%AD%98%E5%9C%A8%E3%81%97%E3%81%A6%E3%81%84%E3%82%8B%E3%81%8B%E7%A2%BA%E8%AA%8D%E3%81%99%E3%82%8B/ */
    /* オブジェクトを他オブジェクトの方向へ向ける
     * https://qiita.com/No2DGameNoLife/items/1415973e64a1f3505834 */
    /* Quaternion.FromToRotationについて詳しく書かれているサイト
     * https://www.f-sp.com/entry/2017/08/30/171353 */
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        enemyspeed = 0.05f;//エネミー速度
        //player_obj = GameObject.Find("player");//オブジェクトの取得
        //isTouch = false;
        //isScreen = false;//画面内 false
        rnd = Random.Range(-3.0f, 8.5f);//ランダム生成(最小値, 最大値-1の値)
        transform.position = new Vector2(transform.position.x, rnd);//エネミーはランダムに表示
        //Debug.Log("ランダム値 = " + rnd);//ランダム生成値の確認
    }

    // Update is called once per frame
    void Update()
    {
        FollowEnemyMove();
    }

    /// <summary>
    /// 横から出現するエネミー移動処理
    /// </summary>
    private void FollowEnemyMove()
    {
        //プレイヤーがアクティブの場合
        if(player_obj)
        {
            //向きたい方向を計算(プレイヤー位置 - オブジェクト位置)
            Vector3 dir = (player_obj.transform.position - gameObject.transform.position);
            //プレイヤーに追従するエネミーの向きを回転
            //Quaternion 回転を表すもの FromToRotation(開始方向, 終了方向)
            this.transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);

            //プレイヤーとエネミーの距離を図る→プレイヤー範囲内だった場合エネミーの追従を行わない


            //プレイヤーの位置に移動するのではなく向いた方向に移動する方が良い？
            //プレイヤー座標にエネミーの座標に変換
            //MoveTowards(移動したいオブジェクトの位置, ターゲットの位置, 移動速度)
            transform.position = Vector3.MoveTowards(transform.position, player_obj.transform.position, enemyspeed);
            //Debug.Log("プレイヤー位置座標 = " + player_obj.transform.position);//プレイヤー位置位置の確認
        }
    }
}