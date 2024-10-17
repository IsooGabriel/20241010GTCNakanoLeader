using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �J�[�h�̃X�N���v�^�u���I�u�W�F�N�g�̃R���N�V�������Ǘ����܂��B
/// </summary>
public class cardmanager_mizuno : MonoBehaviour
{
    /// <summary>
    /// �J�[�h���X�g�����������邽�߂̊�{�J�[�h�̔z��B
    /// </summary>
    [SerializeField]
    private CardScriptableObject[] _Bacecards;
         

    /// <summary>
    /// �J�[�h�̃X�N���v�^�u���I�u�W�F�N�g�̃��X�g�B
    /// </summary>
    public List<CardScriptableObject> cards;

    /// <summary>
    /// ��{�J�[�h�ŃJ�[�h���X�g�����������܂��B
    /// </summary>
    private void Start()
    {
        // _Bacecards��number���Ƀ\�[�g
        System.Array.Sort(_Bacecards, (card1, card2) => card1.number.CompareTo(card2.number));
        cards = new List<CardScriptableObject>(_Bacecards);
    }

    /// <summary>
    /// ���X�g���烉���_���ɃJ�[�h�������A���X�g����폜���܂��B
    /// </summary>
    /// <returns>�������J�[�h�B</returns>
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
