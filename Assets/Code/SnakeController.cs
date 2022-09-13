using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeController : BaseController{
    
    // Settings
    public float MoveSpeed = 5;
    public float SteerSpeed = 180;
    public float BodySpeed = 5;
    public int Gap = 10;
    public int PointsPerApple = 50;

    // References
    public GameObject BodyPrefab;
    public GameObject ApplePrefab;
    public GameObject CoinPrefab;
    public Score ScoreManager;
    public GameObject portal;
    public GameObject OpenWall;

    // Lists
    public List<GameObject> BodyParts = new List<GameObject>();
    public List<Vector3> PositionsHistory = new List<Vector3>();

    //bools?
    public bool PortalSpawned = false;


    // Start is called before the first frame update
    void Start() {
        //First level does nothing as the score is 0, but second level it updates based on your score from level 1
        int snakeSize = Persisting_stats.Score / PointsPerApple;

        //This instantiates the snake body parts
        for (int i = 0; i < snakeSize; i++)
        {
            GrowSnake();
        }
    }

    // Update is called once per frame
    void Update() {
        //TODO
        // Move forward
        
        // Steer
        
        //DONE

        // Store position history -> used to move body parts. 
        PositionsHistory.Insert(0, transform.position);

        // Move body parts -> works by "following" the positionshistory of the player/snake object foreach body object that has been
        //spawned
        int index = 0;
        foreach (var body in BodyParts) {
            Vector3 point = PositionsHistory[Mathf.Clamp(index * Gap, 0, PositionsHistory.Count - 1)];

            // Move body towards the point along the snakes path
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * BodySpeed * Time.deltaTime;

            // Rotate body towards the point along the snakes path
            body.transform.LookAt(point);

            index++;
        }
    }

    public override void GrowSnake() {
        // Instantiate body instance and
        // add it to the list
        GameObject body = Instantiate(BodyPrefab);
        BodyParts.Add(body);
        
        //Could add different bodyparts depending on which type of food is eaten
        //could scale the snake to be larger on later levels? instead of adding length
    }
    public override void SpawnApple()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-9, 9), (float)0.5, Random.Range(-9, 9));

        //Only applicable for scene/level2
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            randomSpawnPosition = new Vector3(Random.Range(-45, 45), (float)0.5, Random.Range(-45, 45));
        }

        Instantiate(ApplePrefab, randomSpawnPosition, Quaternion.identity);
    }
    public override void SpawnCoin()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-9, 9), (float)0.5, Random.Range(-9, 9));

        //Only applicable for scene/level2
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            randomSpawnPosition = new Vector3(Random.Range(-45, 45), (float)0.5, Random.Range(-45, 45));
        }

        Instantiate(CoinPrefab, randomSpawnPosition, Quaternion.identity);
    }
    public override void SpawnPortal()
    {
        portal.SetActive(true);

        //Only applicable for scene/level2
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            OpenWall.SetActive(false);
        }
    }
}