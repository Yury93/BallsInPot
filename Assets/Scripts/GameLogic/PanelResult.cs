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
        foreach (var item in pots)
        {
            item.BlockClick(true);
            item.Balls.ForEach(b => b.BlockClick(true));
        }
        gameObject.SetActive(true);
        if (result)
        {
            SetActiveRewardButton();
            resultText.text = "¬€ œŒ¡≈ƒ»À»!";

            var globalAudio = AudioSystem.instance.globalAudioClips;
            AudioSystem.instance.CreateAuido(globalAudio.win);
        }
        else
        {
            resultText.text = "¬€ œ–Œ»√–¿À»!";
            reward.SetActive(false);
            restartButton.gameObject.SetActive(true);
            nextSceneButton.gameObject.SetActive(false);

            var globalAudio = AudioSystem.instance.globalAudioClips;
            AudioSystem.instance.CreateAuido(globalAudio.los);
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

        var globalAudio = AudioSystem.instance.globalAudioClips;
        AudioSystem.instance.CreateAuido(globalAudio.addReward);

        nextSceneButton.gameObject.SetActive(true);
    }

    private void SetActiveRewardButton()
    {
        restartButton.gameObject.SetActive(false);
        rewardAdd.gameObject.SetActive(true);

        var globalAudio = AudioSystem.instance.globalAudioClips;
        AudioSystem.instance.CreateAuido(globalAudio.buttonClick);
    }
}
