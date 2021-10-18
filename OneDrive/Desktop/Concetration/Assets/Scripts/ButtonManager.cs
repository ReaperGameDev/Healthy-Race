using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject buttonPrefab;

    [SerializeField] private float elementsSizes;

    [SerializeField] private int randomButton;
    [SerializeField] private int elementsQuantityX;
    [SerializeField] private int elementsQuantityY;

    public List<GameObject> elements = new List<GameObject>();
    public List<GameObject> winnerElements = new List<GameObject>();

    private List<int> winnerButtons = new List<int>();
    private RoundsManager roundsManager;
    private float distanceX = 0;
    private float distanceY = 0;
    public int elementsQuantity;


    public int roundNumber;
    int n = 0;
    int y = 0;

    public bool newRoundStarted;
    private void Awake()
    {
        elementsQuantity = elementsQuantityX * elementsQuantityY;
        roundsManager = GetComponent<RoundsManager>();
        roundNumber = roundsManager.round;
        GenerateButtons();
    }

    public void GenerateButtons()
    {
        for (int i = 0; i <= elementsQuantity; i++)
        {
            elements.Add(Instantiate(buttonPrefab));
            elements[i].name = "Boton " + i;
            elements[i].transform.parent = gameObject.transform;
            elements[i].GetComponent<RectTransform>().sizeDelta = new Vector2(elementsSizes, elementsSizes);
            elements[i].GetComponent<RectTransform>().localPosition = new Vector2(distanceX, distanceY);
            if (n <= elementsQuantityX)
            {
                distanceX = distanceX + elementsSizes;
                n++;
            }
            if (y >= elementsQuantityX - 1)
            {
                distanceY = distanceY + elementsSizes;
                distanceX = 0;
                y = 0;
                n = 0;
            }
            else
            {
                y++;
            }
        }
        Destroy(elements[elements.Count - 1]);
    }
    public void WinnersButtons()
    {
        winnerButtons.Clear();
        winnerElements.Clear();

        for (int i=0;i <= roundNumber-1; i++)
        {
            do
            {
                randomButton = Random.Range(0, elementsQuantity - 1);
            } while (winnerButtons.Contains(randomButton));
            winnerButtons.Add(randomButton);
            elements[randomButton].GetComponent<WinnerButton>().imAWinner = true;
            winnerElements.Add(elements[randomButton]);
        }
    }
}