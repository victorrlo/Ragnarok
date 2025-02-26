using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimBehaviour : MonoBehaviour
{
    [SerializeField] Grid _grid;
    public void OnMouseMovement(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            var targetPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            this.gameObject.transform.position = targetPos;
        }

        // if (context.performed)
        // {
        //     var mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            
        //     float snappedX = Mathf.Round(mousePosition.x * _grid.cellSize.x) * _grid.cellSize.x;
        //     float snappedY = Mathf.Round(mousePosition.y * _grid.cellSize.y) * _grid.cellSize.y;

        //     transform.position = new Vector2(snappedX, snappedY);
        // }
    }
}
