using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TitleScreenManager : MonoBehaviour
{
    public AudioClip opening;
    public AudioSource titleScreen;
    public Text taptoStart;
    private bool hasTapped;
    Touch touch;

    // Start is called before the first frame update
    void Start()
    {
        hasTapped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) // if a touch is detected
        {
            touch = Input.GetTouch(0); // gets the first touch on the screen (0)

            if (touch.phase == TouchPhase.Began) //on tap
            {
                if (hasTapped == false)
                {
                    hasTapped = true;
                    titleScreen.PlayOneShot(opening, .50f);
                    StartCoroutine(BeginGame());
                    taptoStart.text = "";
                }
            }
        }

    }

    private IEnumerator BeginGame()
    {
        yield return new WaitForSeconds(2.3f);
        SceneManager.LoadScene("GameplayScene");
    }
}
