using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float movementSpeed;
    public float rotacionSpeed;
    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 1.0f;
        rotacionSpeed = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("W"))
        {
            transform.Translate(0, 0, movementSpeed);
        }
        if (Input.GetButton("S"))
        {
            transform.Translate(0, 0, -movementSpeed);
        }
        if (Input.GetButton("A"))
        {
            transform.Rotate(0, rotacionSpeed, 0);
        }
        if (Input.GetButton("D"))
        {
            transform.Rotate(0, -rotacionSpeed, 0);
        }

    }
}
