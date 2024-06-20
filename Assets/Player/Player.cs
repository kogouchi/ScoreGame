using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 mousePos, worldPos;//座標用変数
    //public int speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //マウス左クリックが押された時
        //if (Input.GetMouseButtonDown(0))
        //{
        //    //Y軸は何もしない
        //    mousePos = Input.mousePosition;//マウス座標の取得
        //    worldPos = this.gameObject.transform.position;//現在の位置を取得
        //    this.gameObject.transform.position = new Vector3(mousePos.x, worldPos.y, 0.0f);
        //}
        
    }
}
