using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ball", menuName = "Property/Ball")]
public class BallProperty : ScriptableObject
{
    [SerializeField] private Color color;
    public Color Color => color;
}
