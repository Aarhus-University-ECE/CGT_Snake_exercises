using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeControllerEndless : BaseController
{

    // Settings
    public Rigidbody rb;

    //TODO ADD FORCE
    public float forwardForce = 0f;
    public float sidewaysForce = 0f;

    public int PointsPerApple = 50;

    // References
    public GameObject BodyPrefab;
    public GameObject ApplePrefab;
    public GameObject CoinPrefab;
    public GameObject PortalPrefab;
    public Score ScoreManager;

    private void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            //TODO
            
        }
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            //TODO
            
        }
        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
            //Should end the level, if you fall from the running part
        }
    }

    //These methods would have different implementations for the endless snake
    //Ie. spawnportal hits at 800 or smth points, and then spawns a new tile where the portal to the next level is 
    //Accessible
    public override void SpawnPortal()
    {
        //Vector3 MiddleSpawnPosition = new Vector3(0, (float)0.5, 0);
        //Instantiate(PortalPrefab, MiddleSpawnPosition, Quaternion.identity);
    }
    //grow snake could add body parts same as in the lower levels
    public override void GrowSnake()
    {
        //throw new System.NotImplementedException();
    }
    //Doesnt do anything, since the apples are preconfigured for the tiles
    public override void SpawnApple()
    {
        //throw new System.NotImplementedException();
    }

    public override void SpawnCoin()
    {
        //throw new System.NotImplementedException();
    }
}
