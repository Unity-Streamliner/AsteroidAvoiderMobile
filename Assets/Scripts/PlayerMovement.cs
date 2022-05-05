using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class PlayerMovement : MonoBehaviour
{
    private Camera mainCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Touch.activeTouches.Count == 0)
        {
            return;
        }

        Vector2 touchPosition = Touch.activeTouches[0].screenPosition;
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);
        Debug.Log($"World Position {worldPosition}, position={touchPosition}");
    }
}
