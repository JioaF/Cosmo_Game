using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_ctrl : MonoBehaviour
{
    //idk what im doing
    public float speed = 0.5f;
    public float rotation = 0f;
    public float rotSpeed = 80;
    public float gravity = 8f;
    Vector3 moveDir = Vector3.zero;

    CharacterController char_ctrl;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        char_ctrl = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (char_ctrl.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                anim.SetInteger("conditionForward",1);
                moveDir = new Vector3(0,0,1);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                anim.SetInteger("conditionForward",0);
                moveDir = new Vector3(0,0,0);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                anim.SetInteger("conditionBack",1);
                moveDir = new Vector3(0,0,-1);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                anim.SetInteger("conditionBack",0);
                moveDir = new Vector3(0, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDir = new Vector3(0,2,0);
                moveDir *= speed;
               
            }
        }
        rotation += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0,rotation,0);

        moveDir.y -= gravity * Time.deltaTime;
        char_ctrl.Move(moveDir * Time.deltaTime);
    }
}
