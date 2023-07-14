using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using CodeMonkey.Utils;
using System.Diagnostics;

public class WindowGraph : MonoBehaviour
{

    private RectTransform graphContainer;
    [SerializeField]private Sprite circleSprite;

    public bool flag = false;
    // Start is called before the first frame update
    private void Start()
    {
        UnityEngine.Debug.Log("WindowGraph Start FUNCTON ");
    }
    private void Update()
    {
        UnityEngine.Debug.Log("WindowGraph Starting AWAKE FUNCTION ");
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        //CreateCircle(new Vector2(100, 100));

        List<int> valueList = new List<int>() /*{ 5, 98, 56, 45, 30, 22, 17, 15, 13, 17, 25, 37, 40, 36, 33 }*/;
        valueList = UserInfo.totalScores;
        UnityEngine.Debug.Log("WindowGraph Valuelist: "+valueList+" !! ");
        ShowGraph(valueList);
       
        

    }

    // Update is called once per frame
    private GameObject CreateCircle(Vector2 anchoredPosition)
    {
        GameObject gameObject = new GameObject("Circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(5, 5);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        return gameObject;

    }

    public void ShowGraph(List<int> valueList)
    {
        ClearGraph();
        float graphHeight = graphContainer.sizeDelta.y;
        float yMaximum = 110f;  //canvas y size
        float xSize = 25f;      //canvas x size

        GameObject lastCircleGameObject = null;
        for (int i = 0; i < valueList.Count; i++) 
        {
            float xPosition = xSize + i * xSize;
            float yPosition = (valueList[i] / yMaximum) * graphHeight;
            GameObject circleGameObject = CreateCircle(new Vector2 (xPosition, yPosition));
            if(lastCircleGameObject != null) 
            {
                CreateDotConnection(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);
            }
            lastCircleGameObject = circleGameObject;
        }
    }

    private void CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB)
    {
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, .5f);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 dir = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);
        rectTransform.anchorMin = new Vector2(0,0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, 3f);
        rectTransform.anchoredPosition = dotPositionA + dir * distance * 0.5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(dir));
    }

    private void ClearGraph()
    {
        // Destroy all child objects in the graph container
        for (int i = graphContainer.childCount - 1; i >= 0; i--)
        {
            if(graphContainer.GetChild(i).gameObject.name!="background")
            {
                Destroy(graphContainer.GetChild(i).gameObject);
            }
            //Destroy(graphContainer.GetChild(i).gameObject);
        }
    }

}
