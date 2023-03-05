using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelResult : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resultText,countRewardText;
    [SerializeField] private GameObject reward;
    [SerializeField] private Button restartButton, nextSceneButton,menuButton;
    [SerializeField] private RewardSystem rewardSystem;
    List<Pot> pots;
    public void Init(List<Pot> pots)
    {
        restartButton.onClick.AddListener(() => SceneLoader.RestartScene());
        nextSceneButton.onClick.AddListener(() => SceneLoader.LoadNextScene());
        rewardSystem.Init();
        this.pots = pots;
    }
    internal void Open(bool result)
    {
        gameObject.SetActive(true);
        if (result)
        {
            var count = rewardSystem.GetGold.AddReward(pots);
            countRewardText.text = "+"+count.ToString();
            resultText.text = "¬€ œŒ¡≈ƒ»À»!";
            reward.SetActive(true);
        }
        else
        {
            resultText.text = "¬€ œ–Œ»√–¿À»!";
            reward.SetActive(false);
        }
        menuButton.gameObject.SetActive(false);
    }
}
