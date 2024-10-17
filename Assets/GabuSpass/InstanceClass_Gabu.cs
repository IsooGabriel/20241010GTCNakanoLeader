using UnityEngine;

public class InstanceClass_Gabu : MonoBehaviour
{
    public GameManager_Nakano gameManager;
    public TurnManager_Sionoya turnManager;
    public cardmanager_mizuno cardManager;
    public PlayerManager_Gabu player;
    public DealerManager_Gabu dealer;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager_Nakano>();
        turnManager = FindObjectOfType<TurnManager_Sionoya>();
        cardManager = FindObjectOfType<cardmanager_mizuno>();
        player = FindObjectOfType<PlayerManager_Gabu>();
        dealer = FindObjectOfType<DealerManager_Gabu>();
        if (gameManager == null)
        {
            gameManager = Instantiate(new GameManager_Nakano());
        }
        if (turnManager == null)
        {
            turnManager = Instantiate(new TurnManager_Sionoya());
        }
        if (cardManager == null)
        {
            cardManager = Instantiate(new cardmanager_mizuno());
        }
        if (player == null)
        {
            player = Instantiate(new PlayerManager_Gabu());
        }
        if (dealer == null)
        {
            dealer = Instantiate(new DealerManager_Gabu());
        }
    }
}
