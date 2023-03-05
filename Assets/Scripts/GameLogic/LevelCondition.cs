using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class LevelCondition : MonoBehaviour
{
    [SerializeField] private bool timeMode;
    [SerializeField] private int timer;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject timerPanel;
    [SerializeField] private PanelResult panelResult;
    [SerializeField] private TextMeshProUGUI helloText;
    [SerializeField] private GlobalGameSetting globalGameSetting;
    private List<Pot> pots;
    private Coroutine coroutine;
    public bool TimeMode => timeMode;
    public void Init(List<Pot> pots)
    {
        timeMode = globalGameSetting.TimeMode;
        this.pots = pots;
        timerPanel.gameObject.SetActive(false);
        if (timeMode)
        {
            Time.timeScale = 1;
            timerText.gameObject.SetActive(true);
            timerPanel.gameObject.SetActive(true);
            coroutine = StartCoroutine(CorTimer(timer));
        }
        panelResult.Init(pots);
    }

    IEnumerator CorTimer(float timer)
    {
        while (timer >= 0)
        {
            timerText.text = "Таймер: " + Convert.ToInt32(timer) + " секунд";
            timer -= 1;
            yield return new WaitForSeconds(1);
        }
        pots.ForEach(p => p.Balls.ForEach(b => b.BlockClick(true)));
        ShowResult(false);
    }
    public virtual void SetupResult()
    {
        bool isNotColorEquals = false;
        foreach (Pot pot in pots)
        {
             isNotColorEquals = pot.Balls.Any(b => b.BallProperty.Color != pot.Balls[0].BallProperty.Color);
            if(isNotColorEquals == true)
            {
                Debug.Log("Цвета всё еще не одинаковые");
                break;
            }
        }
        if (isNotColorEquals == true)
        {
            return;
        }
        Debug.Log("Победа!");
        if (coroutine!= null)
            StopCoroutine(coroutine);

        ShowResult(true);
    }

    
    private void ShowResult(bool result)
    {
        panelResult.Open(result);
    }
}
