using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SSGFE.Alpha.Phases.Games
{
    public class FirstStopTrigger : MonoBehaviour
    {
        public NewCarController newCarCont;
        public Stage1TextManager stage1TextMan;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                //  newCarCont.StartStopCar();
                newCarCont.isCarActive = true;
                stage1TextMan.hasScrolled = false;
                stage1TextMan.textPanal.gameObject.SetActive(true);
                stage1TextMan.arrayPos = 19;
            }

        }
    }
}
