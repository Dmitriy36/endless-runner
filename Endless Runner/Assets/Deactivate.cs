﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    bool dScheduled = false;

    private void OnCollisionExit(Collision player)
    {
        if(player.gameObject.tag == "Player" && !dScheduled)
        {
            Invoke("SetInactive", 5.0f);
            dScheduled = true;
        }
    }

    void SetInactive()
    {
        this.gameObject.SetActive(false);
        dScheduled = false;
    }
}
