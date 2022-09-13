using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    //Make the controller a base class, and these two derivatives thereof?

    //set controller dependent on which level were at? Maybe from gameManager?
    public BaseController snakeController;
    public Score ScoreManager;

    public int PointsPerApple = 50;

    private void OnCollisionEnter(Collision collision)
    {
        //Handles collisions with walls
        if (collision.collider.tag == "Obstacle")
        {
            Debug.Log("collision with obstacle");
            snakeController.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Handles triggers on contact with different objects, that arent physical collisions, ie an apple you eat, not a wall
        if (other.tag == "Apple")
        {
            Destroy(other.gameObject);

            snakeController.GrowSnake();
            snakeController.SpawnApple();
            //Add score to the score counter
            ScoreManager.AddScore(PointsPerApple);
            CheckIfSpawnPortal();
        }
        //Here you could add a check tag for a green apple
        if (other.tag == "Coin")
        {
            Destroy(other.gameObject);
            snakeController.GrowSnake();
            snakeController.SpawnCoin();

            ScoreManager.AddScore(PointsPerApple);
            CheckIfSpawnPortal();
        }

        if (other.tag == "Portal")
        {
            //gameManager.CompleteLevel();
            //Logic to switch active scene to next level
            Persisting_stats.Score = ScoreManager.GetScore();
            Debug.Log(Persisting_stats.Score.ToString());
            
        }
        if (other.tag == "ai")
        {
            snakeController.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
            Debug.Log("ai trigger");
        }
        
    }
    private void CheckIfSpawnPortal()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 && ScoreManager.GetScore() > 150)
        {
            snakeController.SpawnPortal();
        }
        if (SceneManager.GetActiveScene().buildIndex == 2 && ScoreManager.GetScore() > 450)
        {
            snakeController.SpawnPortal();
        }

    }
}
