using System;
using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    public int width = 10;
    public int height = 10;
    public int density = 4;
    public float scale = 20f;

    void Update()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = GenerateTexture();
    }

    Texture2D GenerateTexture()
    {

        Texture2D texture = new Texture2D(width, height);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float x_coord = (float)x / width * scale;
                float y_coord = (float)y / height * scale;
                Mathf.PerlinNoise(x_coord, y_coord);
                Color color = CalculateColor(x,y);
                texture.SetPixel(x, y, color);
            }
        }

        texture.Apply();
        return texture;
    }

    Color CalculateColor(int x, int y)
    {
        float x_coord = (float)x / width * scale;
        float y_coord = (float)y / height * scale;
        float sample = Mathf.PerlinNoise(x_coord, y_coord);
        return new Color(sample, sample, sample);
    }
}
 