using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawer : MonoBehaviour
{
    [Header("スポーンする敵のプレハブ")]
    [SerializeField] GameObject[] _blockPrefabs;  //blockの種類別リスト

    [Header("スポーンする位置")]
    [SerializeField] Vector3 _spawnPotision;  //スポーンする位置
                                              //InstanciateのためVector3型

    void Start()
    {
        SpawnNext();  //最初のスポーンで呼び出す
    }

    private void SpawnNext()
    {
        //ランダムなブロックをとってくる
        int randomIndex = Random.Range(0, _blockPrefabs.Length);
        //生成
        GameObject newBlock = 
            Instantiate(_blockPrefabs[randomIndex], _spawnPotision, Quaternion.identity);

        //newBlock
        if (!newBlock.GetComponent<BlockController>().enabled)
        {
            Debug.Log("ゲームオーバー！");

            //ゲームオーバー処理のメソッド
            
            Destroy(newBlock);  //邪魔なので削除
        }
    }
}
