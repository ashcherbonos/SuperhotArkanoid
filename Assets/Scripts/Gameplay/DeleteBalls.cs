using UnityEngine;
using SuperHot.Core;

namespace SuperHot.Gameplay
{
  public class DeleteBalls : MonoBehaviour
  {
    void OnCollisionEnter(Collision collision)
    {
      if (collision.gameObject.tag != Constants.tagBall) return;
      Destroy(collision.gameObject);
      Main.Store.ballsCount.Value--;
    }
  }
}