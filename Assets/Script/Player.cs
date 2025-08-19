using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    public float moveSpeed, jumpForce;
    public bool isMove, isJump, isAttack;
    public float H, V;
    public float oriMoveSpeed;
    public BoxCollider myBC;
    public ParticleSystem myPS;
    public AudioSource attackSound;
    float Y, Z;
    Animator anim;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        anim = GetComponent<Animator>();
        isMove = false;
        isJump = false;
        isAttack = false;
        oriMoveSpeed = moveSpeed;
        Y = cam.transform.position.y - transform.position.y;
        Z = transform.position.z - cam.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = new Vector3(transform.position.x, transform.position.y + Y, transform.position.z - Z);
        H = Input.GetAxis("Horizontal");
        V = Input.GetAxis("Vertical");

        transform.Translate(H * moveSpeed, 0, V * moveSpeed);
        if (H != 0)
        {
            anim.SetFloat("MoveSpeed", Mathf.Abs(H));
        }
        if (V != 0)
        {
            anim.SetFloat("MoveSpeed", Mathf.Abs(V));
        }
        if (H == 0 && V == 0)
        {
            anim.SetFloat("MoveSpeed", 0);
        }
        if (Input.GetButtonDown("Fire1") && !isJump)
        {
            anim.SetTrigger("Attack");
            isAttack = true;
            moveSpeed = 0;
        }
        //GetComponent<Rigidbody>().AddForce(new Vector3(moveForce, 0, 0));
        /*if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, moveSpeed);
            isMove = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-moveSpeed, 0, 0);
            isMove = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -moveSpeed);
            isMove = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(moveSpeed, 0, 0);
            isMove = true;
        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            isMove = false;
        }
        anim.SetBool("Move", isMove);*/
        if (Input.GetKeyDown(KeyCode.Space) && !isAttack)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0));
            isJump = true;
            anim.SetBool("Air", true);

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("碰撞發生：" + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Floor"))
        {
            anim.SetBool("Air", false);
            isJump = false;
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
    public void AttackEnd()
    {
        moveSpeed = oriMoveSpeed;
        isAttack = false;
    }
    public void hitStart()
    {
        myBC.enabled = true;
        myPS.Play(true);
        if (attackSound != null)
        {
            attackSound.Play();
        }
    }
    public void hitEnd()
    {
        myBC.enabled = false;
    }
    private void test()
    {
        
    }
}
