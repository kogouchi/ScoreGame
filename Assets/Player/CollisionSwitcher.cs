using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーとターゲットの衝突判定を無効にする処理(試し)
public class CollisionSwitcher : MonoBehaviour
{
    public bool ignoreCollision;

    [SerializeField] private Collider colPlayer;//プレイヤーコライダー取得
    [SerializeField] private Collider colTarget;//ターゲットコライダー取得
    private bool _ignoreCollisionCache;

    #region 参考サイト
    /* オブジェクト同士の衝突判定を無効にする
     * https://qiita.com/su10/items/48bf301bb1c6446ef3b8 */
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _ignoreCollisionCache = ignoreCollision;
    }

    // Update is called once per frame
    void Update()
    {
        if(_ignoreCollisionCache != ignoreCollision)
        {
            Physics.IgnoreCollision(colPlayer, colTarget, ignoreCollision);
            _ignoreCollisionCache = ignoreCollision;
        }
    }
}
