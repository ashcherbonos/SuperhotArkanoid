using UnityEngine;
using SuperHot.Gameplay;
using UnityEngine.SceneManagement;

namespace SuperHot.Core
{
  /// <summary>
  /// App-level dataless business logic.
  /// (For data storing, use Main.Store)
  /// </summary>
  public class Model
  {
    private BallsManager ballsManager;
    private int CurrentLevel
    {
      get { return PlayerPrefs.GetInt(Constants.currentLevelKey, 0); }
      set { PlayerPrefs.SetInt(Constants.currentLevelKey, value); }
    }

    public Model()
    {
      ballsManager = new BallsManager();
      Main.Store.timeIsRuning.Bind(s => Time.timeScale = s ? 1 : 0);
      Main.Store.gameStatus.Bind(s => { if (s != GameStatus.Playing) Time.timeScale = 0; });
      Main.Store.blocksCount.LazyBind(s => { if (s == 0) Main.Store.gameStatus.Value = GameStatus.Loose; });
      Main.Store.levelID.LazyBind(s =>
      {
        CurrentLevel = s;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      });
    }

    public void Start()
    {
      Main.Store.gameStatus.Value = GameStatus.Playing;
      Loader.Instantiate<GameObject>(AddressableNames.Levels[CurrentLevel]);
      ballsManager.SpawnBall();
    }
  }
}
