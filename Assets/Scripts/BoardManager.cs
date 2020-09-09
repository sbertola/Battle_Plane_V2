using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private int rows = 5;
    [SerializeField] private int cols = 9;
    private float tileSize = 1;

    [SerializeField] GameObject[] tiles;

    [SerializeField] private int numEnemies = 3;
    [SerializeField] GameObject[] enemies;


    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();
    }

    private void GenerateMap()
    {
        int tileArraySize = tiles.Length;
        int enemyArraySize = enemies.Length;
        int currentEnemies = 0;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                //spawn tiles script
                int tileSelector = Random.Range(0, tileArraySize);
                GameObject tile = (GameObject)Instantiate(tiles[tileSelector]);
               // tile.transform.SetParent(GameObject.FindGameObjectWithTag("UnitPlacement").transform, false);

                float posX = col * tileSize;
                float posY = row * -tileSize;

                tile.transform.position = new Vector2(posX,posY);

                //spawn enemies script
                int spawnEnemy = Random.Range(0, 100);            

                if (col > 4 && currentEnemies < numEnemies && spawnEnemy > 70)
                {
                    int enemySelector = Random.Range(0, enemyArraySize);
                    GameObject enemy = (GameObject)Instantiate(enemies[enemySelector]);
                    currentEnemies++;

                    enemy.transform.position = new Vector2(posX, posY);
                }
                
                if (col == 8 && row == -4)
                {
                    while(currentEnemies < numEnemies)
                    {
                        
                        currentEnemies++;
                    }
                }
            }
        }
    }
}
