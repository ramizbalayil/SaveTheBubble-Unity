using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWall : MonoBehaviour
{
    public GameObject ObstacleWall;
    public GameObject Coin;
    List<GameObject> reuse_objects = new List<GameObject>();

    private const float MAX_Y = 6f;
    private const float MIN_Y = -13f;

    public void SpawnObstacles(float height, int difficulty)
    {
        foreach (var obj in reuse_objects)
        {
            Destroy(obj);
        }

        for (int i = 0; i <= difficulty; i++)
        {
            GameObject current_child = Instantiate(ObstacleWall, transform);
            Vector3 new_pos = current_child.transform.position;
            new_pos.x += Random.Range(-1.3f, 1.3f);
            new_pos.y = transform.position.y + (MAX_Y + MIN_Y) / 2 + getOffsetFromMidpoint(i, height, difficulty);
            current_child.transform.position = new_pos;
            reuse_objects.Add(current_child);
            GameObject collectible = Instantiate(Coin, new Vector3(new_pos.x, new_pos.y - height / 4), Quaternion.identity);
            reuse_objects.Add(collectible);
        }
    }

    private float getOffsetFromMidpoint(int i, float height, int difficulty)
    {
        return height / 4 * difficulty * Mathf.Pow(-1, i);
    }
}
