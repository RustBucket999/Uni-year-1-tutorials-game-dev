using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICursorFollowMouse : MonoBehaviour
{
    public RectTransform customCursor;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;

        customCursor.position = mousePosition;
    }
}
