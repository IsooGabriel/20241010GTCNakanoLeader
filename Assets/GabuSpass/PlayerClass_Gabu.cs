using System.Collections.Generic;
using UnityEngine;

public class PlayerClass_Gabu : MonoBehaviour
{
    #region　変数

    private List<int> _a_currentCards = new List<int>();    // カードの配列
    private int _i_points = 0;                              // カードの合計
    public bool isIhasAce = false;                          // Aceもってるか
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

    #endregion

}
