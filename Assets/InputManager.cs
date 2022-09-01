using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager : MonoBehaviour
{
    private Vector3 mouseStartPosition;
    private Vector3 mouseEndPosition;
    public Vector3 direction;
    public float Sensitivity;

    #region instance (Singelton)
    public static InputManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseStartPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0))
        {
            mouseEndPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            direction = mouseEndPosition - mouseStartPosition;
            

            mouseStartPosition = mouseEndPosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            direction = Vector3.zero;
        }
    }
}
