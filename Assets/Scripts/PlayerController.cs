using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public float jumpHeight;
    public float sprintMultiplier;
    public bool isGrounded;

    // Update is called once per frame
    private void Update()
    {
        // Movement
        float sprint = Input.GetKey(KeyCode.LeftShift) ? sprintMultiplier : 1f;
        float xMove = Input.GetAxis("Horizontal") * speed * sprint * Time.deltaTime;
        float zMove = Input.GetAxis("Vertical") * speed * sprint * Time.deltaTime;
        transform.Translate(xMove, 0, zMove);
    }

    private void FixedUpdate()
    {
        // Jump & Grounded Check
        Ray r = new Ray(transform.position - new Vector3(0, 2.2f, 0), Vector3.down);
        Debug.DrawRay(r.origin, r.direction * 2f);
        isGrounded = Physics.Raycast(r, 1.5f, 1 << 9);

        Debug.Log(Physics.Raycast(r, 1.5f, 1 << 9));

        if (Input.GetAxis("Jump") > 0 && isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(0, jumpHeight * Time.deltaTime, 0);
        }
    }
}
