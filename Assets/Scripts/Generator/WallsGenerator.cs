using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sections;

namespace Generator
{
    public class WallsGenerator : MonoBehaviour
    {
        private const string SectionsPath = "Sections";

        [SerializeField] private Transform _wallsParent;
        [SerializeField] private Vector2Int _scaleRandomRange;

        private Section[] _loadedSections = null;
        private LinkedList<Section> _walls = new LinkedList<Section>();

        private void Start()
        {
            LoadSections();

            AddExistsWalls();
        }

        private void LoadSections()
        {
            _loadedSections = Resources.LoadAll<Section>(SectionsPath);
        }

        private void AddExistsWalls()
        {
            for (int i = 0; i < _wallsParent.childCount; i++)
            {
                _walls.AddLast(_wallsParent.GetChild(i).GetComponent<Section>());
            }
        }

        public void GenerateNext()
        {
            Section section = Instantiate(_loadedSections[Random.Range(0, _loadedSections.Length)], _wallsParent);

            SetSectionLenght(section);
            SetSectionPosition(section);

            _walls.AddLast(section);
            DestroyFirstSection();
        }

        private void SetSectionLenght(Section section)
        {
            int sectionLenght = Random.Range(_scaleRandomRange.x, _scaleRandomRange.y);
            section.SetLenght(sectionLenght);
        }

        private void SetSectionPosition(Section section)
        {
            Section lastSection = _walls.Last.Value;
            Transform lastSectionTransform = lastSection.transform;
            section.transform.localPosition =
                new Vector3(lastSectionTransform.localPosition.x + lastSection.WallsLenght, lastSectionTransform.localPosition.y, lastSectionTransform.localPosition.z);
        }

        private void DestroyFirstSection()
        {
            Section first = _walls.First.Value;
            _walls.RemoveFirst();
            Destroy(first.gameObject, 2f);
        }
    }
}
