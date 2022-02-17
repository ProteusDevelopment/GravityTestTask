using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GamePauser : MonoBehaviour
    {
        private bool _paused = false;
        public void ChangePauseState()
        {
            _paused = !_paused;

            if (_paused)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
    }
}
