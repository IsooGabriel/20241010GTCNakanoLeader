using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerClass_Gabu : MonoBehaviour
{
    #region�@�ϐ�

    protected List<int> _a_currentCards;                        // �J�[�h��int�z��
    protected List<MyScriptableObject> _a_scripts;              // �J�[�h��scriptableObject�z��
    public int i_points = 0;                                    // �J�[�h�̍��v
    public bool isIhasAce = false;                              // Ace�����Ă邩
    public bool isImNatural = false;                            // Natural Black Jack�ł���ꍇ
    public GameObject cardCanvas;                               // �J�[�h��image����ׂ�I�u�W�F�N�g�A���t�@�N�^�����O�ŕʃN���X�ɕ�������������
    public GameObject cardPrefab;                               // �J�[�h�v���n�u�A��Ɠ����ŕ�������������

    public TurnManager_Gabu turnManagare;
    public CardManager_Gabu cardManager;
    public InstanceClass_Gabu instanceClass;

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

        _a_scripts.Add(cardManager.PullCard());
        MyScriptableObject scriptable = _a_scripts[_a_scripts.Count - 1];
        _a_currentCards.Add(scriptable.number);

        i_points = PointCalculator(_a_currentCards.ToArray());
        InstanceCard(scriptable);
    }

    /// <summary>
    /// �����D�N���A
    /// </summary>
    public void CleaCards()
    {
        _a_currentCards.Clear();
        CleaCardsCanvas();
    }

    /// <summary>
    /// ScriptableObject����X�v���C�g���L�����o�X�ɉf���N
    /// </summary>
    /// <param name="scriptable"></param>
    public void InstanceCard(MyScriptableObject scriptable)
    {
        GameObject obj = Instantiate(cardPrefab);
        obj.GetComponent<Image>().sprite = scriptable.sprite;
        obj.transform.parent = cardCanvas.transform;
    }

    /// <summary>
    /// ��ƐS���Ɏ����������s����N
    /// </summary>
    public void CleaCardsCanvas()
    {
        foreach (Transform child in cardCanvas.transform)
        {
            //�����̎q����Destroy����
            Destroy(child.gameObject);
        }
    }
    #endregion
}
