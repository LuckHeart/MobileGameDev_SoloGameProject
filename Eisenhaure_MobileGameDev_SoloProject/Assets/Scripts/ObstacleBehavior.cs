using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObstacleBehavior : MonoBehaviour
{
    public float speed;
    private GameObject player;
    private bool playerAlive;

    // Start is called before the first frame update
    void Start()
    {
        playerAlive = true;
        player = GameObject.Find("PlayerCharacter");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerAlive == true)
        {
            transform.Translate(new Vector2(-1, 0) * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerDeath();
    }

    public void PlayerDeath()
    {
        Debug.Log("Player Hit!");
        GameObject.Destroy(player);
        SceneManager.LoadScene("TItleScreen");
    }
}
