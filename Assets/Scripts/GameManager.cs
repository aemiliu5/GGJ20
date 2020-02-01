using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Timer")]
    public float timer;
    public float timerStart;

    // Start is called before the first frame update
    void Start()
    {
        timer = timerStart;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0f)
        {
            Debug.Log("You lose :(");
        }
    }
}
