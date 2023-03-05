using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
public class TutorialSystem : MonoBehaviour
{
    // уд :))))))))
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private List<Transform> transforms;
    Sequence sq;
    void Start()
    {
        List<Vector3> vectors = new List<Vector3>();
        transforms.ForEach(t => vectors.Add(t.position));
        sq.Append(text.transform.DOPath(vectors.ToArray(), 10));
    }
}
