using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] Transform _player;
    float _movementSpeed = 0.5f;
    float _moveAccuracy = 0.01f;
    public Transform _movePoint;
    Coroutine _walkCoroutine;


    void Start()
    {
        _movePoint.parent = null; // para que o movepoint se movimente independente de player
    }

    void Update()
    {
    }
    public void OnMouseClick(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if(_walkCoroutine != null)
            {
                StopCoroutine(_walkCoroutine);
            }
            _walkCoroutine = StartCoroutine(Walk());
        }

        // actions usam contexto ent�o a minha fun��o tava sendo disparada 3x...
        //como eu quero apenas 1 click para ativar o movimento, s� preciso do performed
        // https://discussions.unity.com/t/player-input-component-triggering-events-multiple-times/781922/7
        //if (context.started) Debug.LogWarning("onMouseClickStarted");
        //else if (context.performed) Debug.LogWarning("onMouseClickPerformed");
        //else if (context.canceled) Debug.LogWarning("onMouseClickCancelled");
    }

    public IEnumerator Walk()
    {
        // para pegar posi��o do mouse, o melhor a usar � Camera.main.ScreenToWorlPoint(Input.mousePosition).x ou y
        // https://stackoverflow.com/questions/33900150/object-doesnt-move-with-mouse-pointer


        // para mover o personagem a uma velocidade constante
        // https://www.youtube.com/watch?v=EhALudpeNRQ&list=PLzskWQnp3wmYJb-a0-b-P1v0R_SFGCisn&index=7

            _movePoint.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
            Vector3 posDifference = _movePoint.position - _player.position;
            

            while (posDifference.magnitude > _moveAccuracy)
            {
                _player.Translate(_movementSpeed * posDifference.normalized * Time.deltaTime);
                posDifference = _movePoint.position - _player.position;
                yield return null;
            }

            _player.position = _movePoint.position;

            _walkCoroutine = null;
            yield return null;
    }
}
