using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float speed = 0;
    public List<GameObject> move_objects = new List<GameObject>();
    public GameObject GameTimer;

    // Update is called once per frame
    void Update()
    {
        if (GameTimer.GetComponent<Timer>().timer_running == true) { return; }

        Vector3 new_pos = transform.position;
        new_pos.y += speed * Time.deltaTime;
        transform.position = new_pos;

        foreach (var obj in move_objects)
        {
            Vector3 new_obj_pos = obj.gameObject.transform.position;
            new_obj_pos.y += speed * Time.deltaTime;
            obj.gameObject.transform.position = new_obj_pos;
        }
    }
}
