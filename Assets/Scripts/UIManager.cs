using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text woodOutline;
    public Text wood;
    public Text ropeOutline;
    public Text rope;
    public Text ragsOutline;
    public Text rags;
    public Inventory inv;

    // Start is called before the first frame update
    void Start()
    {
        inv = GameObject.Find("Player").GetComponent<Inventory>();   
    }

    // Update is called once per frame
    void Update()
    {
        woodOutline.text = wood.text = inv.wood.ToString() + "/12";
        ropeOutline.text = rope.text = inv.rope.ToString() + "/4";
        ragsOutline.text = rags.text = inv.rags.ToString() + "/2";
    }
}
