using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Nakano : MonoBehaviour
{
    int PlayerPoint;//プレイヤーの合計ポイント(仮)
    int DealerPoint;//ディーラーの合計ポイント(仮)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Judge()//勝敗
    {
        PlayerManagerScript playermanagerscript = GetComponent<PlayerManagerScript>();//PlayerManagerスクリプトを探す
        DealerManagerScript dealermanagerscript = GetComponent<DealerManagerScript>();//DealerManagerスクリプトを探す
        if (PlayerPoint< DealerPoint)//Playerの勝敗を調べる
        {
            Debug.Log("敗北");
        }
        else　if (PlayerPoint > DealerPoint)//Playerの勝敗を調べる
        {
            Debug.Log("勝利");
        }
        else
        {
            Debug.Log("同点");
        }
    }
}
