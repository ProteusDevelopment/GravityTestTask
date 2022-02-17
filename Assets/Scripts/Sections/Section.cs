using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sections
{
    public class Section : MonoBehaviour
    {
        [SerializeField] protected Transform _walls;

        public float WallsLenght => _walls.localScale.x;

        public void SetLenght(float lenght)
        {
            _walls.localScale = new Vector3(lenght, _walls.localScale.y, _walls.localScale.z);
            _walls.localPosition = new Vector3(lenght / 2f, _walls.localPosition.y, _walls.localPosition.z);
        }
    }
}
