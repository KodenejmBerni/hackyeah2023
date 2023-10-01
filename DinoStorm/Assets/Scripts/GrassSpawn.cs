using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSpawn : MonoBehaviour
{
    public World world;
    public GameObject[] spawnPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        int grass_grid_width = world.grass_grid.GetLength(0);
        int grass_grid_height = world.grass_grid.GetLength(1);
        Vector2 bot_left_coord = new Vector2(-world.width / 2, -world.height / 2);
        Vector2 step = new Vector2(world.width / grass_grid_width, world.height / grass_grid_height);

        System.Random grass_sprite_rnd = new System.Random();
        for (int x = 0; x < grass_grid_width; x++)
        {
            for (int y = 0; y < grass_grid_height; y++)
            {
                if (world.grass_grid[x, y])
                {
                    GameObject spawnPrefab = spawnPrefabs[grass_sprite_rnd.Next(spawnPrefabs.Length)];
                    SpriteRenderer sprite_renderer = spawnPrefab.GetComponent<SpriteRenderer>();
                    float x_coord = bot_left_coord.x + step.x * x;
                    float y_coord = bot_left_coord.y + step.y * y;
                    float y_offset = sprite_renderer.bounds.extents.y;
                    Vector3 grass_coord = new Vector3(x_coord, y_coord, (y_coord - y_offset) * 0.001f);

                    Instantiate(spawnPrefab, grass_coord, Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
