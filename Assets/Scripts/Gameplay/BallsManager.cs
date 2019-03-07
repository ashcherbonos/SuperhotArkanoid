using System.Collections.Generic;
using UnityEngine;
using SuperHot.Core;

namespace SuperHot.Gameplay
{
  public class BallsManager
  {
    public BallsManager()
    {
      Main.Store.ballsCount.LazyBind(count =>
      {
        if (count > 0) return;
        if (Main.Store.ballsUsedInLevel.Value >= Constants.ballsPerLevel)
        {
          Main.Store.gameStatus.Value = GameStatus.Loose;
          return;
        }
        SpawnBall();
      });
    }

    public void SpawnBall()
    {
      Main.Store.ballsUsedInLevel.Value++;
      var ballGO = Loader.Instantiate<GameObject>(AddressableNames.Ball);
      ballGO.transform.position = Main.Store.ballSpawner.Value.position;
      Ball ball = ballGO.GetComponent<Ball>();
      ball.SetInitialVelocity();
    }
  }
}
