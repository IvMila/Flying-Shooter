using UnityEngine;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
public static class SaveManager
{
    //private static string _saveFilePath = "saveData.json";

    //public static void SaveTests(ShopScriptableObject[] tests)
    //{
    //    string json = JsonUtility.ToJson(tests);
    //    File.WriteAllText(_saveFilePath, json);
    //    Debug.Log("Save JSON: " + json);

    //}

    public static void SaveToJson<T>(List<T> toSave, string fileName)
    {
        Debug.Log(GetPath(fileName));
        string content = JsonHelper.ToJson<T>(toSave.ToArray());
        WriteFile(GetPath(fileName), content);
    }

    public static List<T> ReadFromToJson<T>(string fileName)
    {
        string content = ReadFile(fileName);

        if(string.IsNullOrEmpty(content) || content == "{}")
        {
            return new List<T>();
        }

        List<T> res = JsonHelper.FromJson<T>(content).ToList();

        return res;
    }
    private static string GetPath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
    }

    private static void WriteFile(string path, string content)
    {
        FileStream fileStream = new FileStream(path, FileMode.Create);
        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(content);
        }
    }

    private static string ReadFile(string path)
    {
        if(File.Exists(path))
        {
            using(StreamReader reader = new StreamReader(path))
            {
                string content = reader.ReadToEnd();
                return content;
            }
        }
        return "";
    }

    //public static ShopScriptableObject[] LoadTest()
    //{
    //    if (File.Exists(_saveFilePath))
    //    {
    //        string json = File.ReadAllText(_saveFilePath);
    //        Debug.Log("Load JSON: " + json);

    //        return JsonUtility.FromJson<ShopScriptableObject[]>(json);
    //    }
    //    else return new ShopScriptableObject[0];
    //}
}

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}
