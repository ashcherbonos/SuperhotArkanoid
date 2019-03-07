using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SuperHot.Core;

namespace SuperHot.UI
{
  public class UiManager : MonoBehaviour
  {
    [SerializeField] GameObject HUD;
    [SerializeField] GameObject looseLabel;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject pauseLabel;
    [SerializeField] GameObject menuPanel;
    [SerializeField] List<GameObject> ballsCounterUI;
    [SerializeField] Text blocksCounter;

    void Start()
    {
      Main.Store.ballsUsedInLevel.Bind(s => ballsCounterUI.Map((i, b) => b.SetActive(i < (s - 1))));
      Main.Store.gameStatus.Bind(s =>
      {
        HUD.SetActive(s == GameStatus.Playing);
        looseLabel.SetActive(s == GameStatus.Loose);
        winLabel.SetActive(s == GameStatus.Win);
        pauseLabel.SetActive(s == GameStatus.Pause);
        menuPanel.SetActive(s != GameStatus.Playing);
      });
      Main.Store.blocksCount.Bind(s => blocksCounter.text = s.ToString());
    }

    public void Pause()
    {
      Main.Store.gameStatus.Value = GameStatus.Pause;
    }

    public void Play()
    {
      Main.Store.gameStatus.Value = GameStatus.Playing;
    }

    public void LoadLevel(int id)
    {
      Main.Store.levelID.SetAndTriger(id);
    }
  }
}