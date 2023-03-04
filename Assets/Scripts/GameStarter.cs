using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private ClickRegister clickRegister;
    [SerializeField] private GameSystem gameSystem;
    [SerializeField] private List<Pot> pots;
    [SerializeField] private Transform contentPot;
    [SerializeField] private List<BallProperty> ballProperties;//их количество должно быть одинаково с количеством pots
    public Pot potPrefab;
    public int countPot;
    public PotProperty potProperty;
    public float interval;
    //количество проперти зависит от количества потов
    //после того как определённый цвет превысил лимит одного из пота удалять из списка проперти и назначать опять рандом
    void Start()
    {
        clickRegister.Init();
        PotCreator potCreator = new PotCreator(potPrefab, countPot, contentPot);

        pots = potCreator.CreateListPot(potProperty, interval);

     

        while (ballProperties.Count != 0)
        {
            foreach (var pot in pots)
            {
                var index = Random.Range(0, ballProperties.Count);
                if (ballProperties.Count == 0) break;
                var propertyRnd = ballProperties[index];
                var ballsSameColor = GetBallsSameColor(propertyRnd);

                if (pot.Property.LimitBalls-1 == ballsSameColor.Count)
                {
                    ballProperties.Remove(propertyRnd);

                }
                else
                {
                    var ballInit = pot.Balls.FirstOrDefault(b => b.IsPainted == false);
                    if(ballInit)
                    ballInit.Init(propertyRnd);
                }
            
            }
        }
         gameSystem.Init(pots);
        Debug.Log("Start game");
    }

    private List<Ball> GetBallsSameColor(BallProperty propertyRnd)
    {
        List<Ball> balls = new List<Ball>();
        foreach (var p in pots)
        {
            var listBall = p.Balls.Where(b => b.IsPainted && b.BallProperty.Color == propertyRnd.Color).ToList();
            if (listBall.Count > 0)
            {
                balls.AddRange(listBall);
            }
        }
        return balls;
    }
}
