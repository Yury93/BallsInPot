using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    [SerializeField] private LevelCondition levelCondition;
    public LevelCondition LevelCondition => levelCondition;
    private List<Ball> balls;
    public List<Pot> Pots { get; private set; }

    private Ball ballTop;
    private Coroutine moveCoroutine;
    private bool isProcessCoroutine;

    public void Init(List<Pot> pots)
    {
        balls = new List<Ball>();
        Pots = pots;
        levelCondition.Init(pots);
        foreach (var pot in Pots)
        {
            balls.AddRange(pot.Balls);
        }
      
        balls.ForEach(b => b.OnSelect += SelectBall);
        pots.ForEach(p => p.OnSelect += SelectPot);
    }

    private void SelectPot(Button3D button)
    {
        if (isProcessCoroutine) return;
        var selectePot = button as Pot;
        var hasStateBallTop = selectePot.Balls.Any(b => b == ballTop);// если в этой колбе есть выбранный шарик вверху
        if (hasStateBallTop)
        {
            //шарик отправляется в эту же колбу
            ReturnBallInPot(selectePot);
            ShowOutlinePots(false);
        }
        else if(ballTop)
        {
            //шарик сначала становится на точку к новому овнеру, а потом заполняет новую пустую точку этого овнера
            if (selectePot.Property.LimitBalls > selectePot.Balls.Count)
            {
                var ownerPot = Pots.First(p => p.Balls.Any(b => b == ballTop));
                ownerPot.Balls.Remove(ballTop);
                if (moveCoroutine == null)
                    moveCoroutine = StartCoroutine(CorMoveToPoints(ballTop, selectePot));
                ShowOutlinePots(false);
            }
            else
            {
                FlyTextCreator.Instance.CreateText(selectePot.transform, "Эта колба заполнена", 2);
            }
        }
        else
        {
            //шарик поднимается вверх 
            if (selectePot.Balls.Count == 0) return;
            ShowOutlinePots(true);
            ballTop = selectePot.Balls.Last();
            ballTop.SetState(Ball.State.top);
            if(moveCoroutine == null)
            moveCoroutine = StartCoroutine(CorMoveToPoint(ballTop, selectePot.Top.position));
        }

    }

    private void SelectBall(Button3D button)
    {
        if (isProcessCoroutine) return;
        var ball = button as Ball;
        ballTop = ball;
        if (ball.StateBall == Ball.State.bottom) return;

        var pot = Pots.Last(p => p.Balls.Any(b => b == ball));
        if (ball)
        {
            //шарик отправляется в эту же колбу
            ShowOutlinePots(false);
            ReturnBallInPot(pot);
        }
    }

    private void ReturnBallInPot(Pot pot)
    {
        var vectorReturn = pot.BallCreator.PositionBalls[pot.Balls.IndexOf(ballTop)];
        if (moveCoroutine == null)
            moveCoroutine = StartCoroutine(CorMoveToPoint(ballTop, vectorReturn));

        ballTop.SetState(Ball.State.bottom);
        ballTop = null;

        ShowOutlinePots(false);
    }

    private void ShowOutlinePots(bool result)
    {
        foreach (var pot in Pots)
        {
            pot.Outline.enabled = result;
            
        }
   
    }

    IEnumerator CorMoveToPoint(Ball ball, Vector3 newPosition)
    {
        isProcessCoroutine = true;
        while(ball.transform.position != newPosition)
        {
            ball.transform.position = Vector3.MoveTowards(ball.transform.position, newPosition,0.09f);
            yield return null;
        }
        isProcessCoroutine = false;
        moveCoroutine = null;
    }
    IEnumerator CorMoveToPoints(Ball ball, Pot potNewOwner)
    {
        isProcessCoroutine = true;
        ball.SetState(Ball.State.bottom);
        while (ball.transform.position != potNewOwner.Top.position)
        {
            ball.transform.position = Vector3.MoveTowards(ball.transform.position, potNewOwner.Top.position, 0.1f);
            yield return null;
        }
        potNewOwner.Balls.Add(ball);
        var lastBall = potNewOwner.Balls.LastOrDefault();
        Vector3 newPosition = potNewOwner.BallCreator.PositionBalls[0];
        if (lastBall)
        {
            int index = potNewOwner.Balls.IndexOf(lastBall);
            newPosition = potNewOwner.BallCreator.PositionBalls[index ];
         }

        while (ball.transform.position != newPosition)
        {
            ball.transform.position = Vector3.MoveTowards(ball.transform.position, newPosition, 0.09f);
            yield return null;
        }
        ball.transform.SetParent(potNewOwner.Bottom);
       
        ballTop = null;
        levelCondition.SetupResult();
        isProcessCoroutine = false;
        moveCoroutine = null;
    }

}
