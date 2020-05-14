using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mmove : MonoBehaviour
{
    // Start is called before the first frame update
    CharacterController chr;
    public float rotatoSpeed = 25;
    public float moveSpeed = 25;
    private float fg = -9.8f;
    void Start()
    {
        chr = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 motion = Vector3.zero;
        if (chr.isGrounded)
        {
            MoveMent(out motion);
        }
        else
        {
            motion.y += fg;
        }
        chr.Move(motion);
    }
    public void MoveMent(out Vector3 motion)
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Rotate(0, rotatoSpeed * h * Time.deltaTime, 0);
        motion = transform.forward * v * moveSpeed;
    }
}
