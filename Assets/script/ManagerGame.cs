using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManagerGame : MonoBehaviour
{
    public float time = 45f;
    public  TextMeshProUGUI UITime;
    public GameObject lvFailed;
    public int cout = 1;
    public void Start()
    {
        Time.timeScale = 1;
    }
    public void Update()
    {
        coutDown();
    }
    private void coutDown()
    {

        if( time > 0)
        {
            time -= Time.deltaTime;
            int seconds = Mathf.FloorToInt(time % 60);
            UITime.text = seconds.ToString();
        }
        else
        {
            UITime.text = "0";
            lvFailed.SetActive(true);
        }
    }

}
