using UnityEngine;

[CreateAssetMenu(fileName = "NewMyScriptableObject", menuName = "ScriptableObjects/MyScriptableObject", order = 1)]
public class CardScriptableObject : ScriptableObject
{
    public string name;    // 名前
    public int number;     // 数字
    public Sprite sprite;  // 画像
}
