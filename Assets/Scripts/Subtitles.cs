using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subtitles : MonoBehaviour
{
    [TextArea(1, 2)]
    public string text;
    public int time;
    public bool triggered;
}
