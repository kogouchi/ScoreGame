using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//シーン変更処理を使用

public class Score : MonoBehaviour
{
    [SerializeField] public GameObject score_text;//スコア
    public static int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
