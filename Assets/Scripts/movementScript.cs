using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    public float movementSpeed;
    public float rotacionSpeed;
    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 0.2f;
        rotacionSpeed = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, movementSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -movementSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, rotacionSpeed, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, -rotacionSpeed, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            this.gameObject.transform.position += this.gameObject.transform.right * movementSpeed;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            this.gameObject.transform.position += this.gameObject.transform.right * -movementSpeed;
        }

    }
}
