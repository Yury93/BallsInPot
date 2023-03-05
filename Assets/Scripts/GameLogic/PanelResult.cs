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
    [SerializeField] private Button restartButton, nextSceneButton,menuButton,rewardAdd;
    [SerializeField] private RewardSystem rewardSystem;
    List<Pot> pots;
    public void Init(List<Pot> pots)
    {
        restartButton.onClick.AddListener(() => SceneLoader.RestartScene());
        nextSceneButton.onClick.AddListener(() => SceneLoader.LoadNextScene());
        rewardAdd.gameObject.SetActive(false);
        rewardAdd.onClick.AddListener(AddRewards);
        rewardSystem.Init();
        this.pots = pots;
        nextSceneButton.gameObject.SetActive(false);
    }
    internal void Open(bool result)
    {
        gameObject.SetActive(true);
        if (result)
        {
            SetActiveRewardButton();
            resultText.text = "¬€ œŒ¡≈ƒ»À»!";
           
        }
        else
        {
            resultText.text = "¬€ œ–Œ»√–¿À»!";
            reward.SetActive(false);
            restartButton.gameObject.SetActive(true);
            nextSceneButton.gameObject.SetActive(false);
        }
        menuButton.gameObject.SetActive(false);
    }

    private void AddRewards()
    {
       
        rewardAdd.gameObject.SetActive(false);
        if (GameStarter.instance.GameSystem.LevelCondition.TimeMode)
        {
            var count = rewardSystem.GetGold.AddReward(pots);
            countRewardText.text = "+" + count.ToString();
        }
        else
        {
            var count = rewardSystem.GetGold.AddOneReward();
            countRewardText.text = "+" + count.ToString();
        }
        reward.SetActive(true);
        


        nextSceneButton.gameObject.SetActive(true);
    }

    private void SetActiveRewardButton()
    {
        restartButton.gameObject.SetActive(false);
        rewardAdd.gameObject.SetActive(true);
    }
}
