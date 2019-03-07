using UnityEngine;

namespace SuperHot.Gameplay.BallBehaviours
{
  public class FireballBehavior : IBallBehaviour
  {
    public BallType ballType { get { return BallType.fireball; } }

    public Vector3 VelocityAfterCollision(Vector3 rigidbodyVelocity, Collision collision)
    {
      // fireball don't reflected by the blocks
      return collision.gameObject.tag == Constants.tagBlock ? -collision.relativeVelocity : rigidbodyVelocity;
    }
  }
}