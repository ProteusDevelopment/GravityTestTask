using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Game
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private GameObject _startText;

        private PlayerMovement _playerMovement;
        private GameScoreCounter _gameScoreCounter;

        private void Awake()
        {
            _playerMovement = FindObjectOfType<PlayerMovement>();
            _gameScoreCounter = FindObjectOfType<GameScoreCounter>();

            _playerMovement.enabled = false;
            _gameScoreCounter.enabled = false;
        }

        private void Update()
        {
            #if UNITY_STANDALONE
            if (Input.GetMouseButtonDown(0))
            #else
            if (Input.touchCount > 0)
            #endif
            {
                _playerMovement.enabled = true;
                _playerMovement.InitGravity();

                _gameScoreCounter.enabled = true;
                _gameScoreCounter.Init();

                Destroy(_startText);
                Destroy(gameObject);
            }
        }
    }
}
