using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countResource;
    [SerializeField] private RewardSystem rewardSystem;
    [SerializeField] private Button startButton;
    private void Start()
    {
        rewardSystem.Init();
        rewardSystem.GetGold.LoadCount();
        countResource.text = rewardSystem.GetGold.Count.ToString();
        startButton.onClick.AddListener(SceneLoadScene);
    }
    public void SceneLoadScene()
    {
        SceneLoader.LoadNextScene();
    }
}
