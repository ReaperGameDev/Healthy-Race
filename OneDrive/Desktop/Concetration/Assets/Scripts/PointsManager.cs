using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    [SerializeField] private Text pointsText;
    RoundsManager roundsManager;
    int round, points;
    void Start()
    {
        roundsManager = GetComponent<RoundsManager>();
        round = roundsManager.round;
        points += round * 100;
    }

    // Update is called once per frame
    void Update()
    {   
        pointsText.text = ""+points;
    }
}
