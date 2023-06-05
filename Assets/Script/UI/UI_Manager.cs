using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    [Header("Player")]
    [SerializeField]
    private Player player;
    
    [Header("Pause")]
    [SerializeField]
    private GameObject pauseGroup;
    [SerializeField]
    private GameObject pause;
    [SerializeField]
    private Transform endPos;

    [Header("BossHelp")]
    [SerializeField]
    private GameObject bossHelpPanel;

    public void GoBattleStage()
    {
        SceneManager.LoadScene(1);
    }

    public void GoMainScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseGroup.gameObject.SetActive(true);
        //LeanTween.move(pause, endPos, 0.5f);
    }

    public void Unpause()
    {
        pauseGroup.gameObject.SetActive(false);
        Time.timeScale = 1;
    }


    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void HelpOn()
    {
        bossHelpPanel.gameObject.SetActive(true);
    }

    public void HelpOff()
    {
        bossHelpPanel.gameObject.SetActive(false);
    }

}
