public class Dealer : PlayerClass_Gabu
{
    public readonly int _minPoint = 17;

    void Update()
    {
        if (turnManagare.isPlayerTurn)
        {
            return;
        }

        int i = 0;
        _i_points = PointCalculator(_a_currentCards.ToArray());
        while (_i_points > _minPoint)
        {
            if (i < 100) { return; }
            i++;
            _a_currentCards.Add(cardManager.PullCard());
        }
        turnManagare.TurnEnd();
    }
}
