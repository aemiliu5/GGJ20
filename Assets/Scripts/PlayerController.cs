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
    public AudioClip jumpClip;
    public AudioClip pickupClip1;
    public AudioClip pickupClip2;
    public AudioClip pickupClip3;
    public AudioClip pickupClipMap;
    public AudioClip chopClip1;
    public AudioClip chopClip2;
    public AudioClip chopClip3;

    [Header("Ref")]
    public AudioSource footsteps;
    public AudioSource voice;
    public AudioSource pickup;
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
        Debug.DrawRay(r.origin, r.direction * 1.6f);
        isGrounded = Physics.Raycast(r, 1.6f, 1 << 9);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(0, jumpHeight * Time.deltaTime, 0);
            voice.clip = jumpClip;
            voice.Play();
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

            if(footstepTimer > (0.6f / sprint))
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
