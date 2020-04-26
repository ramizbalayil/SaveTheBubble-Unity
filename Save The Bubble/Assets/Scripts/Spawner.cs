using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject SideWall;
    public GameObject Camera;
    public float height = 0;

    int difficulty = 1;
    GameObject[] side_walls;
    const int MAX_WALLS = 3;

    void Start()
    {
        side_walls = new GameObject[MAX_WALLS];
        for (int i = 0; i < MAX_WALLS; i++)
        {
            side_walls[i] = Instantiate(SideWall, new Vector3(0.0f, 0.0f + i * height, 0), Quaternion.identity);
            if (i != 0)
            {
                side_walls[i].GetComponent<SideWall>().SpawnObstacles(height, difficulty);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < side_walls.Length; i++)
        {
            if (Camera.transform.position.y - side_walls[i].transform.position.y > height)
            {
                side_walls[i].transform.position = new Vector3(0.0f, side_walls[i].transform.position.y + MAX_WALLS * height, 0);
                side_walls[i].GetComponent<SideWall>().SpawnObstacles(height, difficulty);
            }
        }
    }
}
