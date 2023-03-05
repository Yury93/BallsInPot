using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FlyTextCreator : MonoBehaviour
{
    [SerializeField] private Transform content;
    [SerializeField] private GameObject prefabText;
    private static System.Random rng = new System.Random();
    public static FlyTextCreator Instance;
    public void Init()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    public void CreateText(Transform target, string text, float duration)
    {
        GameObject go = Create(target, text, duration);
    }
    private  GameObject Create(Transform target, string text, float duration)
    {
        GameObject go = Instantiate(prefabText, target);
        go.transform.position = Camera.main.WorldToScreenPoint(target.transform.position + Vector3.up * (3 + GetRandomSystem(0.2f, 3)));
        go.transform.SetParent(content);
        var seq = DOTween.Sequence();
        seq.Append(go.transform.DOMoveY(go.transform.position.y + 100, 3));
        go.GetComponent<TextMeshProUGUI>().text = text;
        var seq2 = DOTween.Sequence();

        //seq2.Append(go.GetComponent<TextMeshProUGUI>());
        //seq2.Append(go.GetComponent<TextMeshProUGUI>().DOFade(0, 3f));
        seq.OnComplete(() => GameObject.Destroy(go));

        return go;
    }
    public  float GetRandomSystem(float min, float max)
    {
        var randomDouble = min + (max - min) * rng.NextDouble();
        return Convert.ToSingle(randomDouble);
    }
    
}
