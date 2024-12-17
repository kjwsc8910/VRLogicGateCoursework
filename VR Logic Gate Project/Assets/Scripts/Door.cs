using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{

    private Object door;
    public LogicComponent input;

    private Vector3 pos;
    public Vector3 dis;
    private bool moving = false;
    private bool open = false;

    void Start()
    {

        door = this.gameObject;

        pos = door.GetComponent<Transform>().localPosition;

    }

    void Update()
    {
        if (input.output)
        {
            MoveDoor(pos + dis);
        } else {
            MoveDoor(pos);
        }
    }

    void MoveDoor(Vector3 targ)
    {
        float dist = Vector3.Distance(transform.localPosition, targ);
        if (dist > 0.1f)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, targ, 1f * Time.deltaTime);
        }
	}
}
