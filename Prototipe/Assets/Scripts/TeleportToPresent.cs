using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToPresent : MonoBehaviour
{
     void OnMouseDown(){
         SceneManager.LoadScene("Present", LoadSceneMode.Single); 
  }   
}
