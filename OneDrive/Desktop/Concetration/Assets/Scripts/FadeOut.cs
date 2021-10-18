using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    Image blackFade;
    RectTransform rectTransform;
    float alpha;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        blackFade = GetComponent<Image>();
        blackFade.canvasRenderer.SetAlpha(1.0f);

        Fade();
    }
    private void Update()
    {
        alpha = blackFade.canvasRenderer.GetAlpha();
        if (alpha <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Fade()
    {
        rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        blackFade.CrossFadeAlpha(0, 3, false);
    }
}
