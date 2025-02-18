using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] GameObject _player;
    Vector2 _initialPos;
    Vector2 _targetPos;
    float _movementSpeed = 0.1f;
    bool _isWalking = false;

    void Start()
    {
        SetInitialPosition(_player.transform.position.x, _player.transform.position.y);
    }

    void Update()
    {
        
    }

    void SetInitialPosition(float x, float y)
    {
        _initialPos = new Vector2(x, y);
    }

    public void OnMouseClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!_isWalking)
            {
                StartCoroutine(Walk());
            }
            else
            {
                return;
            }
            
        }

        // actions usam contexto então a minha função tava sendo disparada 3x...
        //como eu quero apenas 1 click para ativar o movimento, só preciso do performed
        // https://discussions.unity.com/t/player-input-component-triggering-events-multiple-times/781922/7
        //if (context.started) Debug.LogWarning("onMouseClickStarted");
        //else if (context.performed) Debug.LogWarning("onMouseClickPerformed");
        //else if (context.canceled) Debug.LogWarning("onMouseClickCancelled");
    }

    public IEnumerator Walk()
    {
        // para pegar posição do mouse, o melhor a usar é Camera.main.ScreenToWorlPoint(Input.mousePosition).x ou y
        // https://stackoverflow.com/questions/33900150/object-doesnt-move-with-mouse-pointer

        _targetPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        float timeSinceStarted = 0f;
        while (true)
        {
            timeSinceStarted += Time.deltaTime; // Time.deltaTime para que o FPS não afete o ritmo da mudança

            _player.transform.position = Vector2.Lerp(_initialPos, _targetPos, Time.deltaTime * _movementSpeed);
            SetInitialPosition(_player.transform.position.x, _player.transform.position.y);

            if ((Vector2)_player.transform.position == _targetPos)
            {
                yield break; // jogador chegou ao destino
            }

            yield return null; // jogador ainda não chegou ao destino, continua no próximo Frame
        }
    }
}
