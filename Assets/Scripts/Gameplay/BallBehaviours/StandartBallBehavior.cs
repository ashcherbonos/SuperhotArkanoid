using UnityEngine;

namespace SuperHot.Gameplay.BallBehaviours
{
  public class StandartBallBehavior : IBallBehaviour
  {
    public BallType ballType { get { return BallType.standart; } }

    public Vector3 VelocityAfterCollision(Vector3 rigidbodyVelocity, Collision collision)
    {
      // collision as usual
      return rigidbodyVelocity;
    }
  }
}