using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce = 10f;
    public float gravityModifier;
    public ParticleSystem explosionSmoke;
    public ParticleSystem dirtSplatter;
    private AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip crashSound;


    public bool isOnGround = true;
    public bool gameOver;
    private Animator playerAnim;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            audioSource.PlayOneShot(jumpSound, 1.0f);
            dirtSplatter.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtSplatter.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game over");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionSmoke.Play();
            dirtSplatter.Stop();
            audioSource.PlayOneShot(crashSound, 1.0f);


        }
    }
}
