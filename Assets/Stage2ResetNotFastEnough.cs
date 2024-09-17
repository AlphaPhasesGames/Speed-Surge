using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SSGFE.Alpha.Phases.Games
{
    public class Stage2ResetNotFastEnough : MonoBehaviour
    {
        public NewCarControllerStage2 newCarCont;
        public Stage2TextMan stage2TextManager;

        public GameObject sphereParent;
        public GameObject resetPosition;


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if(newCarCont.maxSpeed <= 15)
                {
                    //stage2TextManager.ResetCarArrayMove();
                    stage2TextManager.arrayPos = 17;
                    sphereParent.transform.position = resetPosition.transform.position;
                }
            }
        }
    }
}
