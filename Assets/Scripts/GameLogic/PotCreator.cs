using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PotCreator 
{
    private Pot prefab;
    private int countPot;
    private Transform startTransform;

    public PotCreator(Pot prefab,int countPot ,Transform transform)
    {
        this.prefab = prefab;
        this.countPot = countPot;
        this.startTransform = transform;
    }
    public List<Pot> CreateListPot(PotProperty potProperty,float interval)
    {
        List<Pot> pots = new List<Pot>();
        float s = interval;
        for (int i = 0; i < countPot; i++)
        {
            Vector3 position = Vector3.zero;
            if (i==0) position = startTransform.position;
            else  position = pots.Last().transform.position + new Vector3( interval,0,0);
            var pot = GameObject.Instantiate(prefab, position, Quaternion.identity, startTransform);
            pot.Init(potProperty);
            pots.Add(pot);
        
        }
        return pots;
    }
}
