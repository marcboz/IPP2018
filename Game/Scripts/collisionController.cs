using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionController : MonoBehaviour
{
  public ParticleSystem explosion;
  gameController gameController;
  public float reward = 5;

  void Start()
  {
    gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameController>();
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.tag == "pulledBody")
    {
      Destroy(other.gameObject);
      gameController.cash += reward / 2;
    }
    ParticleSystem explosionInstance = Instantiate(explosion, transform.position, Quaternion.identity);
    explosionInstance.Play();
    Destroy(explosionInstance.gameObject, 3f);
    Destroy(this.gameObject);
  }
}
