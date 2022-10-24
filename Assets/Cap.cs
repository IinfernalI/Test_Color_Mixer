using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Cap : MonoBehaviour
{
    [SerializeField] private Transform capMoving;

    private float s = 0f;
    private bool open = false;

    private void OnEnable()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        capMoving.Rotate(0, 0, 90);
        open = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    [ContextMenu("TestSlapa")]
    void OpenClosed()
    {
        if (open == false)
        {
            capMoving.Rotate(0, 0, 90);
            open = true;
        }
        else
        {
            capMoving.Rotate(0, 0, -90);
            open = false;
        }
    }
}