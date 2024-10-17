using UnityEngine;

public class TurnManager_Sionoya : MonoBehaviour
{
    public bool isPlayerTurn = true;
    public int turnCount = 0;


    public void SetTurnEnd()
    {
        isPlayerTurn = !isPlayerTurn;
    }


}
