using SuperHot.Core;
using SuperHot.Gameplay.BallBehaviours;

namespace SuperHot.Gameplay.Boosters
{
  public class BoosterFireball : Booster
  {
    public override void ConcreteActivate()
    {
      Main.Store.ballsBehaviour.Value = new FireballBehavior();
    }

    public override void ConcreteDeactivate()
    {
      Main.Store.ballsBehaviour.Value = new StandartBallBehavior();
    }
  }
}