using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditor : MonoBehaviour
{
    [Header("Variables")]
        public Texture2D map;
        public ColorToPrefab[] mappings;
        public float xOffSet = -8.9f;
        public float yOffSet = -5.0f;

    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }

    void GenerateTile(int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);
        if (pixelColor.a == 0)
            return;
        
        foreach (ColorToPrefab map in mappings)
        {
        }

        print($"{x} {y} {pixelColor}");
        
    }
}
