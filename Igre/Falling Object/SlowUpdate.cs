using System;
using UnityEngine;

public class SlowUpdate : MonoBehaviour
{
    private float timer;
    private void Start()
    {
        InvokeRepeating(nameof(MyUpdate), 1,1);
    }

    private void MyUpdate()
    {
        timer++;
        if (timer >= 5)
        {
            timer = 0;
        Debug.Log("Update timer ");
        }

        Debug.Log(timer);
    }

}
