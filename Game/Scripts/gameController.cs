using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{

  public float cash = 20;
  public float ammo = 5;

  public bool isShopActive = false;
  Text cashText;
  Text ammoText;
  bool endPanelInstantiated = false;
  public GameObject endPanel;
  GameObject startPanel;
  GameObject shop;
  void Start()
  {
    cashText = GameObject.FindGameObjectWithTag("cash").GetComponent<Text>();
    ammoText = GameObject.FindGameObjectWithTag("ammo").GetComponent<Text>();
    endPanel.SetActive(false);
    Time.timeScale = 1f;
    GameObject[] buttons = GameObject.FindGameObjectsWithTag("shopbutton");
    foreach (GameObject button in buttons)
    {
      button.GetComponent<Button>().onClick.AddListener(ToggleShop);
    }
    GameObject.FindGameObjectWithTag("startButton").GetComponent<Button>().onClick.AddListener(StartGame);
    startPanel = GameObject.FindGameObjectWithTag("startMenu");
    shop = GameObject.FindGameObjectWithTag("shop");
    shop.SetActive(isShopActive);
  }

  void ToggleShop()
  {
    isShopActive = !isShopActive;
    shop.SetActive(isShopActive);
  }

  void StartGame()
  {
    startPanel.SetActive(false);
    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<cameraController>().SetLockTag("earth");
  }

  void Update()
  {
    cashText.text = cash + "M";
    ammoText.text = "Ammo: " + ammo;
    if (cash < 0 && !endPanelInstantiated)
    {
      endPanel.SetActive(true);
      endPanelInstantiated = true;
      Time.timeScale = 0f;
    }
    if (ammo == 0)
    {
      ammoText.color = Color.red;
    }
  }
}
