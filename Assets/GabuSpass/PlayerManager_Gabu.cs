using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager_Gabu : PlayerClass_Gabu
{
    TextMeshProUGUI tmp;

    private void Update()
    {
        tmp.text = _i_points.ToString();
        if (isIhasAce)
        {
            tmp.text += " or " + _i_points + 10.ToString();
        }
    }
}
