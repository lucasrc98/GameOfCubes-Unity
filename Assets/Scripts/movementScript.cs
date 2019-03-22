using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    public float movementSpeed;
    public float rotacionSpeed;
    public float forceJump;
    bool jumping;
    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 0.2f;
        rotacionSpeed = 3.0f;
        forceJump = 80f;
        jumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)){
            transform.Translate(0, 0, movementSpeed);
        }
        if (Input.GetKey(KeyCode.S)){
            transform.Translate(0, 0, -movementSpeed);
        }
        if (Input.GetKey(KeyCode.A)){
            transform.Rotate(0, rotacionSpeed, 0);
        }
        if (Input.GetKey(KeyCode.D)){
            transform.Rotate(0, -rotacionSpeed, 0);
        }
        if (Input.GetKey(KeyCode.E)){
            this.gameObject.transform.position += this.gameObject.transform.right * movementSpeed;
        }
        if (Input.GetKey(KeyCode.Q)){
            this.gameObject.transform.position += this.gameObject.transform.right * -movementSpeed;
        }

        if (Input.GetKey(KeyCode.Space) && !jumping){
            this.gameObject.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.up * forceJump);
        }
        if (this.gameObject.transform.position.y < -10){
            this.gameObject.transform.position = new Vector3(0, 3, 0);

        }
       

    }

        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == "floor")
            {
                jumping = false;
                Debug.Log("jumping false");
            }
        }

        void OnCollisionExit(Collision col)
        {
            if (col.gameObject.tag == "floor")
            {
                jumping = true;
                Debug.Log("jumping true");
            }
        }

    private void OnCollisionStay(Collision col){
        if (col.gameObject.tag == "maca"){
            Destroy(col.gameObject);
        }
    }
}
