using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text.RegularExpressions;

public class ScriptableObjectDuplicator : MonoBehaviour
{
    // コピー元のScriptableObject
    public MyScriptableObject originalScriptableObject;

    // データファイルが保存されているフォルダ
    public string folderPath = "Assets/DataFiles/";

    // Spriteを保存するフォルダ
    public string spriteFolderPath = "Assets/Sprites/";

    [ContextMenu("Duplicate ScriptableObjects From Files")]
    public void DuplicateScriptableObjectsFromFiles()
    {
        // フォルダ内のすべてのファイルを取得
        string[] files = Directory.GetFiles(folderPath);

        foreach (string file in files)
        {
            // 拡張子を取り除いたファイル名を取得
            string fileName = Path.GetFileNameWithoutExtension(file);

            // ファイル名を正規表現で解析 (Name00 の形式を想定)
            Match match = Regex.Match(fileName, @"([A-Za-z]+)(\d+)$");

            if (match.Success)
            {
                // name と number を取得
                string newName = match.Groups[1].Value;
                string numberString = match.Groups[2].Value.TrimStart('0'); // 数字の先頭の0を削除
                int newNumber;

                if (int.TryParse(numberString, out newNumber))
                {
                    // Spriteファイルを探す (同じ名前の.pngファイルを想定)
                    string spritePath = Path.Combine(spriteFolderPath, newName + ".png");
                    Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(spritePath);

                    if (sprite != null)
                    {
                        // ScriptableObjectを複製
                        MyScriptableObject newScriptableObject = ScriptableObject.CreateInstance<MyScriptableObject>();
                        newScriptableObject.name = newName;
                        newScriptableObject.number = newNumber;
                        newScriptableObject.sprite = sprite;

                        // 複製したScriptableObjectを保存
                        string assetPath = Path.Combine("Assets/GeneratedScriptableObjects", fileName + ".asset");
                        AssetDatabase.CreateAsset(newScriptableObject, assetPath);
                        AssetDatabase.SaveAssets();

                        Debug.Log($"Created new ScriptableObject at {assetPath} with name {newName}, number {newNumber}");
                    }
                    else
                    {
                        Debug.LogError($"No sprite found for {newName} at {spritePath}");
                    }
                }
            }
            else
            {
                Debug.LogWarning($"File {fileName} does not match the expected format 'Name00'. Skipping.");
            }
        }

        AssetDatabase.Refresh();
    }
}