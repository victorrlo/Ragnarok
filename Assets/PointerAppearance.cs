using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerAppearance : MonoBehaviour
{
    [SerializeField] Texture2D _pointer;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(_pointer, Vector2.zero, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
