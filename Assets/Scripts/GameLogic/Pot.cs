using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : Button3D
{
    [SerializeField] private Ball prefabBall;
    [SerializeField] private PotProperty property;
    [SerializeField] private List<Ball> balls;
    [SerializeField] private Transform bottom,top;
    [SerializeField] private Outline outline;
    public Color selectedColor, defaultColor;
    public Outline Outline => outline;
    public BallCreator BallCreator { get; private set; }
    public Transform Top => top;
    public Transform Bottom => bottom;
    public List<Ball> Balls => balls;
    public PotProperty Property => property;
    
    public void Init(PotProperty potProperty)
    {
        property = potProperty;
        BallCreator = new BallCreator(prefabBall,10);
        balls = BallCreator.CreateBalls(property.CountBalls, bottom);
       
    }
}
