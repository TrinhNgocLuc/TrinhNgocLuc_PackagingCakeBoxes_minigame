using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playGame : MonoBehaviour
{
    public void SelectLevel()
    {
        SceneManager.LoadScene("SelectLevel");
    }
    public void Home()
    {
        SceneManager.LoadScene("Start");
    }
    public void NextLv()
    {
        int unlockLv = PlayerPrefs.GetInt("UnlockLv");
        SceneManager.LoadScene("Level"+unlockLv.ToString());
    }
}
