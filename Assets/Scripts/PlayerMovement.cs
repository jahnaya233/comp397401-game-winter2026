using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
   
    public float speed = 20f;
    private Rigidbody rb;
    public float jumpForce = 5f;
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

        Vector3 movement = new Vector3(moveX, 0.0f, moveZ).normalized;
        rb.AddForce(movement * speed, ForceMode.Acceleration);

        Vector3 velocity = rb.linearVelocity;
        Vector3 horizontal = new Vector3(velocity.x, 0, velocity.z);

        Vector3 target = movement * speed;

        rb.linearVelocity = Vector3.Lerp(horizontal, target, 0.2f) + Vector3.up * velocity.y;


    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
                {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            audioSource.PlayOneShot(jumpSound);
        }
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

    void ResetDamage()
    {
        canTakeDamage = true;
    }
}
