using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public float width = 100;
    public float height = 100;

    public float rock_grid_density = 0.1f;
    int rock_grid_width;
    int rock_grid_height;
    public float rock_grid_thres = 0.8f;
    public bool[,] rock_grid;
    float rock_grid_scale = 1f;

    public float grass_grid_density = 0.1f;
    int grass_grid_width;
    int grass_grid_height;
    public float grass_grid_thres = 0.8f;
    public bool[,] grass_grid;
    float grass_grid_scale = 1.234f;

    // Start is called before the first frame update
    void Awake()
    {
        rock_grid_width = (int)(width * rock_grid_density);
        rock_grid_height = (int)(height * rock_grid_density);
        rock_grid = new bool[rock_grid_width, rock_grid_height];
        GenerateRockGrid();

        grass_grid_width = (int)(width * grass_grid_density);
        grass_grid_height = (int)(height * grass_grid_density);
        grass_grid = new bool[grass_grid_width, grass_grid_height];
        GenerateGrassGrid();
    }

    void GenerateGrassGrid()
    {
        for (int x = 0; x < grass_grid_width; x++)
        {
            for (int y = 0; y < grass_grid_height; y++)
            {
                float val = Mathf.PerlinNoise(x * grass_grid_scale * (float)Math.PI, y * grass_grid_scale * (float)Math.PI);
                bool is_grass = val > grass_grid_thres;
                grass_grid.SetValue(is_grass, x, y);
            }
        }
    }

    void GenerateRockGrid()
    {
        for (int x = 0; x < rock_grid_width; x++)
        {
            for (int y = 0; y < rock_grid_height; y++) 
            {
                float val = Mathf.PerlinNoise(x * rock_grid_scale * (float)Math.PI, y * rock_grid_scale * (float)Math.PI);
                bool is_rock = val > rock_grid_thres;
                rock_grid.SetValue(is_rock, x, y);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
