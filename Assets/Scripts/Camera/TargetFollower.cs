using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Camera
{
    public class TargetFollower : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        private void LateUpdate()
        {
        Vector3 position = transform.position;

        position.x = _target.position.x;

        transform.position = position; 
        }
    }
}
