using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GameManager_Nakano : MonoBehaviour
{
    int PlayerPoint;//プレイヤーの合計ポイント(仮)
    int DealerPoint;//ディーラーの合計ポイント(仮)
    PlayerManager_Gabu playermanagerscript;
    DealerManager_Gabu dealermanagerscript;
    cardmanager_mizuno cardmanagerscript;
    TurnManager_Sionoya turnmanagerscript;

    // Start is called before the first frame update
    void Start()
    {
        playermanagerscript = GetComponent<PlayerManager_Gabu>();//PlayerManagerスクリプトを探す
        dealermanagerscript = GetComponent<DealerManager_Gabu>();//DealerManagerスクリプトを探す

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void startGame()
    {

    }

    int Judge()//勝敗
    {
        PlayerPoint = playermanagerscript.i_points;
        DealerPoint= dealermanagerscript.i_points;
       bool PlayerNatural = playermanagerscript.isImNatural;
        bool DealerNatural = dealermanagerscript.isImNatural;
        int judge = 0;
        if(PlayerPoint!=DealerPoint)//同じポイントじゃないとき
        {
            if (PlayerPoint <= 21 && DealerPoint <= 21)
            {
                judge = PlayerPoint > DealerPoint ? 0 : 1;
            }
            else if (DealerPoint > 21)//
            {
                judge = 0;
            }
            else if (PlayerPoint > 21)//
            {
                judge = 1;
            }
            else
            {
                judge = 2;
            }
        }
        else if (!DealerNatural)//
        {
            judge = 0;
        }
        else if (!PlayerNatural)//
        {
            judge = 1;
        }
        else
        {
            judge = 2;
        }
        return judge;
    }
}
