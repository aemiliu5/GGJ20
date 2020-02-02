using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Materials")]
    public int wood;
    public int rope;
    public int rags;

    [Header("Game Objects")]
    public GameObject axe;

    [Header("Tree Collecting")]
    public bool inTree;
    public float treeTimer;
    public float treeTimerEnd;
    public float axeTimer;
    public bool treeBroken;
    public GameObject treeGO;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Axe"))
        {
            axe.SetActive(true);
            GetComponent<PlayerController>().pickup.clip = GetComponent<PlayerController>().pickupClip1;
            GetComponent<PlayerController>().pickup.Play();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Tree"))
        {
            inTree = true;
            treeGO = other.gameObject;
        }

        if (other.gameObject.CompareTag("Rope"))
        {
            rope++;
            GetComponent<PlayerController>().pickup.clip = GetComponent<PlayerController>().pickupClip2;
            GetComponent<PlayerController>().pickup.Play();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Rag"))
        {
            rags++;
            GetComponent<PlayerController>().pickup.clip = GetComponent<PlayerController>().pickupClip3;
            GetComponent<PlayerController>().pickup.Play();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Map"))
        {
            FindObjectOfType<GameManager>().hasMap = true;
            GetComponent<PlayerController>().pickup.clip = GetComponent<PlayerController>().pickupClipMap;
            GetComponent<PlayerController>().pickup.Play();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Subtitles"))
        {
            if(!other.GetComponent<Subtitles>().triggered)
            {
                FindObjectOfType<UIManager>().subtitles.text = other.GetComponent<Subtitles>().text;
                FindObjectOfType<UIManager>().subtitles.color = Color.white;
                FindObjectOfType<UIManager>().timerActive = true;
                FindObjectOfType<UIManager>().uiTimer = 0f;
                FindObjectOfType<UIManager>().uiTimerEnd = other.GetComponent<Subtitles>().time;
                other.GetComponent<Subtitles>().triggered = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {
            inTree = false;

            if(!treeBroken)
                treeGO = null;
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
                axeTimer += Time.deltaTime;

                if (inTree)
                {
                    treeTimer += Time.deltaTime;

                    if (axeTimer > 0.5f)
                    {
                        AudioClip[] randomChopSound = { GetComponent<PlayerController>().chopClip1, GetComponent<PlayerController>().chopClip2, GetComponent<PlayerController>().chopClip3 };

                        GetComponent<PlayerController>().pickup.clip = randomChopSound[Random.Range(0, 3)];
                        GetComponent<PlayerController>().pickup.Play();
                        axeTimer = 0f;
                    }
                }
                else
                {
                    treeTimer = 0f;

                    if (axeTimer > 0.5f)
                    {
                        GetComponent<PlayerController>().pickup.clip = GetComponent<PlayerController>().airChopClip;
                        GetComponent<PlayerController>().pickup.Play();
                        axeTimer = 0f;
                    }
                }

                if(treeTimer >= treeTimerEnd)
                {
                    if(treeGO)
                        treeGO.GetComponent<Tree>().isBroken = true;
                }
            }
            else
            {
                axe.GetComponent<Animator>().Play("Axe_Idle");
                treeTimer = 0f;
                axeTimer = 0f;
            }
        }

        if(wood >= 10 && rope >= 3 && rags >= 1)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
    }
}
