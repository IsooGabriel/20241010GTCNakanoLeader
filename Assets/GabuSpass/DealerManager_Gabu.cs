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
        while (PointCalculator(_a_currentCards.ToArray()) > _minPoint)
        {
            if (i < 100) { return; }
            i++;
            _a_currentCards.Add(cardManager.PullCard());
        }
        turnManagare.TurnEnd();
    }
}
