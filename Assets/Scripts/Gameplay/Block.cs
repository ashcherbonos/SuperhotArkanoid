using System.Collections;
using UnityEngine;
using SuperHot.Core;

namespace SuperHot
{
  public class Block : MonoBehaviour
  {
    [SerializeField] GameObject block;
    [SerializeField] GameObject derbis;
    [SerializeField] Collider collider;
    [SerializeField] Rigidbody rigidbody;

    void Start()
    {
      Main.Store.blocksCount.Value++;
    }

    void OnCollisionEnter(Collision collision)
    {
      CheckForCrush(collision.gameObject.tag);
    }

    void OnParticleCollision(GameObject other)
    {
      CheckForCrush(other.tag);
    }

    private void CheckForCrush(string otherColliderTag)
    {
      if (otherColliderTag != Constants.tagBall) return;
      Crush();
    }

    private void Crush()
    {
      Main.Store.blocksCount.Value--;
      block.SetActive(false);
      derbis.SetActive(true);
      Destroy(collider);
      Destroy(rigidbody);
      StartCoroutine(DestroySelfAfterDerbisFalls());
    }

    private IEnumerator DestroySelfAfterDerbisFalls()
    {
      yield return new WaitForSeconds(Constants.destroyBloksAfteColisionInSeconds);
      Destroy(gameObject);
    }
  }
}