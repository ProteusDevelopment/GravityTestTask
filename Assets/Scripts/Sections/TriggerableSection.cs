using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Generator;

namespace Sections
{
    public class TriggerableSection : Section
    {
        private WallsGenerator _wallsGenerator;

        private void Start()
        {
            _wallsGenerator = FindObjectOfType<WallsGenerator>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _wallsGenerator.GenerateNext();
            }
        }
    }
}
