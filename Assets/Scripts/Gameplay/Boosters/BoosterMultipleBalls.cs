using UnityEngine;
using SuperHot.Core;

namespace SuperHot.Gameplay.Boosters
{
  public class BoosterMultipleBalls : Booster
  {
    public override void ConcreteActivate()
    {
      Main.Store.multipleBalls.Trigger();
    }

    public override void ConcreteDeactivate() { }
  }
}