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
    public float footstepTimer = 0f;

    [Header("Audio Clips")]
    public AudioClip sandClip;
    public AudioClip grassClip;
    public AudioClip grassClip2;
    public AudioClip stoneClip;

    [Header("Ref")]
    public AudioSource footsteps;
    public TerrainCheck terrainCheck;

    private void FixedUpdate()
    {
        // Movement
        float sprint = Input.GetKey(KeyCode.LeftShift) ? sprintMultiplier : 1f;
        float xMove = Input.GetAxis("Horizontal") * speed * sprint;
        float zMove = Input.GetAxis("Vertical") * speed * sprint;
        bool isMoving = Mathf.Abs(Input.GetAxis("Horizontal")) > 0 || Mathf.Abs(Input.GetAxis("Vertical")) > 0;
        transform.Translate(xMove, 0, zMove);

        // Jump & Grounded Check
        Ray r = new Ray(transform.position - new Vector3(0, 2.2f, 0), Vector3.down);
        Debug.DrawRay(r.origin, r.direction * 2f);
        isGrounded = Physics.Raycast(r, 1.5f, 1 << 9);

        if (Input.GetAxis("Jump") > 0 && isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(0, jumpHeight * Time.deltaTime, 0);
        }

        // Footstep Sounds
        switch(terrainCheck.surfaceIndex)
        {
            case 0: footsteps.clip = sandClip; break;
            case 1: footsteps.clip = grassClip; break;
            case 2: footsteps.clip = stoneClip; break;
            case 3: footsteps.clip = grassClip2; break;
        }

        if(isMoving)
        {
            footstepTimer += Time.fixedDeltaTime;

            if(footstepTimer > (0.6f / sprintMultiplier))
            {
                footsteps.Play();
                footstepTimer = 0f;
            }
        }
        else
        {
            footstepTimer = 0f;
        }
    }
}
