using System.Collections.Generic;
using UnityEngine;

public class CardManager_Gabu : MonoBehaviour
{
    [SerializeField]
    private CardScriptableObject[] _Bacecards;
    public List<CardScriptableObject> cards;

    private void Start()
    {
        cards = new List<CardScriptableObject>(_Bacecards);
    }
    public CardScriptableObject PullCard()
    {
        CardScriptableObject pullCard = cards[Random.Range(0, cards.Count - 1)];
        cards.Remove(pullCard);
        return pullCard;
    }
}
