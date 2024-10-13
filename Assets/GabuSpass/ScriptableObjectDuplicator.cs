using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

public class ScriptableObjectDuplicator : MonoBehaviour
{
    // スプライトが保存されているフォルダ
    public string spriteFolderPath = "Assets/GabuSpass/Cards/";

    [ContextMenu("Generate ScriptableObjects From Sprites")]
    public void GenerateScriptableObjectsFromSprites()
    {
        // スプライトフォルダ内のすべてのファイルを取得
        string[] spriteFiles = Directory.GetFiles(spriteFolderPath, "*.png");

        foreach (string spriteFile in spriteFiles)
        {
            // スプライトファイル名を取得（拡張子なし）
            string fileName = Path.GetFileNameWithoutExtension(spriteFile);

            // スプライトファイル名を正規表現で解析 (例: Name00)
            Match match = Regex.Match(fileName, @"([A-Za-z]+)(\d+)$");

            if (match.Success)
            {
                // name と number を取得
                string newName = match.Groups[1].Value;
                string numberString = match.Groups[2].Value.TrimStart('0'); // 数字の先頭の0を削除
                int newNumber;

                if (int.TryParse(numberString, out newNumber))
                {
                    // スプライトを読み込む
                    Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(spriteFile);

                    if (sprite != null)
                    {
                        // ScriptableObjectを生成
                        CardScriptableObject newScriptableObject = ScriptableObject.CreateInstance<CardScriptableObject>();
                        newScriptableObject.name = newName;   // 名前をスプライト名に設定
                        newScriptableObject.number = newNumber;  // ファイル名の数字を設定
                        newScriptableObject.sprite = sprite;  // スプライトを設定

                        // 複製したScriptableObjectを保存 (ファイル名をスプライト名に基づいて生成)
                        string assetPath = Path.Combine("Assets/GeneratedScriptableObjects", fileName + ".asset");
                        AssetDatabase.CreateAsset(newScriptableObject, assetPath);
                        AssetDatabase.SaveAssets();

                        Debug.Log($"Created new ScriptableObject at {assetPath} with name {newName}, number {newNumber}");
                    }
                    else
                    {
                        Debug.LogError($"Failed to load sprite for {fileName}");
                    }
                }
            }
            else
            {
                Debug.LogWarning($"Sprite file {fileName} does not match the expected format 'Name00'. Skipping.");
            }
        }

        AssetDatabase.Refresh();
    }
}
