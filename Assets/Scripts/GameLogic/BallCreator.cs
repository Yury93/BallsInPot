using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCreator 
{
    private Ball prefabBall;
    private float offsetPointY;
    private int countPoints;
    public List<Vector3> PositionBalls { get; private set; }
    
    public BallCreator(Ball prefab,int countPoints)
    {
        prefabBall = prefab;
        PositionBalls = new List<Vector3>();
        offsetPointY = prefabBall.transform.localScale.y;
        this.countPoints = countPoints;
    }
    public List<Ball> CreateBalls(int countBall, Transform bottom)
    {
        List<Ball> balls = new List<Ball>();
        Create(countBall, bottom, balls);
        CreatePosition(bottom);
        SetupStartPositionBalls(balls);
        Debug.Log("Заблокировать шар при создании");
        //balls.ForEach(b => b.BlockClick(true));
        return balls;
    }
    private void SetupStartPositionBalls(List<Ball> balls)
    {
        int i = 0;
        foreach (var item in balls)
        {
            item.transform.position = PositionBalls[i];
            i++;
        }
    }
    private void CreatePosition(Transform bottom)
    {
        var vector = new Vector2(bottom.position.x, bottom.position.y);
        PositionBalls.Add(vector);
        for (int k = 1; k < countPoints; k++)
        {
            vector = new Vector2(bottom.position.x, vector.y + offsetPointY);
            PositionBalls.Add(vector);
        }
    }
    private void Create(int countBall, Transform bottom, List<Ball> balls)
    {
        for (int b = 0; b < countBall; b++)
        {
            var ball = GameObject.Instantiate(prefabBall, bottom);
            balls.Add(ball);
        }

        balls.ForEach(b => b.transform.SetParent(bottom));
    }
}
