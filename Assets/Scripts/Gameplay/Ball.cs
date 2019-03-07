using UnityEngine;
using SuperHot.Core;
using SuperHot.Gameplay.BallBehaviours;

namespace SuperHot.Gameplay
{
  public enum BallType
  {
    standart,
    fireball
  }

  public class Ball : MonoBehaviour
  {
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] GameObject standartGameObject;
    [SerializeField] GameObject fireballGameObject;

    private Vector3 direction;
    private IBallBehaviour ballBehaviour = new StandartBallBehavior();

    void Start()
    {
      Main.Store.ballsCount.Value++;
      Main.Store.multipleBalls.LazyBind(s =>
      {
        CloneSelf().DeflectVelocityVector(45);
        CloneSelf().DeflectVelocityVector(-45);
      });
      Main.Store.ballsBehaviour.Bind(s => SetBallBehaviour(s));
    }

    void OnCollisionEnter(Collision collision)
    {
      SetVelocity(ballBehaviour.VelocityAfterCollision(rigidbody.velocity, collision));
      CorrectReflection();
    }

    void OnCollisionExit(Collision collision)
    {
      CorrectReflection();
    }

    public void SetInitialVelocity()
    {
      SetVelocity(Vector3.forward);
    }

    private void SetBallBehaviour(IBallBehaviour ballBehaviour)
    {
      this.ballBehaviour = ballBehaviour;
      SwitchGameObjects(ballBehaviour.ballType);
    }

    private void SwitchGameObjects(BallType ballType)
    {
      standartGameObject.SetActive(ballType == BallType.standart);
      fireballGameObject.SetActive(ballType == BallType.fireball);
    }

    private Ball CloneSelf()
    {
      GameObject newBallGO = Instantiate(gameObject);
      newBallGO.transform.position = transform.position;
      Ball newBall = newBallGO.GetComponent<Ball>();
      newBall.SetVelocity(rigidbody.velocity);
      return newBall;
    }

    private void DeflectVelocityVector(float angle)
    {
      SetVelocity(Quaternion.AngleAxis(angle, Vector3.up) * rigidbody.velocity);
    }

    private void SetVelocity(Vector3 direction)
    {
      rigidbody.velocity = direction.normalized * Constants.ballSpeed;
    }

    private void CorrectReflection()
    {
      Vector3 movementDirection = rigidbody.velocity.normalized;
      PreventInfinityHorizontalMovement(ref movementDirection);
      PreventSlidingOnSideWalls(ref movementDirection);
      SetVelocity(movementDirection);
    }

    private void PreventInfinityHorizontalMovement(ref Vector3 direction)
    {
      direction.z = SetMinVelocityComponent(direction.z);
    }

    private void PreventSlidingOnSideWalls(ref Vector3 direction)
    {
      direction.x = SetMinVelocityComponent(direction.x);
    }

    private float SetMinVelocityComponent(float velocityComponent)
    {
      if (Mathf.Abs(velocityComponent) < Constants.minimumVelocityComponent)
      {
        velocityComponent = Constants.minimumVelocityComponent * Mathf.Sign(velocityComponent);
      }
      return velocityComponent;
    }
  }
}
