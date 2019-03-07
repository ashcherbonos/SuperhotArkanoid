using SuperHot.Core;

namespace SuperHot.Gameplay.Boosters
{
  public class BoosterMachineGun : Booster
  {
    public override void ConcreteActivate()
    {
      Main.Store.shooting.Value = true;
    }

    public override void ConcreteDeactivate()
    {
      Main.Store.shooting.Value = false;
    }
  }
}