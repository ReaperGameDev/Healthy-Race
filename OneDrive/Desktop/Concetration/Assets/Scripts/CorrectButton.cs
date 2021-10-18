using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectButton : MonoBehaviour
{
    public int correct = 0;
    public int incorrect = 0;
    RoundsManager roundsManager;
    void Start()
    {
        roundsManager = GetComponent<RoundsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (correct == roundsManager.round)
        {
            roundsManager.round++;
            roundsManager.StartNewRound();
            correct = 0;
        }
        if (incorrect > 0)
        {
            incorrect = 0;
            StartCoroutine("Wait");
            
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        roundsManager.StartNewRound();
    }
}
