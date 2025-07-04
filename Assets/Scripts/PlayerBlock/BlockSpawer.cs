using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawer : MonoBehaviour
{
    [Header("�X�|�[������G�̃v���n�u")]
    [SerializeField] GameObject[] _blockPrefabs;  //block�̎�ޕʃ��X�g

    [Header("�X�|�[������ʒu")]
    [SerializeField] Vector3 _spawnPotision;  //�X�|�[������ʒu
                                              //Instanciate�̂���Vector3�^

    void Start()
    {
        SpawnNext();  //�ŏ��̃X�|�[���ŌĂяo��
    }

    private void SpawnNext()
    {
        //�����_���ȃu���b�N���Ƃ��Ă���
        int randomIndex = Random.Range(0, _blockPrefabs.Length);
        //����
        GameObject newBlock = 
            Instantiate(_blockPrefabs[randomIndex], _spawnPotision, Quaternion.identity);

        //newBlock
        if (!newBlock.GetComponent<BlockController>().enabled)
        {
            Debug.Log("�Q�[���I�[�o�[�I");

            //�Q�[���I�[�o�[�����̃��\�b�h
            
            Destroy(newBlock);  //�ז��Ȃ̂ō폜
        }
    }
}
