using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーに一時的に追従させる
public class Follow_Enemy : MonoBehaviour
{
    public GameObject player_obj;//プレイヤーを取得(プレイヤーの位置を保存するため)
    public float enemyspeed;//落下速度
    public bool isTouch;//接触フラグ
    public bool isScreen;//画面フラグ
    public Vector3 player_pos;//プレイヤーの位置座標保存
    public Vector3 enemy_pos;//エネミーの位置座標

    private float rnd;//ランダム生成
    
    // Start is called before the first frame update
    void Start()
    {
        enemyspeed = 0.1f;//エネミー速度
        //player_pos = player_obj.transform.position;
        //player_obj = GameObject.Find("player");//プレイヤーの位置座標取得
        isTouch = false;
        isScreen = false;//画面内 false
        rnd = Random.Range(-3.0f, 8.5f);//ランダム生成(最小値, 最大値-1の値)
        transform.position = new Vector2(10.0f, rnd);//エネミーはランダムに表示
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
        //試案２
        ////プレイヤーとエネミー座標からベクトル求める
        //Vector2 vector2 = player_obj.transform.position - this.transform.position;
        ////上下の回転をしないよう固定
        //vector2.y = 0.0f;
        //
        ////Quaternion(回転値)を取得
        //Quaternion quaternion = Quaternion.LookRotation(vector2);
        ////回転値をゲームオブジェクトのrotationに代入
        //this.transform.rotation = quaternion;
        //
        ////プレイヤー方向に移動し続ける
        //enemy_pos = gameObject.transform.rotation * new Vector3(enemyspeed, enemyspeed, 0);
        //gameObject.transform.position += enemy_pos * Time.deltaTime;

        //試案１
        //if(!isTouch)
        //{
        //    //MoveTowards(移動したいオブジェクトの位置, ターゲットの位置, 移動速度)
        //    transform.position = Vector3.MoveTowards(transform.position, player_pos, enemyspeed);
        //    //Debug.Log("現在の位置座標 = " + transform.position);
        //}
        //else
        //{
        //
        //    //Debug.Log("エネミーがプレイヤーに衝突" + isTouch);
        //}
        //
        ////画面外まで出た場合
        //if (isScreen) Destroy(gameObject);//オブジェクト削除
    }
}
