using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    MeshRenderer[] mrs;
    public GameObject scorePrefab;
    public GameObject particlePrefab;
    GameObject canvas;

    private void Start()
    {
        mrs = this.GetComponentsInChildren<MeshRenderer>();
        canvas = GameObject.Find("Canvas");
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
            PlayerController.sfx[1].Play();
            GameObject scoreText = Instantiate(scorePrefab);
            scoreText.transform.parent = canvas.transform;

            GameObject particleEffect = Instantiate(particlePrefab, this.transform.position, Quaternion.identity);
            Destroy(particleEffect, 1);

            Vector3 screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
            scoreText.transform.position = screenPoint;

            foreach(MeshRenderer m in mrs)
            {
                m.enabled = false;
            }
        }
    }
}
