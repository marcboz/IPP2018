using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour
{

  Rigidbody planetRb;
  public float maxGravityDistance = 10;
  public float gravityMultiplier = 1;
  void Start()
  {
    planetRb = GetComponent<Rigidbody>();
  }

  float calculateForce(float bigMass, float smallMass, float distance, float multiplier)
  {
    return (6.68f * ((bigMass * smallMass) / (distance * distance))) * multiplier;
  }
  void Update()
  {
    foreach (GameObject body in GameObject.FindGameObjectsWithTag("pulledBody"))
    {
      if (Vector3.Distance(body.transform.position, transform.position) <= maxGravityDistance)
      {
        body.GetComponent<Rigidbody>().AddForce(new Vector3(
          transform.position.x - body.transform.position.x,
          0.0f,
          transform.position.z - body.transform.position.z
          ).normalized * calculateForce(
            planetRb.mass,
            body.GetComponent<Rigidbody>().mass,
            Vector3.Distance(body.transform.position, transform.position),
            gravityMultiplier
          )
        );
      }
    }
  }
}
