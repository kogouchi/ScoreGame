using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject target;
    public float speed;
    public bool isTouch;

    #region 参考サイト
    /* 参考サイト
    オブジェクトをクリックした座標へ移動させる
    https://futabazemi.net/unity/click_xpos_move */
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.1f;
        target = GameObject.Find("target_obj");
        isTouch = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "target_obj")
        {
            isTouch = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouch == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
        }
    }
}