using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _gravity = -20f;

        private Rigidbody2D _rigidbody;
        private Vector2 _currentGravity = Vector2.zero;

        public float Speed => _speed;

        public void InitGravity()
        {
            _rigidbody = GetComponent<Rigidbody2D>();

            _currentGravity.y = _gravity;
            Physics2D.gravity = _currentGravity;

            _rigidbody.isKinematic = false;
        }

        private void Update()
        {
            #if UNITY_STANDALONE
            if (Input.GetMouseButtonDown(0))
            #else
            if (Input.touchCount > 0)
            #endif
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    ReverseGravity();
                }
            }

            Move();
        }

        private void ReverseGravity()
        {
            _currentGravity = Physics2D.gravity = -_currentGravity;
        }

        private void Move()
        {
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
        }
    }
}
