using UnityEngine;
using SuperHot.Gameplay;
using SuperHot.Gameplay.BallBehaviours;

namespace SuperHot.Core
{
  /// <summary>
  /// Value class with globall acces for storing app-level data.
  /// (Only data. For logic, use Main.Model)
  /// Use Boxing to bind listeners to stored data:
  /// Main.Store.someFloat.Value = 42f;
  /// Main.Store.someFloat.Bind(s=>Debug.Log(s));
  /// </summary>
  public class Store
  {
    public Box<GameStatus> gameStatus = new Box<GameStatus>(GameStatus.Pause);
    public Box<bool> timeIsRuning = new Box<bool>(false);
    public Box<Transform> ballSpawner = new Box<Transform>(null);
    public Box<int> ballsCount = new Box<int>(0);
    public Box<int> ballsUsedInLevel = new Box<int>(0);
    public Box<int> blocksCount = new Box<int>(0);
    public Box<bool> shooting = new Box<bool>(false);
    public Box<Trigger> multipleBalls = new Box<Trigger>(Trigger.Trigger);
    public Box<IBallBehaviour> ballsBehaviour = new Box<IBallBehaviour>(new StandartBallBehavior());
    public Box<Trigger> newLevelStarted = new Box<Trigger>(Trigger.Trigger);
  }

  public enum GameStatus
  {
    Pause, Playing, Loose, Win
  }

  public enum Trigger
  {
    Trigger
  }
}