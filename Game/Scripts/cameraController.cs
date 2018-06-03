using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{

  string lockTag = "earth";

  public void setLockTag(string tag)
  {
    lockTag = tag;
  }

  void Update()
  {
    const int orthographicSizeMin = 1;
    const int orthographicSizeMax = 40;
    if (Input.GetAxis("Mouse ScrollWheel") < 0)
    {
      Camera.main.orthographicSize++;
    }
    if (Input.GetAxis("Mouse ScrollWheel") > 0)
    {
      Camera.main.orthographicSize--;
    }
    Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, orthographicSizeMin, orthographicSizeMax);

    transform.position = new Vector3(GameObject.FindGameObjectWithTag(lockTag).transform.position.x, 4.0f, GameObject.FindGameObjectWithTag(lockTag).transform.position.z);
  }
}
