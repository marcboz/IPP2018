using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class retryButton : MonoBehaviour
{

  void Start()
  {
    GetComponent<Button>().onClick.AddListener(Retry);
  }

  void Retry()
  {
    SceneManager.LoadScene("SampleScene");
  }

}
