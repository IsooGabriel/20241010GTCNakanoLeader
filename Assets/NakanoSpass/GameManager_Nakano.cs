using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Nakano : MonoBehaviour
{
    int PlayerPoint;//�v���C���[�̍��v�|�C���g(��)
    int DealerPoint;//�f�B�[���[�̍��v�|�C���g(��)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Judge()//���s
    {
        PlayerManager_Gabu playermanagerscript = GetComponent<PlayerManager_Gabu>();//PlayerManager�X�N���v�g��T��
        DealerManager_Gabu dealermanagerscript = GetComponent<DealerManager_Gabu>();//DealerManager�X�N���v�g��T��
        if (PlayerPoint< DealerPoint)//Player�̏��s�𒲂ׂ�
        {
            Debug.Log("�s�k");
        }
        else�@if (PlayerPoint > DealerPoint)//Player�̏��s�𒲂ׂ�
        {
            Debug.Log("����");
        }
        else
        {
            Debug.Log("���_");
        }
    }
}
