﻿using TMPro;

public class DealerManager_Gabu : PlayerClass_Gabu
{
    public readonly int _minPoint = 17;
    public TextMeshProUGUI tmp;

    void Update()
    {
        tmp.text = "<size=70>Dealer Point: </size><size=120>" + i_points.ToString() + "</size>";
        if (isIhasAce)
        {
            tmp.text += "<size=70> or </size><size=120>" + (i_points + 10).ToString() + "</size>";
        }

        if (turnManagare.isPlayerTurn)
        {
            return;
        }

        int i = 0;
        i_points = PointCalculator(_a_currentCards.ToArray());
        while (i_points > _minPoint)
        {
            if (i < 100) { return; }
            i++;
            _a_currentCards.Add(cardManager.PullCard().number);
        }
        turnManagare.SetTurnEnd();
    }
}
