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

                transform.localScale -= new Vector3(0.025f, 0.025f, 0.025f);

                if(transform.localScale.x <= 0f)
                {
                    Destroy(gameObject);
                }
            }         
        }
    }

    private void OnDestroy()
    {
        // Add wood to inventory
        GameObject.Find("Player").GetComponent<Inventory>().wood++;
    }
}
