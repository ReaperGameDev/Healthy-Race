using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameScene : MonoBehaviour
{
    [SerializeField] private GameObject fadeIn;
    
    public void CreateFadeIn()
    {
        var fade = Instantiate(fadeIn);
        fade.transform.parent = gameObject.transform;
    }
}
