using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Timer")]
    public float timer;
    public float timerStart;

    [Header("Pause")]
    public bool paused;
    public bool hasMap;

    [Header("References")]
    public UIManager ui;

    // Start is called before the first frame update
    void Start()
    {
        timer = timerStart;
        ui = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0f)
        {
            Debug.Log("You lose :(");
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    private void Pause()
    {
        paused = !paused;

        if(paused)
        {
            Time.timeScale = 0f;
            ui.paused.SetActive(true);

            foreach(SmoothMouseLook m in FindObjectsOfType<SmoothMouseLook>())
            {
                m.enabled = false;
            }
        }
        else
        {
            Time.timeScale = 1f;
            ui.paused.SetActive(false);

            foreach (SmoothMouseLook m in FindObjectsOfType<SmoothMouseLook>())
            {
                m.enabled = true;
            }
        }
    }
}
