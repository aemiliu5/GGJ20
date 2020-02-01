using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public float fadeTimer;
    public bool isBroken;

    // Update is called once per frame
    void Update()
    {
        if(isBroken)
        {
            fadeTimer += Time.deltaTime;

            // Tree falling
            if(!GetComponent<Rigidbody>())
            {
                gameObject.AddComponent(typeof(Rigidbody));
            }
            else
            {
                GetComponent<Rigidbody>().mass = 5;
                GetComponent<Rigidbody>().AddForce(transform.right * 50f);
            }

            if (fadeTimer > 3.5f)
                GetComponent<Renderer>().material.color -= new Color(0, 0, 0, 0.05f);
        }

        if(GetComponent<Renderer>().material.color.a <= 0f)
        {
            Destroy(gameObject, 0.25f);
        }
    }

    private void OnDestroy()
    {
        // Add wood to inventory
        GameObject.Find("Player").GetComponent<Inventory>().wood++;
    }
}
