using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed, jumpForce;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Rigidbody>().AddForce(new Vector3(moveForce, 0, 0));
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, moveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-moveSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -moveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(moveSpeed, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0));
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("碰撞發生：" + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Floor"))
        {

        }
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("碰撞持續：" + collision.gameObject.name);
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("碰撞結束：" + collision.gameObject.name);
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
