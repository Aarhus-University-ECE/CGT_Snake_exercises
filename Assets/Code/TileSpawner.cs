using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{

    private List<GameObject> activeTiles;
    public GameObject[] tilePrefabs;

    public float tileLength = 100;
    public int numberOfTiles = 3;
    public int totalNumOfTiles = 9;

    public float zSpawn = 0;

    private Transform playerTransform;

    private int previousIndex;

    void Start()
    {
        //spawns number of tiles in the beginning
        activeTiles = new List<GameObject>();
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
                SpawnTile();
            else
                SpawnTile(Random.Range(0, totalNumOfTiles));
        }
        //Sets playertransform, to be used when checking in update if a new tile should be spawned
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }
    void Update()
    {
        //Calls spawntile and deletetile when needed in the runner, once the player has travelled far enough
        if (playerTransform.position.z - 70 >= zSpawn - (numberOfTiles * tileLength))
        {
            //TODO
            //Hint, you need to find a tile index to call spawntile with, and you may also want to check if it is the same as last
            //To get a better feeling of progression
            

            //Done

            DeleteTile();
        }

    }

    public void SpawnTile(int index = 0)
    {
        //Instantiates a new tile, based on random chosen tile. Sets position and rotation before instantiate ;)
        GameObject tile = tilePrefabs[index];

        tile.transform.position = Vector3.forward * zSpawn;
        tile.transform.rotation = Quaternion.identity;
        tile.SetActive(true);
        var clone = Instantiate(tile);

        //DONE
        activeTiles.Add(clone); //Clone is just the name of the current tile you are activating/istantiating above
        zSpawn += tileLength; //Position of the next tile
        previousIndex = index; //Added to not spawn the same tile again, see update()
    }

    private void DeleteTile()
    {
        //Deletes tiles already traversed
        activeTiles[0].SetActive(false);
        activeTiles.RemoveAt(0);

        //Add score here based on distance travelled somewhere?
    }
}
