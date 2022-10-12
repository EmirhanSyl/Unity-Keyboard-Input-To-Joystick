using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private int width = 256;
    [SerializeField] private int height = 256;
    [SerializeField] private int depth = 20;

    [SerializeField] private float scale = 20f;

    [SerializeField] private float offsetX = 100f;
    [SerializeField] private float offsetY = 100f;

    private int lastDepth;
    private int lastWidth;
    private int lastHeight;

    private float lastScale;
    private float lastOffsetX;
    private float lastOffsetY;


    private void Start()
    {
        offsetX = Random.Range(0f, 9999f);
        offsetY = Random.Range(0f, 9999f);

        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);

        lastDepth = depth;
        lastWidth = width;
        lastHeight = height;
        lastScale = scale;
        lastOffsetX = offsetX;
        lastOffsetY = offsetY;
    }

    private void Update()
    {
        if (lastDepth != depth || lastWidth != width || lastHeight != height || lastScale != scale || lastOffsetX != offsetX ||lastOffsetY != offsetY)
        {
            Terrain terrain = GetComponent<Terrain>();
            terrain.terrainData = GenerateTerrain(terrain.terrainData);

            lastDepth = depth;
            lastWidth = width;
            lastHeight = height;
            lastScale = scale;
            lastOffsetX = offsetX;
            lastOffsetY = offsetY;
        }
    }

    TerrainData GenerateTerrain(TerrainData data)
    {
        data.heightmapResolution = width + 1;
        data.size = new Vector3(width,depth, height);
        data.SetHeights(0, 0, GenerateHeights());

        return data;
    }

    float[,] GenerateHeights()
    {
        float[,] heights = new float[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = CalculateHeight(x, y);
            }
        }

        return heights;
    }

    float CalculateHeight(int x, int y)
    {
        float xCoord = (float)x / width * scale + offsetX;
        float yCoord = (float)y / height * scale + offsetY;

        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}
