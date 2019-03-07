using System.Collections;
using UnityEngine;

namespace SuperHot.Gameplay.Boosters
{
  public abstract class Booster : MonoBehaviour
  {
    public abstract void ConcreteActivate();
    public abstract void ConcreteDeactivate();

    private bool isActive = false;

    public bool ActivateIfCan()
    {
      if (isActive) return false;

      ConcreteActivate();
      StartCoroutine(Deactivate());
      isActive = true;
      return true;
    }

    private IEnumerator Deactivate()
    {
      yield return new WaitForSeconds(Constants.boosterTime);
      ConcreteDeactivate();
      isActive = false;
    }
  }
}
