using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text.RegularExpressions;

public class ScriptableObjectDuplicator : MonoBehaviour
{
    // �R�s�[����ScriptableObject
    public MyScriptableObject originalScriptableObject;

    // �f�[�^�t�@�C�����ۑ�����Ă���t�H���_
    public string folderPath = "Assets/DataFiles/";

    // Sprite��ۑ�����t�H���_
    public string spriteFolderPath = "Assets/Sprites/";

    [ContextMenu("Duplicate ScriptableObjects From Files")]
    public void DuplicateScriptableObjectsFromFiles()
    {
        // �t�H���_���̂��ׂẴt�@�C�����擾
        string[] files = Directory.GetFiles(folderPath);

        foreach (string file in files)
        {
            // �g���q����菜�����t�@�C�������擾
            string fileName = Path.GetFileNameWithoutExtension(file);

            // �t�@�C�����𐳋K�\���ŉ�� (Name00 �̌`����z��)
            Match match = Regex.Match(fileName, @"([A-Za-z]+)(\d+)$");

            if (match.Success)
            {
                // name �� number ���擾
                string newName = match.Groups[1].Value;
                string numberString = match.Groups[2].Value.TrimStart('0'); // �����̐擪��0���폜
                int newNumber;

                if (int.TryParse(numberString, out newNumber))
                {
                    // Sprite�t�@�C����T�� (�������O��.png�t�@�C����z��)
                    string spritePath = Path.Combine(spriteFolderPath, newName + ".png");
                    Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(spritePath);

                    if (sprite != null)
                    {
                        // ScriptableObject�𕡐�
                        MyScriptableObject newScriptableObject = ScriptableObject.CreateInstance<MyScriptableObject>();
                        newScriptableObject.name = newName;
                        newScriptableObject.number = newNumber;
                        newScriptableObject.sprite = sprite;

                        // ��������ScriptableObject��ۑ�
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