using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    public GameObject[] bricks;
    List<Rigidbody> bricksRBs = new List<Rigidbody>();
    Collider col;

    private void Start()
    {
        col = this.GetComponent<Collider>();
        foreach(GameObject b in bricks)
        {
            bricksRBs.Add(b.GetComponent<Rigidbody>());
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Spell")
        {
            col.enabled = false;
            foreach(Rigidbody r in bricksRBs){
                r.isKinematic = false;
            }
        }
    }

}
