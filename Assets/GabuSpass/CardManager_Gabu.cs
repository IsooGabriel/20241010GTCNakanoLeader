using UnityEngine;

public class CardManager_Gabu : MonoBehaviour
{
    public CardScriptableObject PullCard()
    {
        Debug.Log("pull is ok");
        return new CardScriptableObject();
    }
}
