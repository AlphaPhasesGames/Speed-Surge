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
        public bool runOnce;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (stage1TextMan.answerCorrect)
                {
                    if (!runOnce)
                    {
                        stage1TextMan.arrayPos = 15;
                        LOLSDK.Instance.SubmitProgress(0, 25, 100);
                        runOnce = true;
                        Debug.Log("Submit Progress ran once");
                    }

                }
            }
        }

        public IEnumerator CorrectAnswerCoRoutine()
        {
            //forwardButton.gameObject.SetActive(false);

            yield return new WaitForSeconds(5);
            stage1TextMan.forwardButton.gameObject.SetActive(true);
            // stage1TextMan.textPanal.gameObject.SetActive(true);
            stage1TextMan.arrayPos = 16;
           // stage1TextMan.hasScrolled = false;
           
            Debug.Log("This start coRoutine Runs");

        }
    }
}
