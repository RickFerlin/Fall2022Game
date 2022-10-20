using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace EndlessRunner
{

    public class TileSpawner : MonoBehaviour
    {
        public int tileStartCount = 10;
        public int minStraightTiles = 3;
        public int maxStraightTiles = 15;
        public GameObject startingTile;
        public List<GameObject> turnTiles;
        public List<GameObject> obstacles;

        private Vector3 currentTileLocation = Vector3.zero;
        private Vector3 currentTileDirection = Vector3.forward;
        private GameObject prevTile;

        private List<GameObject> currentTiles;
        private List<GameObject> currentObstacles;

        private void Start()
        {
            currentTiles = new List<GameObject>();
            currentObstacles = new List<GameObject>();

            Random.InitState(System.DateTime.Now.Millisecond);

            for (int i = 0; i < tileStartCount; i++)
            {
                SpawnTile(startingTile.GetComponent<Tile>(), false);
            }
            // SpawnTile();
        }

        private void SpawnTile(Tile tile, bool spawnObstacle)
        {
            prevTile = GameObject.Instantiate(tile.gameObject, currentTileLocation, Quaternion.identity);
            currentTiles.Add(prevTile);
            currentTileLocation += Vector3.Scale(prevTile.GetComponent<Renderer>().bounds.size, currentTileDirection);
        }
    }

}
