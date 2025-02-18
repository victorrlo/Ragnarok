using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PointerBehaviour : MonoBehaviour
{
    [SerializeField] GameObject _pointer;
    Vector2 _targetPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseMovement(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _targetPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            _pointer.transform.position = _targetPos;
        }
    }
}
