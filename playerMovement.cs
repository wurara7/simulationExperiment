using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    float rotationX;
    float rotationY;
    public float sensitivityHor = 5.0f;
    public float sensitivityVert = 5.0f;
    public float minVert = -45.0f;
    public float maxVert = 45.0f;

    public float speed = 10f;
    public float smoothTime = 0.1f;
    Vector3 velocity;

   static bool isMove;
    void getVelocity()
    {
        Vector3 direction = Vector3.zero;
        direction = new Vector3(Input.GetAxisRaw("Horizontal"),0, Input.GetAxisRaw("Vertical"));
        if (Input.GetKey(KeyCode.Space))
            direction += Vector3.up ;
        if (Input.GetKey(KeyCode.LeftControl))
            direction += Vector3.down ;
        velocity = direction.normalized*speed*Time.deltaTime;
    }
    void camerRotetion()
    {
        //0是左键，1是右
        if (Input.GetMouseButton(1))
            {
                rotationY = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityHor;
                rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
                rotationX = Mathf.Clamp(rotationX, minVert, maxVert);
                transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
                transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }
    }

    public static void setIsMove(bool judge)
    {
        isMove = judge;
    }
    void Update()
    {
        if (isMove)
        {
            camerRotetion();
            getVelocity();
            transform.Translate(velocity);
        }
    }

}
