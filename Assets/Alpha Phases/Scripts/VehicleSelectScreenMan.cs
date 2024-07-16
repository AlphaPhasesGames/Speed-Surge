using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace SSGFE.Alpha.Phases.Games
{
    public class VehicleSelectScreenMan : MonoBehaviour
    {
        public SwitchVehicles switchVeh;
        public Button carButton;
        public Button skateBoardButton;
        public Button toiletButton;
        public Button toyCarButton;

        // public GameObject car;
        //  public GameObject skateBoard;
        //  public GameObject toilet;
        //  public GameObject toyCar;

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
            switchVeh.arrayPos = 0;
            switchVeh.hasScrolled = false;
            panalOpen = false;

        }

        public void ChooseSkate()
        {
            //     car.gameObject.SetActive(false);
            //     skateBoard.gameObject.SetActive(true);
            //     toilet.gameObject.SetActive(false);
            //      toilet.gameObject.SetActive(false);
            switchVeh.arrayPos = 2;
            switchVeh.hasScrolled = false;
            panalOpen = false;
        }

        public void ChooseToilet()
        {
            //    toilet.gameObject.SetActive(true);
            switchVeh.arrayPos = 1;
            switchVeh.hasScrolled = false;
            panalOpen = false;
        }

        public void ChooseToyCar()
        {
            //    toilet.gameObject.SetActive(true);
            switchVeh.arrayPos = 4;
            switchVeh.hasScrolled = false;
            panalOpen = false;
        }
    }
}
