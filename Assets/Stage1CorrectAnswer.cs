using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoLSDK;

namespace SSGFE.Alpha.Phases.Games
{
    public class Stage1CorrectAnswer : MonoBehaviour
    {
        public Stage1TextManager stage1TextMan;
        // Start is called before the first frame update
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                stage1TextMan.answerCorrect = true;
            }
        }
    }
}
