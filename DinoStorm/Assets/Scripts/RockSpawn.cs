using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawn : MonoBehaviour
{
    public World world;
    public GameObject[] spawnPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        int rock_grid_width = world.rock_grid.GetLength(0);
        int rock_grid_height = world.rock_grid.GetLength(1);
        Vector2 bot_left_coord = new Vector2(-world.width / 2, -world.height / 2);
        Vector2 step = new Vector2(world.width / rock_grid_width, world.height / rock_grid_height);

        System.Random stone_sprite_rnd = new System.Random();
        for (int x = 0; x < rock_grid_width; x++)
        {
            for (int y = 0; y < rock_grid_height; y++)
            {
                if (world.rock_grid[x, y])
                {
                    GameObject spawnPrefab = spawnPrefabs[stone_sprite_rnd.Next(spawnPrefabs.Length)];
                    SpriteRenderer sprite_renderer = spawnPrefab.GetComponent<SpriteRenderer>();
                    float x_coord = bot_left_coord.x + step.x * x;
                    float y_coord = bot_left_coord.y + step.y * y;
                    float y_offset = sprite_renderer.bounds.extents.y;
                    Vector3 rock_coord = new Vector3(x_coord, y_coord, (y_coord - y_offset) * 0.001f);
                    
                    Instantiate(spawnPrefab, rock_coord, Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
