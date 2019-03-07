using UnityEngine;

namespace SuperHot.Gameplay.BallBehaviours
{
  public interface IBallBehaviour
  {
    BallType ballType { get; }

    Vector3 VelocityAfterCollision(Vector3 rigidbodyVelocity, Collision collision);
  }
}