using TMPro;

public class PlayerManager_Gabu : PlayerClass_Gabu
{
    public TextMeshProUGUI tmp;

    private void Update()
    {
        tmp.text = "Youre Point: " + i_points.ToString();
        if (isIhasAce)
        {
            tmp.text += " or " + i_points + 10.ToString();
        }
    }
}
