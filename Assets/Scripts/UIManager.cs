using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI")]
    public Text woodOutline;
    public Text wood;
    public Text ropeOutline;
    public Text rope;
    public Text ragsOutline;
    public Text rags;
    public Text subtitles;
    public Image timer;
    public GameObject map;
    public float uiTimer;
    public float uiTimerEnd;
    public bool timerActive;
    public bool showMap;
    public GameObject paused;

    [Header("References to other Scripts")]
    public Inventory inv;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        inv = GameObject.Find("Player").GetComponent<Inventory>();
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        woodOutline.text = wood.text = inv.wood.ToString() + "/12";
        ropeOutline.text = rope.text = inv.rope.ToString() + "/4";
        ragsOutline.text = rags.text = inv.rags.ToString() + "/1";
        timer.fillAmount = gm.timer / gm.timerStart;

        if(uiTimer > uiTimerEnd)
        {
            subtitles.color -= Color.white * 0.04f;

            if(subtitles.color.r <= 0f)
            {
                uiTimer = 0f;
                timerActive = false;
            }

        }
        else
        {
            if(timerActive)
                uiTimer += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.M) && gm.hasMap && gm.paused == false)
        {
            showMap = !showMap;
        }

        map.SetActive(showMap);
    }
}
