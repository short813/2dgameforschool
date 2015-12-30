using UnityEngine;
using System.Collections;

public class character_control2 : MonoBehaviour
{
    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        cheese_start = 71;

    }
    // variables for ground check
    Rigidbody2D body;
    public Transform Ground_CheckTransform;
    public bool grounded = false;
    public LayerMask Ground_CheckLayerMask;
    Animator animator;
    public bool dead = false;
    // collection variable
    private uint Cheese= 0;
    public Texture2D CheeseIconTexture;
    public GUIStyle restartButtonStyle;
    public AudioClip CheeseCollectSound;
    public AudioSource footstepsAudio;
    public float jumpForce = 500;
    public float maxspeed;
    public float xxxMovementxxx;
    public float CheeseToNext = 36;
    public float cheese_start;
    


    void DisplayRestartButton()
    {
        // when dead it shows a GUI to restart the level
        if (dead && grounded)
        {
            Rect buttonRect = new Rect(Screen.width * 0.35f, Screen.height * 0.45f, Screen.width * 0.30f, Screen.height * 0.1f);
            if (GUI.Button(buttonRect, " Try Again?"))
                Application.LoadLevel(Application.loadedLevelName);

        }
    }
    void DisplayCheeseCount()
    {
        // icon of object collect
        Rect CheeseIconRect = new Rect(10, 10, 32, 32);
        GUI.DrawTexture(CheeseIconRect, CheeseIconTexture);
        // object counter
        GUIStyle style = new GUIStyle();
        style.fontSize = 30;
        style.fontStyle = FontStyle.Bold;
        style.normal.textColor = Color.red;
        Rect labelRect = new Rect(CheeseIconRect.xMax, CheeseIconRect.y, 60, 32);
        GUI.Label(labelRect, Cheese.ToString(), style);
    }
void OnGUI()
    {
            DisplayCheeseCount();
            DisplayRestartButton();
    }
void CollectCheese(Collider2D CheeseCollider)
    {
        Cheese++;
        Destroy(CheeseCollider.gameObject);
        AudioSource.PlayClipAtPoint(CheeseCollectSound, transform.position);
        
        
    }
void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Cheese"))
            CollectCheese(collider);
        else DeathByPidgey(collider);
    }

void DeathByPidgey(Collider2D pidgeyCollider)
    {
        dead = true;
        animator.SetBool("dead", true);
    }
    void UpdateGroundedStatus()
    {
        //checks to see if it is grounded
        grounded = Physics2D.OverlapCircle(Ground_CheckTransform.position, 0.1f, Ground_CheckLayerMask);
        animator.SetBool("grounded", grounded);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            body.AddForce(new Vector2(0.0f, jumpForce));
        }
        
        if ((cheese_start - Cheese) == CheeseToNext)
            {
            Application.LoadLevel(3);
        }
    }

    void FixedUpdate()
    {
        xxxMovementxxx = Input.GetAxis("Horizontal");
        if (grounded && !dead)
        {
            body.velocity = new Vector2(xxxMovementxxx * maxspeed, body.velocity.y);
        }
        animator.SetFloat("speed", xxxMovementxxx);
        UpdateGroundedStatus();
    }
}
