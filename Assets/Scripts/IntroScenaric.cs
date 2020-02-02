using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroScenaric : MonoBehaviour
{
    public Image background;
    public Image lightning;
    public Image fade;
    public AudioSource src;
    public AudioClip thunder;
    public AudioClip boatCrash;
    public AudioClip rain;
    public AudioClip ambience;
    public RectTransform backgroundCoords;
    public Sprite bg1;
    public Sprite bg2;
    public bool moving;
    public bool fadingIn;
    public bool fadingOut;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Cutscene");
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            if(background.sprite == bg1)    backgroundCoords.position -= new Vector3(0.05f, 0, 0);
            else                            backgroundCoords.position += new Vector3(0.05f, 0, 0);
        }


        if(fadingIn)
        {
            fade.color -= Color.black / 100f;

            if(fade.color.a < 0f)
            {
                fadingIn = false;
            }
        }

        if (fadingOut)
        {
            fade.color += Color.black / 100f;

            if (fade.color.a > 0.99f)
            {
                fadingOut = false;

                if (background.sprite == bg2)
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene(1);
                }
            }


        }
    }

    IEnumerator Cutscene()
    {
        FadeIn();
        src.PlayOneShot(rain);
        yield return new WaitForSecondsRealtime(0.5f);
        moving = true;
        yield return new WaitForSecondsRealtime(3f);
        lightning.color += new Color(0, 0, 0, 0.2f);
        src.PlayOneShot(thunder);
        yield return new WaitForSecondsRealtime(0.1f);
        lightning.color -= new Color(0, 0, 0, 0.2f);
        yield return new WaitForSecondsRealtime(4f);
        FadeOut();
        yield return new WaitForSecondsRealtime(3f);
        background.sprite = bg2;
        src.Stop();
        src.PlayOneShot(ambience);
        yield return new WaitForSecondsRealtime(0.5f);
        src.PlayOneShot(boatCrash);
        yield return new WaitForSecondsRealtime(0.5f);
        FadeIn();
        yield return new WaitForSecondsRealtime(4f);
        FadeOut();
    }

    void FadeIn()
    {
        fadingIn = true;
    }

    void FadeOut()
    {
        fadingOut = true;
    }
}
