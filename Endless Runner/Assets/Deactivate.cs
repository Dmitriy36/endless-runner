using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    private void OnCollisionExit(Collision player)
    {
        if(player.gameObject.tag == "Player")
        {
            Invoke("SetInactive", 3.0f);
        }
    }

    void SetInactive()
    {
        this.gameObject.SetActive(false);
    }
}
