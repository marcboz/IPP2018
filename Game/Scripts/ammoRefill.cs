using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ammoRefill : MonoBehaviour
{

  gameController gameController;
  public float amount;
  public float price;
  void Start()
  {
    gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameController>();
    GetComponent<Button>().onClick.AddListener(Buy);
  }

  void Buy()
  {
    if (gameController.cash >= price)
    {
      gameController.ammo += amount;
      gameController.cash -= price;
    }
  }
}
