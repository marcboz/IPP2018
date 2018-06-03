using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraLockButton : MonoBehaviour
{

  public string lockTag;

  void Start()
  {
    GetComponent<Button>().onClick.AddListener(changeCameraLock);
  }

  void changeCameraLock()
  {
    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<cameraController>().SetLockTag(lockTag);
  }
}
