using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimBehaviour : MonoBehaviour
{
    public void OnMouseMovement(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            var targetPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            this.gameObject.transform.position = targetPos;
        }
    }
}
