using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Controller : MonoBehaviour
{
    public GameObject Cake;
    public GameObject Box;
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    public GameObject lvCompleted;
    int cout;
    public float fixedForce = 30f;

    public void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startTouchPosition = touch.position;
                    break;

                case TouchPhase.Ended:
                    endTouchPosition = touch.position;
                    HandleSwipe();
                    break;
            }
        }
    }
    private void HandleSwipe()
    {
        Vector2 swipeDirection = endTouchPosition - startTouchPosition;

        if (swipeDirection.magnitude > 100) 
        {
            swipeDirection.Normalize(); 

            if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
            {
                swipeDirection = new Vector2(Mathf.Sign(swipeDirection.x), 0);
            }
            else
            {
                swipeDirection = new Vector2(0, Mathf.Sign(swipeDirection.y));
            }
            ApplyForce(Cake, swipeDirection);
            ApplyForce(Box, swipeDirection);
        }
    }
    public void ApplyForce(GameObject obj, Vector2 direction)
    {
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 force = direction * fixedForce;
            rb.AddForce(force, ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("box") && Cake.transform.position.y > Box.transform.position.y)
        {
           
            Debug.Log("ok");
            Destroy(Cake);
            cout = PlayerPrefs.GetInt("UnlockLv");
            cout++;
            PlayerPrefs.SetInt("UnlockLv", cout);
            Time.timeScale = 0;
            lvCompleted.SetActive(true);

        }
    }
}
