using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WinnerButton : MonoBehaviour
{
    public bool imAWinner=false;
    private bool canBeClicked = false;
    CorrectButton correctButton;
    private void Start()
    {
        correctButton = GetComponentInParent<CorrectButton>();
    }
    IEnumerator ShowWinnerItem()
    {
        if (imAWinner)
        {
            this.GetComponent<Image>().color = Color.red;          
        }
        yield return new WaitForSeconds(3f);
        canBeClicked = true;
        this.GetComponent<Image>().color = Color.white;
    }

    public void onClickedButton()
    {
        if (canBeClicked)
        {
            if (imAWinner)
            {
                this.GetComponent<Image>().color = Color.green;
                correctButton.correct++;
            }
            else
            {
                this.GetComponent<Image>().color = Color.black;
                correctButton.incorrect++;
            }
        }
    }
    public void CallCorutine()
    {
        canBeClicked = false;
        StartCoroutine("ShowWinnerItem");
    }
}
