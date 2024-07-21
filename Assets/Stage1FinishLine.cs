using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LoLSDK;

namespace SSGFE.Alpha.Phases.Games
{
    public class Stage1FinishLine : MonoBehaviour
    {

        public Stage1TextManager stage1TextMan;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (stage1TextMan.answerCorrect)
                {
                    stage1TextMan.hasScrolled = false;
                    stage1TextMan.restrictionBool1 = true;
                    stage1TextMan.arrayPos = 17;
                   // stage1TextMan.forwardParent.gameObject.SetActive(false);
                    stage1TextMan.forwardButton.gameObject.SetActive(false);
                    StartCoroutine(CorrectAnswerCoRoutine());
                }

                if (!stage1TextMan.answerCorrect)
                {
                    stage1TextMan.restrictionBool2 = true;
                    stage1TextMan.hasScrolled = false;
                    stage1TextMan.arrayPos = 19;
                }
            }
        }

        public IEnumerator CorrectAnswerCoRoutine()
        {
            //forwardButton.gameObject.SetActive(false);

            yield return new WaitForSeconds(5);
            stage1TextMan.forwardButton.gameObject.SetActive(true);
            // stage1TextMan.textPanal.gameObject.SetActive(true);
            stage1TextMan.arrayPos = 21;
           // stage1TextMan.hasScrolled = false;
           
            Debug.Log("This start coRoutine Runs");

        }
    }
}
