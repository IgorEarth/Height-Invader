using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove2 : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _oldMousePositionX;
    private float _eulerY;

    [SerializeField] Animator _animator;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _oldMousePositionX = Input.mousePosition.x;
            _animator.SetBool("run", true);

        }


        if (Input.GetMouseButton(0))
        {
            Vector3 newPositon = transform.position + transform.forward * Time.deltaTime * _speed;
            newPositon.x = Mathf.Clamp(newPositon.x, -2.5f, 2.5f);
            transform.position = newPositon;
          
            float deltaX = Input.mousePosition.x - _oldMousePositionX;
            _oldMousePositionX = Input.mousePosition.x;

            _eulerY += deltaX;
            _eulerY = Mathf.Clamp(_eulerY, -70, 70);
            transform.eulerAngles = new Vector3(0, _eulerY, 0);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _animator.SetBool("run", false);
        }

        
    }
}
