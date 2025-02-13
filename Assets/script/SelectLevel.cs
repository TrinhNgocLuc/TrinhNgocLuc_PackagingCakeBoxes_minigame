using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour
{
    public Button[] buttonLv;
    public int cout = 1;

    void Start()
    {
        PlayerPrefs.SetInt("UnlockLv", cout);
    }
    public void Update()
    {
        updateLv();
    }

    public void updateLv()
    {
        int unlockLv = PlayerPrefs.GetInt("UnlockLv");
        for (int i = 1; i < buttonLv.Length; i++)
        {
            buttonLv[i].interactable = false;
        }
        for (int i = 0; i < unlockLv; i++)
        {
            buttonLv[i].interactable = true;
        }
    }
}
