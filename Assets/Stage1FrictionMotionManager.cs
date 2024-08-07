using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SSGFE.Alpha.Phases.Games
{
    public class Stage1FrictionMotionManager : MonoBehaviour
    {
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
            textMan.arrayPos = 13;
        }

        public void ChooseFriction()
        {
            textMan.arrayPos = 13;
        }
    }
}
