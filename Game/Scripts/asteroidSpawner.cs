using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidSpawner : MonoBehaviour
{

  public GameObject[] asteroids;
  public Transform[] spawnPointsEarth;
  public Transform[] spawnPointsMars;
  public float interval = 2;

  string currentLockTag;

  void Start()
  {
    currentLockTag = "earth";
    StartCoroutine(SpawnAsteroidsOnEarth());
  }

  void Update()
  {
    if (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<cameraController>().GetLockTag() == "earth" && currentLockTag != "earth")
    {
      StartCoroutine(SpawnAsteroidsOnEarth());
      if (currentLockTag == "mars")
      {
        StopCoroutine(SpawnAsteroidsOnMars());
      }
      currentLockTag = "earth";
    }

    if (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<cameraController>().GetLockTag() == "mars" && currentLockTag != "mars")
    {
      StartCoroutine(SpawnAsteroidsOnMars());
      if (currentLockTag == "earth")
      {
        StopCoroutine(SpawnAsteroidsOnEarth());
      }
      currentLockTag = "mars";
    }
  }

  IEnumerator SpawnAsteroidsOnEarth()
  {
    while (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<cameraController>().GetLockTag() == "earth")
    {
      Debug.Log("e");
      int randomIndex = Random.Range(0, 3);
      Instantiate(asteroids[Random.Range(0, 2)], spawnPointsEarth[randomIndex].position, spawnPointsEarth[randomIndex].rotation);
      yield return new WaitForSeconds(interval);
    }

  }

  IEnumerator SpawnAsteroidsOnMars()
  {
    while (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<cameraController>().GetLockTag() == "mars")
    {
      Debug.Log("m");
      int randomIndex = Random.Range(0, 3);
      Instantiate(asteroids[Random.Range(0, 2)], spawnPointsMars[randomIndex].position, spawnPointsMars[randomIndex].rotation);
      yield return new WaitForSeconds(interval);
    }
  }
}
