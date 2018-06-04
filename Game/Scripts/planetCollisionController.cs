using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetCollisionController : MonoBehaviour
{
  gameController gameController;
  public int penalty = 2;

  void Start()
  {
    gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameController>();
  }
  void OnTriggerEnter(Collider other)
  {
    if (other.tag == "pulledBody")
    {
      gameController.cash -= penalty / 3;
      Destroy(other.gameObject);
    }
  }
}
