using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgm : MonoBehaviour
{
    [SerializeField] public AudioSource audios;//オーディオソース型
    [SerializeField] public AudioClip[] audioClips;//オーディオクリップ型
    public int rnd;//ランダム変数

    #region 参考サイト
    /* オーディオ再生
     * https://qiita.com/Maru60014236/items/94a017ae59306929dbfb */
    #endregion

    // Start is called before the first frame update
    void Start()
{
    rnd = Random.Range(0, 4);//ランダム生成(最小値, 最大値-1の値)
    audios.PlayOneShot(audioClips[rnd]);
    Debug.Log(rnd + " 番目のBGMを再生");
}

// Update is called once per frame
void Update()
{

}
}
