using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{

  public float cash = 20;
  Text cashText;
  bool endPanelInstantiated = false;
  public GameObject endPanel;
  void Start()
  {
    cashText = GameObject.FindGameObjectWithTag("cash").GetComponent<Text>();
    endPanel.SetActive(false);
    Time.timeScale = 1f;
  }

  void Update()
  {
    cashText.text = cash + "M";
    if (cash <= 0 && !endPanelInstantiated)
    {
      endPanel.SetActive(true);
      endPanelInstantiated = true;
      Time.timeScale = 0f;
    }
  }
}
