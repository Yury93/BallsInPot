using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Pot",menuName = "Property/Pot")]
public class PotProperty : ScriptableObject
{
    [SerializeField] private int countBalls;
    [Header("������ ���� ������ �� 1 ��� ������ ��� ���������� ����������� ������")]
    [SerializeField] private int limitBalls;
    public int CountBalls => countBalls;
    public int LimitBalls => limitBalls;
   
}
