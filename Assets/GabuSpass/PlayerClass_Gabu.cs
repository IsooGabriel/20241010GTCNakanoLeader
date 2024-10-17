using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerClass_Gabu : MonoBehaviour
{
    #region　変数

    protected List<int> _a_currentCards = new List<int>();                                  // カードのint配列
    protected List<CardScriptableObject> _a_scripts = new List<CardScriptableObject>();     // カードのscriptableObject配列
    public int i_points = 0;                                    // カードの合計
    public bool isIhasAce = false;                              // Aceもってるか
    public bool isImNatural = false;                            // Natural Black Jackである場合
    public GameObject cardCanvas;                               // カードのimageを並べるオブジェクト、リファクタリングで別クラスに分けた方がいい
    public GameObject cardPrefab;                               // カードプレハブ、上と同じで分けた方がいい

    public TurnManager_Sionoya turnManagare;
    public cardmanager_mizuno cardManager;
    public InstanceClass_Gabu instanceClass;

    #endregion

    #region 関数

    /// <summary>
    /// カードの合計を計算する。aceがある場合もちゃんとやる（aceが複数枚あっても合計のパターンは２である）
    /// 実際はこんな難しくない、aceがある場合は合計とその合計に１０を足した２つのパターンさえあればいい
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public int PointCalculator(int[] cards)
    {
        if (cards.Length == 0)
        {
            return 0;
        }

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

        _a_scripts.Add(cardManager.PullCard());
        CardScriptableObject scriptable = _a_scripts.Last();
        _a_currentCards.Add(scriptable.number);

        i_points = PointCalculator(_a_currentCards.ToArray());
        InstanceCard(scriptable);
    }

    /// <summary>
    /// 持ち札クリア
    /// </summary>
    public void CleaCards()
    {
        _a_currentCards.Clear();
        CleaCardsCanvas();
    }

    /// <summary>
    /// ScriptableObjectからスプライトをキャンバスに映す君
    /// </summary>
    /// <param name="scriptable"></param>
    public void InstanceCard(CardScriptableObject scriptable)
    {
        Vector2 prefabScale = cardPrefab.transform.localScale;
        Vector3 position = cardPrefab.transform.position;

        GameObject obj = Instantiate(cardPrefab);
        obj.GetComponent<Image>().sprite = scriptable.sprite;
        obj.transform.parent = cardCanvas.transform;
        obj.transform.localScale = prefabScale;
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = cardPrefab.transform.rotation;
    }

    /// <summary>
    /// 一家心中に自分だけ失敗する君
    /// </summary>
    public void CleaCardsCanvas()
    {
        foreach (Transform child in cardCanvas.transform)
        {
            //自分の子供をDestroyする
            Destroy(child.gameObject);
        }
    }
    #endregion

    private void Start()
    {
        if (instanceClass == null)
        {
            instanceClass = FindObjectOfType<InstanceClass_Gabu>();
        }

        if (cardManager == null)
        {
            cardManager = instanceClass.cardManager;
        }
        if (turnManagare == null)
        {
            turnManagare = instanceClass.turnManager;
        }
    }
}
