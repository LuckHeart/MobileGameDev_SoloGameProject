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

    // Start is called before the first frame update
    void Start()
    {
        hasTapped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasTapped == false && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Starting the Game");
            hasTapped = true;
            titleScreen.PlayOneShot(opening, .50f);
            StartCoroutine(BeginGame());
            taptoStart.text = "";
        }
    }

    private IEnumerator BeginGame()
    {
        yield return new WaitForSeconds(2.3f);
        SceneManager.LoadScene("GameplayScene");
    }
}