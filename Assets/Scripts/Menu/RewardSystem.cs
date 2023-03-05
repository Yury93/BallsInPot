using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardSystem : MonoBehaviour
{
    [SerializeField] private Image imageGold;
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
        public int AddOneReward()
        {
            count += 1;
            SaveCount();
            return 1;
        }
        public void TakeResource(int price)
        {
            count -= price;
            SaveCount();
        }
        public void AddGold()
        {
            count += 10;
            SaveCount();
        }

    }
    public Gold GetGold { get; private set; }
    public static RewardSystem instance;
    public void Init()
    {
        GetGold = new Gold();
        if(MenuLibrary.instance)
        imageGold.sprite = MenuLibrary.instance.GlobalSprites.spriteGold;
        GetGold.LoadCount();
        if(instance == null)
        {
            instance = this;
        }
    }
    [ContextMenu("днаюбхрэ гнкнрю")]

    public void Context_AddGold()
    {
        GetGold.AddGold();
    }
}
