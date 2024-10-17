using TMPro;
using UnityEngine;

public class GameManager_Nakano : MonoBehaviour
{
    int PlayerPoint;//プレイヤーの合計ポイント(仮)
    int DealerPoint;//ディーラーの合計ポイント(仮)
    int playerWins = 0;
    int dealerWins = 0;

    TextMeshProUGUI playerTmp;
    TextMeshProUGUI dealerTmp;

    PlayerManager_Gabu playermanagerscript;
    DealerManager_Gabu dealermanagerscript;
    cardmanager_mizuno cardmanagerscript;
    TurnManager_Sionoya turnmanagerscript;
    InstanceClass_Gabu instanceClass;

    // Start is called before the first frame update
    void Start()
    {
        if (instanceClass == null)
        {
            instanceClass = FindObjectOfType<InstanceClass_Gabu>();
            if (instanceClass == null)
            {
                Debug.LogWarning("InstanceClass_Gabuが見つかりません");
            }
        }

        if (playermanagerscript == null)
        {
            playermanagerscript = instanceClass.player;
        }
        if (dealermanagerscript == null)
        {
            dealermanagerscript = instanceClass.dealer;
        }
        if (cardmanagerscript == null)
        {
            cardmanagerscript = instanceClass.cardManager;
        }
        if (turnmanagerscript == null)
        {
            turnmanagerscript = instanceClass.turnManager;
        }
        startGame();
    }


    void startGame()
    {
        playermanagerscript.PullCard();
        dealermanagerscript.PullCard();
        playermanagerscript.PullCard();
        dealermanagerscript.PullCard();
        turnmanagerscript.isPlayerTurn = true;
        turnmanagerscript.turnCount = 1;
        playerWins = 0;
        dealerWins = 0;
    }

    int Judge()//勝敗
    {
        PlayerPoint = playermanagerscript.i_points;
        DealerPoint = dealermanagerscript.i_points;
        bool PlayerNatural = playermanagerscript.isImNatural;
        bool DealerNatural = dealermanagerscript.isImNatural;
        int judge = 0;
        if (PlayerPoint != DealerPoint)//同じポイントじゃないとき
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

    private void Update()
    {
        playerTmp.text = $"<size=70>Youre WINs: </size><size=120>{playerWins}</size>";
        dealerTmp.text = $"<size=70>Dealer WINs: </size><size=120>{dealerWins}</size>";
    }
}
