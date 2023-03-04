using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : Button3D
{
    public enum  State { top, bottom };
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private State state = State.bottom;
    public State StateBall => state;
    public BallProperty BallProperty { get; private set; }
    public bool IsPainted;
    public void Init(BallProperty ballProperty)
    {
        BallProperty = ballProperty;
        meshRenderer.material.color = ballProperty.Color;
        IsPainted = true;
    }
    public void SetState(State state)
    {
        this.state = state;
    }
}
