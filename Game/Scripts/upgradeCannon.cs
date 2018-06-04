using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upgradeCannon : MonoBehaviour
{

  void Start()
  {
    GetComponent<Button>().onClick.AddListener(Upgrade);
  }

  void Upgrade()
  {
    if (GameObject.FindGameObjectWithTag("GameController").GetComponent<gameController>().cash >= 20)
    {
      launchControl.cooldown = launchControl.cooldown - (launchControl.cooldown / 3);
      GameObject.FindGameObjectWithTag("GameController").GetComponent<gameController>().cash -= 20;
    }

  }
}
