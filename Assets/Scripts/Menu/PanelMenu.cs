using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelMenu : Window
{
    [SerializeField] private TextMeshProUGUI countResource;
    [SerializeField] private Button continueButton, goToMenuButton;
    [SerializeField] private GameSystem gameSystem;
    public override void Open()
    {
        base.Open();
        
        foreach (var item in gameSystem.Pots)
        {
            item.BlockClick(true);
            foreach (var ball in item.Balls)
            {
                ball.BlockClick(true);
            }
        }
        Time.timeScale = 0.00001f;
        RewardSystem.instance.GetGold.LoadCount();
        countResource.text = RewardSystem.instance.GetGold.Count.ToString() + " золота" ;

        var globalAudio = AudioSystem.instance.globalAudioClips;
        AudioSystem.instance.CreateAuido(globalAudio.buttonClick);
    }
    public override void Close()
    {
        base.Close();
        foreach (var item in gameSystem.Pots)
        {
            item.BlockClick(false);
            foreach (var ball in item.Balls)
            {
                ball.BlockClick(false);
            }
        }
        Time.timeScale = 1f;

        var globalAudio = AudioSystem.instance.globalAudioClips;
        AudioSystem.instance.CreateAuido(globalAudio.buttonClick);
    }
    public void LoadSceneMenu()
    {
        SceneLoader.LoadMenu();
    }
}
