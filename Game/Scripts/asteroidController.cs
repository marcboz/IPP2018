using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidController : MonoBehaviour
{

  public float maxVelocity = 10;

  void Start()
  {
    GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(0, maxVelocity), 0.0f, Random.Range(0, maxVelocity));
    Debug.Log(GetComponent<Rigidbody>());
  }
}
