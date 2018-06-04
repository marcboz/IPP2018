using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class exitButton : MonoBehaviour
{
  void Start()
  {
    GetComponent<Button>().onClick.AddListener(Quit);
  }

  void Quit()
  {
    Application.Quit();
  }
}
