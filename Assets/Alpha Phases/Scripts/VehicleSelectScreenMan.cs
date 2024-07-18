using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace SSGFE.Alpha.Phases.Games
{
    public class VehicleSelectScreenMan : MonoBehaviour
    {
        //public SwitchVehicles switchVeh;
        public NewCarController newCarCont;
        public Stage1TextManager stage1TextMan;
        public Button carButton;
        public Button skateBoardButton;
        public Button toiletButton;
        public Button toyCarButton;

        public GameObject car;
        public GameObject skateBoard;
        public GameObject toilet;
        public GameObject toyCar;

        public GameObject selectionPanal;
        public bool panalOpen;
        // Start is called before the first frame update
        void Start()
        {
            carButton.onClick.AddListener(ChooseCar);
            skateBoardButton.onClick.AddListener(ChooseSkate);
            toiletButton.onClick.AddListener(ChooseToilet);
            toyCarButton.onClick.AddListener(ChooseToyCar);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                panalOpen = !panalOpen;
            }

            if (panalOpen)
            {
                selectionPanal.gameObject.SetActive(true);
            }

            else
            {
                selectionPanal.gameObject.SetActive(false);
            }
        }


        public void ChooseCar()
        {
            //    car.gameObject.SetActive(true);
            //    skateBoard.gameObject.SetActive(false);
            //    toilet.gameObject.SetActive(false);
            //     toilet.gameObject.SetActive(false);
            // NewCarController.
            // newCarCont.isCarActive = true;
            stage1TextMan.hasScrolled = false;
            stage1TextMan.arrayPos = 5;
            stage1TextMan.forwardParent.gameObject.SetActive(true);
            car.gameObject.SetActive(true);
            //switchVeh.hasScrolled = false;
            panalOpen = false;
            Debug.Log("This runs");

        }

        public void ChooseSkate()
        {
            //     car.gameObject.SetActive(false);
            //     skateBoard.gameObject.SetActive(true);
            //     toilet.gameObject.SetActive(false);
            //      toilet.gameObject.SetActive(false);
            stage1TextMan.hasScrolled = false;
            stage1TextMan.forwardParent.gameObject.SetActive(true);
            stage1TextMan.arrayPos = 5;
            skateBoard.gameObject.SetActive(true);
            // switchVeh.hasScrolled = false;
            panalOpen = false;
        }

        public void ChooseToilet()
        {
            //    toilet.gameObject.SetActive(true);
            stage1TextMan.hasScrolled = false;
            stage1TextMan.forwardParent.gameObject.SetActive(true);
            stage1TextMan.arrayPos = 5;
            toilet.gameObject.SetActive(true);
            // switchVeh.hasScrolled = false;
            panalOpen = false;
        }

        public void ChooseToyCar()
        {
            //    toilet.gameObject.SetActive(true);
            stage1TextMan.hasScrolled = false;
            stage1TextMan.forwardParent.gameObject.SetActive(true);
            stage1TextMan.arrayPos = 5;
            toyCar.gameObject.SetActive(true);
            //switchVeh.hasScrolled = false;
            panalOpen = false;
        }
    }
}
