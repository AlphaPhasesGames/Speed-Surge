using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoLSDK;

namespace SSGFE.Alpha.Phases.Games
{
    public class Stage2FinalBoxes : MonoBehaviour
    {
        public NewCarControllerStage2 newCarCont;
        public Stage2TextMan stage2TextManager;

        public Rigidbody[] boxesToKinematic;

        public GameObject respawnPosition;
        public GameObject carObject;

        public GameObject boxesSet1;
        public GameObject boxesSet2;

        public AudioSource carSounds;
        public AudioSource wheelSounds;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {

                if(newCarCont.maxSpeed >= 40)
                {
                    SetAllRigidbodiesKinematic(false);
                    stage2TextManager.arrayPos = 18;
                    LOLSDK.Instance.SubmitProgress(0, 50, 100);
                    //newCarCont.isCarActive = false;
                    Destroy(this.gameObject);
                    wheelSounds.Stop();
                    carSounds.Stop();
                }

                if (newCarCont.maxSpeed < 40 )
                {
                    // SetAllRigidbodiesKinematic(true);
                    //  stage2TextManager.restrictionBool2 = true;
                    carObject.transform.position = respawnPosition.transform.position;
                    stage2TextManager.arrayPos = 20;
                    stage2TextManager.ResetCarArrayMove();
                    boxesSet1.gameObject.SetActive(false);
                    boxesSet2.gameObject.SetActive(true);
                    //newCarCont.isCarActive = false;
                    //Destroy(this.gameObject);
                }

            }

        }


        void SetAllRigidbodiesKinematic(bool kinematic)
        {
            foreach (Rigidbody rb in boxesToKinematic)
            {
                if (rb != null)
                {
                    rb.isKinematic = kinematic;
                }
            }
        }
    }
}
