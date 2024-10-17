using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カードのスクリプタブルオブジェクトのコレクションを管理します。
/// </summary>
public class cardmanager_mizuno : MonoBehaviour
{
    /// <summary>
    /// カードリストを初期化するための基本カードの配列。
    /// </summary>
    [SerializeField]
    private CardScriptableObject[] _Bacecards;
         

    /// <summary>
    /// カードのスクリプタブルオブジェクトのリスト。
    /// </summary>
    public List<CardScriptableObject> cards;

    /// <summary>
    /// 基本カードでカードリストを初期化します。
    /// </summary>
    private void Start()
    {
        // _Bacecardsをnumber順にソート
        System.Array.Sort(_Bacecards, (card1, card2) => card1.number.CompareTo(card2.number));
        cards = new List<CardScriptableObject>(_Bacecards);
    }

    /// <summary>
    /// リストからランダムにカードを引き、リストから削除します。
    /// </summary>
    /// <returns>引いたカード。</returns>
    public CardScriptableObject PullCard()
    {
        CardScriptableObject pullCard = cards[Random.Range(0, cards.Count - 1)];
        cards.Remove(pullCard);
        return pullCard;
    }
    public void ResetCards()
    {
        cards = new List<CardScriptableObject>(_Bacecards);

    }

}
