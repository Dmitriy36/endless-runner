using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    public static GameObject player;
    public static GameObject currentPlatform;
    public static AudioSource[] sfx;

    bool canTurn = false;
    Vector3 startPosition;
    public static bool isDead = false;
    Rigidbody rb;

    public GameObject magic;
    public Transform magicStartPos;
    Rigidbody mRb;

    int livesLeft;
    public Texture aliveIcon;
    public Texture deadIcon;
    public RawImage[] icons;

    public GameObject gameOverPanel;
    public TMP_Text highScore;

    private void RestartGame()
    {
        SceneManager.LoadScene("ScrollingWorld", LoadSceneMode.Single);
    }

    private void OnCollisionEnter(Collision other)
    {     
        if(other.gameObject.tag == "Fire" || other.gameObject.tag == "Wall" && !isDead)
        {
            sfx[6].Play();
            anim.SetTrigger("isDead");
            isDead = true;
            livesLeft--;
            PlayerPrefs.SetInt("Lives", livesLeft);

            if(livesLeft > 0)
            {
                Invoke("RestartGame", 1f);
            }
            else
            {
                icons[0].texture = deadIcon;
                gameOverPanel.SetActive(true);

                PlayerPrefs.SetInt("LastScore", PlayerPrefs.GetInt("Score"));
                if (PlayerPrefs.HasKey("HighScore"))
                {
                    int hs = PlayerPrefs.GetInt("HighScore");
                    if (hs < PlayerPrefs.GetInt("Score"))
                    {
                        PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));
                    }
                }
                else
                {
                    PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));
                }

            }
            
        } else 
        currentPlatform = other.gameObject;
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            highScore.text = "High Score: 0";
        }
            

        anim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
        mRb = magic.GetComponent<Rigidbody>();

        sfx = GameObject.FindWithTag("GameData").GetComponentsInChildren<AudioSource>();

        player = this.gameObject;
        startPosition = player.transform.position;

        GenerateWorld.RunDummy();

        isDead = false;

        livesLeft = PlayerPrefs.GetInt("Lives");

        for (int i = 0; i < icons.Length; i++)
        {
            if(i >= livesLeft)
            {
                icons[i].texture = deadIcon;
            }
        }
    }

    void CastMagic()
    {
        
        magic.transform.position = magicStartPos.position;
        magic.SetActive(true);
        mRb.AddForce(this.transform.forward * 80000);

        Invoke("KillMagic", 1.0f);
    }

    void PlayMagicSound()
    {
        sfx[7].Play();
    }

    void KillMagic()
    {
        magic.SetActive(false);
    }

    void Footstep1()
    {
        sfx[3].Play();
    }

    void Footstep2()
    {
        sfx[4].Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other is BoxCollider && GenerateWorld.lastPlatform.tag != "platformTSection")
        GenerateWorld.RunDummy();

        if(other is SphereCollider)
        {
            canTurn = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other is SphereCollider)
        {
            canTurn = false;
        }
    }

    void StopJump()
    {            
        anim.SetBool("isJumping", false);
    }

    void StopMagic()
    {
        anim.SetBool("isMagic", false);
    }

    void Update()
    {

        if (isDead) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerController.sfx[2].Play();
            anim.SetBool("isJumping", true);
            rb.AddForce(Vector3.up * 200);
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("isMagic", true);
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow) && canTurn)
        {
            this.transform.Rotate(Vector3.up * 90); // rotates about the "up" axis 
            GenerateWorld.dummyTraveler.transform.forward = -this.transform.forward;
            GenerateWorld.RunDummy();

            if (GenerateWorld.lastPlatform.tag != "platformTSection")
                GenerateWorld.RunDummy();

            this.transform.position = new Vector3(startPosition.x, this.transform.position.y, startPosition.z);
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow) && canTurn)
        {
            this.transform.Rotate(Vector3.up * -90); // rotates about the "up" axis 
            GenerateWorld.dummyTraveler.transform.forward = -this.transform.forward;
            GenerateWorld.RunDummy();

            if (GenerateWorld.lastPlatform.tag != "platformTSection")
                GenerateWorld.RunDummy();

            this.transform.position = new Vector3(startPosition.x, this.transform.position.y, startPosition.z);
        }

        else if (Input.GetKeyDown(KeyCode.A))
        {
            this.transform.Translate(-0.5f, 0, 0);
        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
            this.transform.Translate(0.5f, 0, 0);
        }

    }

}
