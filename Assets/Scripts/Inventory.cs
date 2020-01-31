using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Materials")]
    public int wood;
    public int rope;
    public int sail;

    [Header("Game Objects")]
    public GameObject axe;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Axe"))
        {
            axe.SetActive(true);
            Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        // Axe Attack
        if (axe.activeSelf)
        {
            if (Input.GetMouseButton(0))
            {
                axe.GetComponent<Animator>().Play("Axe");
            }
            else
            {
                axe.GetComponent<Animator>().Play("Axe_Idle");
            }
        }
    }
}
