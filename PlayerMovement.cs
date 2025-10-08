using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public LayerMask groundLayer;

    public float speed = 5f;
    public float jumpForce = 3f;

    private Rigidbody2D rb;
    private AudioSource jumpAudio;
    private AudioSource deathAudio;

    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Get both AudioSources
        AudioSource[] sources = GetComponents<AudioSource>();
        if (sources.Length >= 2)
        {
            jumpAudio = sources[0];
            deathAudio = sources[1];
        }
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);

        if (Mathf.Abs(rb.linearVelocity.x) > 0.1f)
        {
            float rotationSpeed = 300f;
            transform.Rotate(0, 0, -rb.linearVelocity.x * rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (IsGrounded())
        {
            Debug.Log("Player is on the ground");
        }
        else
        {
            Debug.Log("Player is in the air");
        }

    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        if (jumpAudio != null)
            jumpAudio.Play();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isDead && collision.gameObject.CompareTag("Obstacle"))
        {
            isDead = true;

            GameObject bgMusic = GameObject.Find("BackgroundMusic");
            if (bgMusic != null)
            {
                AudioSource bgSource = bgMusic.GetComponent<AudioSource>();
                if (bgSource != null)
                    bgSource.Stop();
            }
      
            GameObject tempAudio = new GameObject("TempDeathSound");
            AudioSource tempSource = tempAudio.AddComponent<AudioSource>();
            tempSource.clip = deathAudio.clip;
            tempSource.Play();
            DontDestroyOnLoad(tempAudio);
            Destroy(tempAudio, deathAudio.clip.length);

            SceneManager.LoadScene("GameOver");
        }
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Flag"))
        {
            string currentScene = SceneManager.GetActiveScene().name;

            if (currentScene == "SampleScene")
            {
                SceneManager.LoadScene("SampleScene 1");
            }
            else if (currentScene == "SampleScene 1")
            {
                SceneManager.LoadScene("GameWon");
            }
        }
    }
    bool IsGrounded()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, groundLayer);

        Debug.DrawRay(transform.position, Vector2.down * 0.6f, Color.red);

        return hit.collider != null;
    }

}
