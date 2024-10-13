using System.Collections.Generic;
using UnityEngine;

public class PlayerClass_Gabu : MonoBehaviour
{
    #region�@�ϐ�

    protected List<int> _a_currentCards = new List<int>();      // �J�[�h�̔z��
    public int i_points = 0;                                    // �J�[�h�̍��v
    public bool isIhasAce = false;                              // Ace�����Ă邩
    public bool isImNatural = false;                            // Natural Black Jack�ł���ꍇ
    public TurnManager turnManagare;
    public CardManager cardManager;
    public InstanceClass instanceClass;

    #endregion

    #region�@�֐�

    /// <summary>
    /// �J�[�h�̍��v���v�Z����Bace������ꍇ�������Ƃ��iace�������������Ă����v�̃p�^�[���͂Q�ł���j
    /// ���ۂ͂���ȓ���Ȃ��Aace������ꍇ�͍��v�Ƃ��̍��v�ɂP�O�𑫂����Q�̃p�^�[����������΂���
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public int PointCalculator(int[] cards)
    {
        int total = 0;

        for (int i = 0; i < cards.Length; i++)
        {
            total += cards[i];

            // Ace�����Ă��true
            if (cards[i] == 1)
            {
                isIhasAce = true;
            }
        }

        return total;
    }

    /// <summary>
    /// Ace�����邩�m�F����
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public bool CheckAce(int[] cards)
    {
        foreach (int i in cards)
        {
            if (i == 1) // Ace�����������瑦true�Ԃ�
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Natural Black Jack���ǂ�����Ԃ�
    /// </summary>
    /// <param name="cards"></param>
    /// <param name="minCards">�ς��Ȃ��Ă����ANatural�Ɣ��肷�閇��</param>
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
    /// �J�[�h���P������
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
    /// �����D�N���A
    /// </summary>
    public void CleaCards()
    {
        _a_currentCards.Clear();
    }

    #endregion

}
