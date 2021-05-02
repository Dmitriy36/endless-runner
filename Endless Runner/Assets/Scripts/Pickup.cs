using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    MeshRenderer[] mrs;

    private void Start()
    {
        mrs = this.GetComponentsInChildren<MeshRenderer>();
    }

    private void OnEnable()
    {
        if (mrs != null)
        {
            foreach (MeshRenderer m in mrs)
            {
                m.enabled = true;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameData.singleton.UpdateScore(10);

            foreach(MeshRenderer m in mrs)
            {
                m.enabled = false;
            }
        }
    }
}
