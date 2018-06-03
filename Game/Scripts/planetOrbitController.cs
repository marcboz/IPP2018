using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetOrbitController : MonoBehaviour
{

  GameObject sun;
  public float orbitDegreesPerSec = 1;
  void Start()
  {
    sun = GameObject.FindGameObjectWithTag("sun");
  }

  void Update()
  {
    transform.RotateAround(sun.transform.position, Vector3.up, -1 * orbitDegreesPerSec * Time.deltaTime);
  }
}
