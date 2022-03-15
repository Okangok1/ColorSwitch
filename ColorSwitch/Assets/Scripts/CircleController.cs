﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    public float rotationSpeed = 50f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(transform.position.x*0,transform.position.y*0, rotationSpeed * Time.deltaTime));
    }

}
