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
            
            if(!GetComponent<AudioSource>().isPlaying)
                GetComponent<AudioSource>().Play();

            // Tree falling
            transform.localScale -= Vector3.one * Time.deltaTime;

            if(transform.localScale.x <= 0f)
            {
                Destroy(gameObject);
            }
        }         
    }

    private void OnDestroy()
    {
        // Add wood to inventory
        GameObject.Find("Player").GetComponent<Inventory>().wood++;
    }
}
