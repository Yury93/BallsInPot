using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countResource;
    [SerializeField] private RewardSystem rewardSystem;
    [SerializeField] private Button startButton,startNoTime;
    [SerializeField] private ShopPanel shopPanel;
    [SerializeField] private GlobalGameSetting globalGameSetting;
    private void Start()
    {
        rewardSystem.Init();
        rewardSystem.GetGold.LoadCount();
        countResource.text = rewardSystem.GetGold.Count.ToString() + " золота";
        startButton.onClick.AddListener(SceneLoadScene);
        shopPanel.Init();
        startNoTime.onClick.AddListener(LoadClassic);
        //if (AudioSystem.instance &&  AudioSystem.isPlayAudio)
        //    AudioSystem.instance.SetActiveSounds();

        //YandexSDK.ShowAdv();
        
    }
    public void SceneLoadScene()
    {
        globalGameSetting.TimeMode = true;
        SceneLoader.LoadNextScene();
    }
    public void LoadClassic()
    {
        globalGameSetting.TimeMode = false;
        SceneLoader.LoadNextScene();
    }
    public void RefreshResourceInfo()
    {
        countResource.text = rewardSystem.GetGold.Count.ToString() + " золота";
    }
}
