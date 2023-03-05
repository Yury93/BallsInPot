using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RewardSystem : MonoBehaviour
{
    public class Gold
        {
        private int count;
        public int Count => count;
        public const string GOLD = "GOLD";
        public void LoadCount()
        {
            count = PlayerPrefs.GetInt(GOLD);
        }
        public void SaveCount()
        {
            PlayerPrefs.SetInt(GOLD, count);
        }
        public int AddReward(List<Pot> pots)
        {
            int reward = pots.Count;
            count += reward;
            SaveCount();
            return reward;
        }
    }
    public Gold GetGold { get; private set; }
    public static RewardSystem instance;
    public void Init()
    {
        GetGold = new Gold();
        GetGold.LoadCount();
        if(instance == null)
        {
            instance = this;
        }
    }


}
