﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAbleArea : MonoBehaviour
{
    private Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void OnMouseDown()
    {
        Debug.Log("ekrana tıklandı");
        player.isJumping = true;
    }
}
