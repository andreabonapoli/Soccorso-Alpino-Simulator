﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class Elicopter : MonoBehaviour
{

    private void Start()
    {
        
    }

    public void Rotate(int flag)
    {
        if (flag==0)
            transform.DORotate(new Vector3(0f, 360f, 0f), 0.1f, RotateMode.WorldAxisAdd).SetLoops(-1, LoopType.Restart);
        else if (flag==1)
            transform.DORotate(new Vector3(0f, 90f, 0f), 0.1f, RotateMode.WorldAxisAdd).SetLoops(-1, LoopType.Incremental);
    }

    public void Move()
    {
        transform.DOMove(new Vector3(2.15f, -6f, -2.09f), 5f);
    }




}