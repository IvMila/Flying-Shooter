using UnityEngine;
using System.IO;

public class SaveManagerJSON : MonoBehaviour
{
    private string _saveFilePath => Path.Combine(Application.dataPath, "Saves/{0}.json");

    public void SavePurchasedObjects<T>(T data)
    {
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(string.Format(_saveFilePath, typeof(T).Name), json);
    }

    public T LoadPurchasedObjects<T>()
    {
        var filePath = string.Format(_saveFilePath, typeof(T).Name);
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonUtility.FromJson<T>(json);
        }

        return default;
    }
}
