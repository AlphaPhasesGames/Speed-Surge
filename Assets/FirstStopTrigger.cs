using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SSGFE.Alpha.Phases.Games
{
    public class FirstStopTrigger : MonoBehaviour
    {
        public NewCarController newCarCont;
        public Stage1TextManager stage1TextMan;
        public bool wrongAnswer;
        public bool runOnce;
        public bool runTwice;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
               // if (!runOnce)
              //  {
                    if (!stage1TextMan.answerCorrect)
                    {
                    //  newCarCont.StartStopCar();
                        stage1TextMan.runOnce = false;
                        newCarCont.isCarActive = true;
                        stage1TextMan.hasScrolled = false;
                        stage1TextMan.textPanal.gameObject.SetActive(true);
                        stage1TextMan.arrayPos = 17;
                       // StartCoroutine(ReserCar());
                        newCarCont.skate.mute = false;
                   // stage1TextMan.answerCorrect = false;
                    newCarCont.skate.volume = 0;
                      //  runOnce = true;
                    }
              //  }

                //if (!runTwice)
                //{
                    if (stage1TextMan.answerCorrect)
                    {
                        //  newCarCont.StartStopCar();
                        newCarCont.isCarActive = true;
                        stage1TextMan.hasScrolled = false;
                        stage1TextMan.textPanal.gameObject.SetActive(true);
                        stage1TextMan.arrayPos = 19;
                       // stage1TextMan.answerCorrect = true;
                        newCarCont.skate.mute = false;
                        newCarCont.skate.volume = 0;
                       // runTwice = true;
                    }
               // }
               
               
            }

        }

        public IEnumerator ReserCar()
        {
            yield return new WaitForSeconds(0.5f);
            newCarCont.isCarActive = false;
        }
    }
}
