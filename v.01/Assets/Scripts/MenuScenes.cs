using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ResetData
{
    public void ResetD()
    {
        StaticData.Instance.playerData.damage = 3;
        StaticData.Instance.playerData.position = Vector3.zero;
        StaticDataBug.Instance.bugData.pressedSave = true;
        StaticDataBug.Instance.bugData.tumblerSave = false;
        StaticDataArm.Instance.armData.tumblerSave = false;
        Cursor.visible = true;
    }
}

public class MenuScenes : MonoBehaviour
{
    // Start is called before the first frame update
    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        ResetData resetData = new ResetData();
        resetData.ResetD();
        SceneManager.LoadScene("Present", LoadSceneMode.Single);
    }
}
