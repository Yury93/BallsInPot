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
        sq = DOTween.Sequence();
        sq.Append(text.transform.DOMoveY(transforms[1].position.y, 2)) 
        .AppendCallback(() => DestroyGO());
 
    }

    public void DestroyGO()
    {
        StartCoroutine(CorColorText());
        IEnumerator CorColorText()
        {
            yield return new WaitForSecondsRealtime(2f);
            Color color = text.color;
            while (color.a >0)
            {
                color = new Color(color.r, color.g, color.b, color.a -0.01f);
                text.color = color;
                yield return null;
            }
            Destroy(gameObject, 1);
        }
        sq.Kill();

    }
}
