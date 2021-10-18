using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeIn : MonoBehaviour
{
    Image blackFade;
    RectTransform rectTransform;
    float alpha;


    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        blackFade = GetComponent<Image>();
        blackFade.canvasRenderer.SetAlpha(0.0f);

        Fade();
    }
    private void Update()
    {
        alpha = blackFade.canvasRenderer.GetAlpha();
        if (alpha >= 1)
        {
            SceneManager.LoadScene("Level");
        }

    }
    public void Fade()
    {
        rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        blackFade.CrossFadeAlpha(1, 3, false);
    }
}
    


