using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Fade : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI regoinName;

    private float fadeTime;

    private bool fading;

    // Start is called before the first frame update
    void Start()
    {
        regoinName.CrossFadeAlpha(0, 0.5f, false);
        fadeTime = 0f;
        fading = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (fading)
        {
            FadeIn();
        }
        else if (regoinName.color.a != 0)
        {
            regoinName.CrossFadeAlpha(0, 0.5f, false);
        }
    }

    private void FadeIn()
    {
        regoinName.CrossFadeAlpha(1, 0.5f, false);
        fadeTime += Time.deltaTime;
        if (regoinName.color.a == 1 && fadeTime > 1.5f)
        {
            fading = false;
            fadeTime = 0f;
        }
    }
}
