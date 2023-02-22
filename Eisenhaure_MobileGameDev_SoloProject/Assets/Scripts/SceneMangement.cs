using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMangement : MonoBehaviour
{
    public GameObject obstacle;
    public Text scoreCounter;
    private GameObject obstacleInstance;
    public float playerTally;
    public float obstacleTiming;
    public bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        obstacleTiming = 0.0f;
        playerTally = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerTally();

        if (obstacleTiming >= 0.0f)
        {
            obstacleTiming += 1 * Time.deltaTime;
        }

        if (obstacleTiming >= 4.0f)
        {
            ObstacleSpawning();
            obstacleTiming = 0.0f;
        }

        if (obstacleInstance?.transform.position.x <= -10f)
        {
            Destroy(obstacleInstance);
            playerTally++;
        }
    }

    public void ObstacleSpawning()
    {
        Vector2 SpawnPOS = new Vector2(13, (Random.Range(-4.95f, -2.21f)));
        Instantiate(obstacle, SpawnPOS, transform.rotation);
        obstacleInstance = GameObject.Find("LargeObstacle(Clone)");
    }

    public void PlayerTally()
    {
        scoreCounter.text = playerTally.ToString();
    }
}
