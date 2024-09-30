using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SSGFE.Alpha.Phases.Games
{
    public class Stage3RestartCollider : MonoBehaviour
    {
        public NewCarControllerStage3 newCarCont;
       // public Stage2TextMan stage1TextMan;
        public bool wrongAnswer;
        public bool runOnce;
        public bool runTwice;

        public GameObject carRoation;
        public GameObject carObject;
        public BoxCollider triggerBox;

        private void Update()
        {
 
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {

                    newCarCont.isCarActive = true;
                    newCarCont.skate.volume = 0;
                    carObject.transform.rotation = carRoation.transform.rotation;
                    triggerBox.enabled = false;
            }

        }
     
    }
}
