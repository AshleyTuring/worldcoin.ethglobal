using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentManager : MonoBehaviour
{
    [SerializeField] Transform[] contentParents;
    [SerializeField] GameObject contentPrefab;

    private void Start()
    {
        for (int y = 0; y < contentParents.Length; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                InstantiateContent(y);
            }
            if (contentParents[y].GetComponent<ScrollingObjectManager>())
            {
                contentParents[y].GetComponent<ScrollingObjectManager>().StartScrolling();
            }
        }
    }

    void InstantiateContent(int index)
    {
        GameObject newContent = Instantiate(contentPrefab, contentParents[index]);
        newContent.GetComponentInChildren<Image>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
}
