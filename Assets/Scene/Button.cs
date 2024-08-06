using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] public GameObject player_obj;//プレイヤーを取得
    [SerializeField] public GameObject[] button_obj;//UI格納

    public Canvas canvas; // Canvasをアサイン
    private bool isVisible = false;

    // Start is called before the first frame update
    void Start()
    {
        //非常時
        foreach (GameObject uiElement in button_obj)
        {
            uiElement.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!player_obj)
        {
            // Canvasが非アクティブならアクティブにする
            //if (!canvas.gameObject.activeSelf)
            //{
            //    canvas.gameObject.SetActive(true);
            //}
            // 表示状態に応じてすべてのUI要素の表示を切り替える
            foreach (GameObject uiElement in button_obj)
            {
                uiElement.SetActive(true);
            }
        }
    }
}
