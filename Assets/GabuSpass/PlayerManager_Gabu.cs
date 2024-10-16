using TMPro;

public class PlayerManager_Gabu : PlayerClass_Gabu
{
    public TextMeshProUGUI tmp;

    private void Update()
    {
        tmp.text = "<size=70>Youre Point: </size><size=120>" + i_points.ToString() + "</size>";
        if (isIhasAce)
        {
            tmp.text += "<size=70> or </size><size=120>" + (i_points + 10).ToString() + "</size>";
        }
    }
}
