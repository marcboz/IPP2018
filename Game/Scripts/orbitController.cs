using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbitController : MonoBehaviour
{

  public GameObject planet;
  public float orbitDegreesPerSec = 1;

  void Update()
  {
    transform.RotateAround(planet.transform.position, Vector3.up, -1 * orbitDegreesPerSec * Time.deltaTime);
  }
}
