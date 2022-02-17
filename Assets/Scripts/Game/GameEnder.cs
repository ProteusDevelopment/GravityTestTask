using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class GameEnder : MonoBehaviour
    {
        [SerializeField] private GameObject _endText;
        [SerializeField] private GameObject _pauserObject;

        private bool _ending = false;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _endText.SetActive(true);
                _pauserObject.SetActive(false);
                Time.timeScale = 0f;
                _ending = true;
            }
        }

        private void Update()
        {
            if (!_ending)
            {
                return;
            }

            #if UNITY_STANDALONE
            if (Input.GetMouseButtonDown(0))
            #else
            if (Input.touchCount > 0)
            #endif
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
