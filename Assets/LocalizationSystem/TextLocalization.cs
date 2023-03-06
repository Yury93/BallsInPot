using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextLocalization : MonoBehaviour
{
    [SerializeField] string key, customPostfix, customPrefix;
    private Text text;
    private TextMeshProUGUI textPro;


    void Start()
    {
        text = GetComponent<Text>();
        if (text == null)
        {
            textPro = GetComponent<TextMeshProUGUI>();
        }
        Refresh();
        LocalizationSystem.Subscribe(Refresh);

    }
    private void OnDestroy()
    {
        LocalizationSystem.UnSubscribe(Refresh);
    }
    public void Refresh()
    {
        string totalText = LocalizationSystem.GetTranslate(key);
        if (text)
        {
            text.text = customPrefix + totalText + customPostfix;
        }
        else
        {
            textPro.text = customPrefix + totalText + customPostfix;
        }

    }
    [ContextMenu("ru test")]
    public void TestRuTranslate()
    {
        LocalizationSystem.ChangeLanguage(SystemLanguage.Russian);
    }
    [ContextMenu("eng test")]
    public void TestEngTranslate()
    {
        LocalizationSystem.ChangeLanguage(SystemLanguage.English);
    }
}
