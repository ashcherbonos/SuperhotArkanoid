using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperHot.Core
{
  public class Loader
  {
    public static T Load<T>(string name) where T : UnityEngine.Object
    {
      return Resources.Load<T>(name);
    }

    public static T Instantiate<T>(string name) where T : UnityEngine.Object
    {
      return MonoBehaviour.Instantiate(Load<T>(name));
    }
  }
}
