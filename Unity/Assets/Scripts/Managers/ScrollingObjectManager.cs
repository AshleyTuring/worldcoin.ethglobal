using System.Collections;
using UnityEngine;

public class ScrollingObjectManager : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 10f;

    GameObject objectComponent;
    GameObject clonedObjectComponent;

    bool isScrolling;

    RectTransform objectRectTransform;

    float width;
    Vector3 startPos;
    float scrollPos = 0;

    private void Update()
    {
        if (isScrolling)
        {
            objectRectTransform.anchoredPosition = new Vector3(-scrollPos % width, startPos.y, startPos.z);

            scrollPos += scrollSpeed * 20 * Time.deltaTime;
        }
    }

    public void StartScrolling()
    {
        StartCoroutine(StartAfterNextFrame());
    }

    IEnumerator StartAfterNextFrame()
    {
        yield return new WaitForEndOfFrame();

        objectComponent = this.gameObject;

        objectRectTransform = objectComponent.GetComponent<RectTransform>();

        startPos = objectRectTransform.anchoredPosition;

        width = objectRectTransform.rect.width;
        scrollPos = 0;
        objectRectTransform.anchoredPosition = startPos;

        clonedObjectComponent = Instantiate(objectComponent, objectComponent.transform);
        Destroy(clonedObjectComponent.GetComponent<ScrollingObjectManager>());
        isScrolling = true;
    }
}
