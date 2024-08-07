using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SSGFE.Alpha.Phases.Games
{
    public class Stage1FrictionMotionManager : MonoBehaviour
    {
        public FirstStopTrigger stopTrigger;
        public NewCarController newCarCont;
        public Stage1TextManager textMan;
        public Button motionButt;
        public Button frictionButt;

        private void Awake()
        {
            motionButt.onClick.AddListener(ChooseMotion);
            frictionButt.onClick.AddListener(ChooseFriction);
        }
      
        public void ChooseMotion()
        {
            stopTrigger.wrongAnswer = false;
            textMan.textBool14 = false;
            textMan.arrayPos = 13;
            newCarCont.maxSpeed = 50;
            textMan.textBool15 = false;
        }

        public void ChooseFriction()
        {
            stopTrigger.wrongAnswer = true;
            textMan.arrayPos = 13;
            newCarCont.maxSpeed = 30;
        }
    }
}
