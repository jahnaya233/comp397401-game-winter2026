/*
 *File name: PlayerMovement.cs
 *Author: Jahnaya Brooks
 *Student Number: 301359779
 *Data Last Modified: 2026/03/23
 *Description:
 *Controls the movement of the player, jumping, health, and interaction with enemies 
 *Revision History:
 *1.0 Basic movement coded  
 *1.1 Added sound
 *1.2 Added health and damage system
 */

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
//Handles the player movement, jumping, and health
public class PlayerMovement : MonoBehaviour
{
   
    public float speed = 20f;//moving speed
    private Rigidbody rb;
    public float jumpForce = 5f;//jump strength
    private bool isGrounded;

    public AudioSource audioSource;
    public AudioClip jumpSound;
    public GameObject gameOverPanel;

    private bool isGameOver = false;
    public int health = 3;
    private bool canTakeDamage = true;
    public float damageCooldown = 1f;

    public TextMeshProUGUI livesText;

    void Start()
    {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        livesText.text = "Lives: " + health;
    }

     void FixedUpdate()
    {

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        //Normalize the movement to prevent faster speed going diagonally
        Vector3 movement = new Vector3(moveX, 0.0f, moveZ).normalized;

        //Apply movement force
        rb.AddForce(movement * speed, ForceMode.Acceleration);

        Vector3 velocity = rb.linearVelocity;
        Vector3 horizontal = new Vector3(velocity.x, 0, velocity.z);

        Vector3 target = movement * speed;

        rb.linearVelocity = Vector3.Lerp(horizontal, target, 0.2f) + Vector3.up * velocity.y;


    }

     void Update()
    {
        //Jump input
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
                {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            audioSource.PlayOneShot(jumpSound);
        }
        //Fall of map check and calls gameover panel
        if (transform.position.y<-5f && !isGameOver)
        {
            isGameOver = true;
            FindAnyObjectByType<PauseManager>().GameOver();
        }
        
          
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

   //Controls player health, one is taken away when hit by enemy
    public void TakeDamage()
    {

        if (!canTakeDamage) return;

        health--;

        livesText.text = "Lives: " + health;
        if (health <= 0)
        {
            FindObjectOfType<PauseManager>().GameOver();
        }

        canTakeDamage = false;
        Invoke(nameof(ResetDamage), damageCooldown);
    }
    //Resets the damage cooldown
    void ResetDamage()
    {
        canTakeDamage = true;
    }
}
