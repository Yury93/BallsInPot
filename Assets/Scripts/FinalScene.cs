using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class FinalScene : MonoBehaviour
{
    [SerializeField] private Button button;
    Sequence sequence;
    void Start()
    {
        sequence = DOTween.Sequence();
        sequence.Append(button.gameObject.transform.DOScale(new Vector3(1.5f, 1.5f, 1), 1))
            .Append(button.gameObject.transform.DOScale(new Vector3(1f, 1f, 1), 1))
            .Append(button.gameObject.transform.DOScale(new Vector3(1.5f, 1.5f, 1), 1))
            .Append(button.gameObject.transform.DOScale(new Vector3(1f, 1f, 1), 1))
            .AppendCallback(() => sequence.Kill());
        button.onClick.AddListener(() => SceneLoader.LoadMenu());
    }
    private void OnDestroy()
    {
        if(sequence != null)
        sequence.Kill();
    }


}
