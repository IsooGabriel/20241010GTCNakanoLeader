using TMPro;
using UnityEngine;

public class GameManager_Nakano : MonoBehaviour
{
    int PlayerPoint;//プレイヤーの合計ポイント(仮)
    int DealerPoint;//ディーラーの合計ポイント(仮)
    int playerWins = 0;
    int dealerWins = 0;

    public TextMeshProUGUI playerTmp;
    public TextMeshProUGUI dealerTmp;
    public TextMeshProUGUI judjeTmp;

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
        DealingCards();
        turnmanagerscript.isPlayerTurn = true;
        turnmanagerscript.turnCount = 1;
        playerWins = 0;
        dealerWins = 0;
    }

    public void DealingCards()
    {
        playermanagerscript.PullCard();
        dealermanagerscript.PullCard();
        playermanagerscript.PullCard();
        dealermanagerscript.PullCard();
    }

    public void NextTurn()
    {
        playermanagerscript.CleaCards();
        dealermanagerscript.CleaCards();
        turnmanagerscript.isPlayerTurn = true;

        DealingCards();
    }

    public void Stand()
    {
        switch (Judge())
        {
            case 0:
                playerWins++;
                break;
            case 1:
                dealerWins++;
                break;
            case 2:
                break;
        }


    }

    public void PlyaerWIN()
    {
        judjeTmp.text = "<color=yellow>WIN<color>";
    }

    public void DealerWINT()
    {
        judjeTmp.text = "<color=#5d00ff>LOSE<color>";
    }

    public void JudgePush()
    {
        judjeTmp.text = "<color=gray>PUSH<color>";
    }

    int Judge()//勝敗
    {
        PlayerPoint = playermanagerscript.i_points;
        DealerPoint = dealermanagerscript.i_points;

        PlayerPoint += (PlayerPoint + 10) <= 21 ? 10 : 0;
        DealerPoint += (DealerPoint + 10) <= 21 ? 10 : 0;

        bool PlayerNatural = playermanagerscript.isImNatural;
        bool DealerNatural = dealermanagerscript.isImNatural;
        int judge = 0;                  // 0:Player WIN 1:Dealer WIN 2:Push
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
