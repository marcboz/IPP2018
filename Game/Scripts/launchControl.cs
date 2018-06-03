﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launchControl : MonoBehaviour
{

  public GameObject bomb;
  float speed = 10;

  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    Plane playerPlane = new Plane(Vector3.up, transform.position);
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    float hitdist = 0.0f;
    if (playerPlane.Raycast(ray, out hitdist))
    {
      Vector3 targetPoint = ray.GetPoint(hitdist);

      Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
      transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
    }
  }
}
