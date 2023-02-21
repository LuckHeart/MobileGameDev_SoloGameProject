using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float JumpForce;
    public bool hasJumped;
    public float jumpCount;
    Touch touch;
    Rigidbody2D rb;
    Animator player;
    public AudioClip playerJump;
    public AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        hasJumped = false;
        player = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) // if a touch is detected
        {
            touch = Input.GetTouch(0); // gets the first touch on the screen (0)

            if (touch.phase == TouchPhase.Began) //on tap
            {
                if (jumpCount < 2)
                {
                    rb.AddForce((Vector2.up * JumpForce) * Time.fixedDeltaTime, ForceMode2D.Impulse);
                    jumpCount++;
                    player.SetBool("hasJumped", true);
                    StartCoroutine(JumpTime());
                    playerAudio.PlayOneShot(playerJump, 1);
                }
            }
        }
    }

    private IEnumerator JumpTime()
    {
        yield return new WaitForSeconds(3.2f);
        player.SetBool("hasJumped", false);
        jumpCount = 0;
    }
}
