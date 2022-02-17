using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Player;

namespace Game
{
    public class GameScoreCounter : MonoBehaviour
    {
        [SerializeField] private Text _scoreValueText;

        private float _scoreAddition;
        private float _currentScore = 0;

        public void Init()
        {
            _scoreAddition = FindObjectOfType<PlayerMovement>().Speed;
        }

        private void Update()
        {
            _currentScore += _scoreAddition * Time.deltaTime;
            
            UpdateScoreValueText();
        }

        private void UpdateScoreValueText()
        {
            _scoreValueText.text = Mathf.FloorToInt(_currentScore).ToString();
        }
    }
}
