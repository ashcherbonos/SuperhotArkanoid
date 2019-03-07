using UnityEngine;
using UnityEngine.UI;
using SuperHot.Core;
using SuperHot.Gameplay;

namespace SuperHot.Initialization
{
  public class Initializator
  {
    public void InitScene()
    {
      InitCameraRig();
      InitUI();
      InitEnvironment();
      InitPlayer();
    }

    private void InitCameraRig()
    {
      Loader.Instantiate<GameObject>(AddressableNames.CameraRig);
    }

    private void InitUI()
    {
      Loader.Instantiate<GameObject>(AddressableNames.UI);
    }

    private void InitEnvironment()
    {
      Loader.Instantiate<GameObject>(AddressableNames.Environment);
    }

    private void InitPlayer()
    {
      Loader.Instantiate<Racket>(AddressableNames.Player).Init();
    }
  }
}
