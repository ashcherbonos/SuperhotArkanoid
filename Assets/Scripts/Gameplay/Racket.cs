using UnityEngine;
using System.Collections.Generic;
using SuperHot.Core;

namespace SuperHot.Gameplay
{
  public class Racket : MonoBehaviour
  {
    private const float RIGHT = 1;
    private const float LEFT = -1;

    [SerializeField] Transform ballSpawner;
    [SerializeField] List<ParticleSystem> guns;

    private float AvaliableXPosition => (Constants.fieldWidth - Constants.racketWidth) / 2;
    private bool CanMoveRight => transform.position.x < AvaliableXPosition;
    private bool CanMoveLeft => transform.position.x > -AvaliableXPosition;
    private bool UserPushRight => Input.GetKey(KeyCode.RightArrow);
    private bool UserPushLeft => Input.GetKey(KeyCode.LeftArrow);

    public void Init()
    {
      Main.Store.ballSpawner.Value = ballSpawner;
      Main.Store.shooting.Bind(s => guns.Map(g => SwitchEmission(g.emission, s)));
    }

    void Update()
    {
      if (Main.Store.gameStatus.Value != GameStatus.Playing) return;

      if (UserPushRight && CanMoveRight)
      {
        Move(RIGHT);
        return;
      }

      if (UserPushLeft && CanMoveLeft)
      {
        Move(LEFT);
        return;
      }

      Main.Store.timeIsRuning.Value = false;
    }

    private void Move(float directionOfMovment)
    {
      float xTranslate = directionOfMovment * Constants.playerSpeed * Time.deltaTime;
      transform.Translate(xTranslate, 0, 0);
      Main.Store.timeIsRuning.Value = true;
    }

    private void SwitchEmission(ParticleSystem.EmissionModule emission, bool on)
    {
      emission.enabled = on;
    }
  }
}