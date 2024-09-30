using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SSGFE.Alpha.Phases.Games
{
    public class Stage4ChangeView : MonoBehaviour
    {

        public NewCarControllerStage3 newCarCont;
        public Camera carCam;
        public Camera bowlingCam;
        public Rigidbody rb;
        public Stage4TextMan stage4TextMan;
        public AudioSource bowling;
        public AudioSource skate;
        public AudioSource car;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if(newCarCont.maxSpeed <= 30)
                {
                   
                    stage4TextMan.arrayPos = 12;
                   // newCarCont.isCarActive = false;
                    stage4TextMan.MoveCar();
                   // newCarCont.maxSpeed = 50;
                }

                if (newCarCont.maxSpeed > 30)
                {
                    skate.Stop();
                    car.Stop();
                    bowling.Play();

                    rb.isKinematic = false;
                    rb.AddForce(-transform.right * 22000f);
                    newCarCont.enabled = false;
                    carCam.gameObject.SetActive(false);
                    bowlingCam.gameObject.SetActive(true);
                   // Destroy(this.gameObject);
                }

               
            }
        }
    }
}
