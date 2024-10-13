using System.Collections.Generic;
using UnityEngine;

public class PlayerClass_Gabu : MonoBehaviour
{
    #region　変数

    protected List<int> _a_currentCards = new List<int>();      // カードの配列
    public int i_points = 0;                                    // カードの合計
    public bool isIhasAce = false;                              // Aceもってるか
    public bool isImNatural = false;                            // Natural Black Jackである場合
    public TurnManager turnManagare;
    public CardManager cardManager;
    public InstanceClass instanceClass;

    #endregion

    #region　関数

    /// <summary>
    /// カードの合計を計算する。aceがある場合もちゃんとやる（aceが複数枚あっても合計のパターンは２である）
    /// 実際はこんな難しくない、aceがある場合は合計とその合計に１０を足した２つのパターンさえあればいい
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public int PointCalculator(int[] cards)
    {
        int total = 0;

        for (int i = 0; i < cards.Length; i++)
        {
            total += cards[i];

            // Aceもってるをtrue
            if (cards[i] == 1)
            {
                isIhasAce = true;
            }
        }

        return total;
    }

    /// <summary>
    /// Aceがあるか確認する
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public bool CheckAce(int[] cards)
    {
        foreach (int i in cards)
        {
            if (i == 1) // Aceが見つかったら即true返す
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Natural Black Jackかどうかを返す
    /// </summary>
    /// <param name="cards"></param>
    /// <param name="minCards">変えなくていい、Naturalと判定する枚数</param>
    /// <returns></returns>
    public bool CheckNatural(int[] cards, int minCards = 2)
    {
        if (cards.Length > minCards)
        {
            return false;
        }

        if (PointCalculator(cards) == 21)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// カードを１枚引く
    /// </summary>
    public void PullCard()
    {
        i_points = PointCalculator(_a_currentCards.ToArray());
        if (i_points >= 21)
        {
            return;
        }
        _a_currentCards.Add(cardManager.GetCard());
        i_points = PointCalculator(_a_currentCards.ToArray());
    }

    /// <summary>
    /// 持ち札クリア
    /// </summary>
    public void CleaCards()
    {
        _a_currentCards.Clear();
    }

    #endregion

}
