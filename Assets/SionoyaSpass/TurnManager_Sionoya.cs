using UnityEngine;

public class TurnManager_Sionoya : MonoBehaviour
{
    public bool isPlayerTurn = true;


    public void SetTurnEnd()
    {
        isPlayerTurn = !isPlayerTurn;
    }


}
