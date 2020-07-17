using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToPast : MonoBehaviour
{
     void OnMouseDown(){
         SceneManager.LoadScene("Past", LoadSceneMode.Single); 
  }   
}
