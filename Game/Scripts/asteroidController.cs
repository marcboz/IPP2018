using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidController : MonoBehaviour
{

  public float maxVelocity = 1;
  public float offset = 0.2f;

  void Start()
  {
    if (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<cameraController>().GetLockTag() == "earth")
    {
      Vector3 direction = new Vector3(
        GameObject.FindGameObjectWithTag("earth").transform.position.x - transform.position.x,
        0.0f,
        GameObject.FindGameObjectWithTag("earth").transform.position.z - transform.position.z
      ).normalized;
      GetComponent<Rigidbody>().velocity = new Vector3(Random.Range((direction.x - offset) * maxVelocity, (direction.x + offset) * maxVelocity), 0.0f, Random.Range((direction.z - offset) * maxVelocity, (direction.z + offset) * maxVelocity));
    }
    if (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<cameraController>().GetLockTag() == "mars")
    {
      Vector3 direction = new Vector3(
        GameObject.FindGameObjectWithTag("mars").transform.position.x - transform.position.x,
        0.0f,
        GameObject.FindGameObjectWithTag("mars").transform.position.z - transform.position.z
      ).normalized;
      GetComponent<Rigidbody>().velocity = new Vector3(Random.Range((direction.x - offset) * maxVelocity, (direction.x + offset) * maxVelocity), 0.0f, Random.Range((direction.z - offset) * maxVelocity, (direction.z + offset) * maxVelocity));
    }
  }
}
