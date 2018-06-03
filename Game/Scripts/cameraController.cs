using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{

  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
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
  }
}
