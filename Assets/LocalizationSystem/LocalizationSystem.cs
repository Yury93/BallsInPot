using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LocalizationSystem : MonoBehaviour
{
    public static SystemLanguage language { get; private set; }
    public static List<LocalisationEntity> localisations;
    private static string lastErrorKey = "";
    public static Dictionary<string, string> dictionary = new Dictionary<string, string>();
    private static List<System.Action> subscribers = new List<System.Action>();
    public static void Init(List<LocalisationEntity> structs)
    {
        localisations = structs;
        Config.localisation = structs;
        subscribers.Clear();

        if (PlayerPrefs.HasKey("Language"))
        {

            string lang = PlayerPrefs.GetString("Language");
            language = lang.ToEnum<SystemLanguage>();
        }
        else
        {
            //  language = SystemLanguage.English;
            language = Application.systemLanguage;
        }
        LoadLanguage(language);

    }
    public static void ChangeLanguage(SystemLanguage lang)
    {
        LoadLanguage(lang);
        PlayerPrefs.SetString("Language", lang.ToString());
        language = lang;
        Refresh();
    }
    public static void Refresh()
    {

        subscribers = subscribers.Where(s => s != null).ToList();
        for (int i = 0; i < subscribers.Count; i++)
        {
            if (subscribers[i] == null)
            {
                subscribers.Remove(subscribers[i]);
                i--;
            }
            else
            {
                subscribers[i]?.Invoke();
            }
        }
    }
    private static void LoadLanguage(SystemLanguage lang)
    {
        var text = Resources.Load<TextAsset>("ConfigFiles/Localisation").text;

        var list = CSVSerializer.ParseCSV(text, ',');
        var total = CSVSerializer.Deserialize<LocalisationEntity>(list);
        dictionary.Clear();
        foreach (var item in total)
        {
            if (lang == SystemLanguage.Russian) dictionary.Add(item.key, item.russian);
            else
                //  if (lang == SystemLanguage.English) 
                dictionary.Add(item.key, item.english);


        }

    }
    public static string GetTranslate(string keyWord)
    {
        if (string.IsNullOrEmpty(keyWord)) return "";
        string local = "";
        if (dictionary.TryGetValue(keyWord, out local))
        {
            return local;
        }
        if (lastErrorKey != keyWord) Log($"TRANSLATE: ({keyWord}) of language ({language}) not found");
        lastErrorKey = keyWord;
        return keyWord;

    }

    public static void Subscribe(System.Action callback)
    {
        subscribers.Add(callback);
    }
    public static void UnSubscribe(System.Action callback)
    {
        subscribers.Remove(callback);
    }
    private static void Log(string text)
    {

       Debug.Log(ColorizeText(text, Color.yellow));
    }
    public static string ColorizeText(string text, Color color)
    {
        string prefix = $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>";
        string post = "</color>";

        return prefix + text + post;
    }
   
}
public static class Methods
{
    public static T ToEnum<T>(this string self)
    {
        return (T)Enum.Parse(typeof(T), self);


    }
}
