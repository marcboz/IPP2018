using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class launchControl : MonoBehaviour
{
  public static float cooldown = 3f;
  public GameObject bomb;
  float speed = 10;
  float distanceFromMouse;
  Slider powerSlider;
  Slider cooldownSlider;
  Image sliderColor;
  Image cooldownColor;
  float timer;
  public float maxVelocity = 3f;

  cameraController cameraController;
  gameController gameController;

  void Start()
  {
    powerSlider = GameObject.FindGameObjectWithTag("powerSlider").GetComponent<Slider>();
    sliderColor = GameObject.FindGameObjectWithTag("fillColor").GetComponent<Image>();
    cooldownSlider = GameObject.FindGameObjectWithTag("cooldownSlider").GetComponent<Slider>();
    cooldownColor = GameObject.FindGameObjectWithTag("cdfillColor").GetComponent<Image>();
    timer = Time.time + cooldown;
    cameraController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<cameraController>();
    gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameController>();
  }

  float calculateDistanceToPowerRatio()
  {
    if (distanceFromMouse > 30)
    {
      return 1f;
    }
    else
    {
      return distanceFromMouse / 30;
    }
  }

  void calculateCooldown()
  {
    if (timer >= Time.time)
    {
      cooldownSlider.value = 1 - ((timer - Time.time) / cooldown);
      cooldownColor.color = Color.red;
    }
    else
    {
      cooldownSlider.value = 1;
      cooldownColor.color = Color.green;
    }
  }

  string checkCurrentTag()
  {
    if (cameraController.GetLockTag() == "earth")
    {
      return "earthLauncher";
    }
    else if (cameraController.GetLockTag() == "mars")
    {
      return "marsLauncher";
    }
    else return "";
  }


  void Update()
  {
    if (tag == checkCurrentTag())
    {
      Plane plane = new Plane(Vector3.up, transform.position);
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      float hitdist = 0.0f;
      float cursorPower = calculateDistanceToPowerRatio();
      Vector3 mousePoint;
      if (plane.Raycast(ray, out hitdist))
      {
        mousePoint = ray.GetPoint(hitdist);
        distanceFromMouse = Vector3.Distance(transform.position, mousePoint);

        Quaternion targetRotation = Quaternion.LookRotation(mousePoint - transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
        if (timer <= Time.time && Input.GetMouseButton(0) && gameController.ammo > 0 && (!gameController.isShopActive || (gameController.isShopActive && Input.mousePosition.x > 250)) && (Screen.height - Input.mousePosition.y) > 30)
        {
          GameObject instantiated = Instantiate(bomb, transform.position, Quaternion.LookRotation(mousePoint - transform.position));
          Vector3 direction = new Vector3(
            mousePoint.x - transform.position.x,
            0.0f,
            mousePoint.z - transform.position.z
          ).normalized;
          instantiated.GetComponent<Rigidbody>().velocity = new Vector3(direction.x * maxVelocity * cursorPower, 0.0f, direction.z * maxVelocity * cursorPower);
          timer = Time.time + cooldown;
          gameController.ammo -= 1;
        }
      }
      powerSlider.value = cursorPower;
      if (cursorPower < 0.34f) { sliderColor.color = Color.green; }
      if (cursorPower >= 0.34f && cursorPower < 0.67f) { sliderColor.color = Color.yellow; }
      if (cursorPower >= 0.67f) { sliderColor.color = Color.red; }
      calculateCooldown();

    }
  }
}
