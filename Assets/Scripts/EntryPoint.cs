using UnityEngine;
using SuperHot.Core;
using SuperHot.Initialization;

namespace SuperHot
{
  public class EntryPoint : MonoBehaviour
  {
    void Awake()
    {
      Main.Store = new Store();
      new Initializator().InitScene();
      Main.Model = new Model();
      Main.Model.Start();
    }
  }
}
