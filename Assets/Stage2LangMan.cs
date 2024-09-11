using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LoLSDK;
using SimpleJSON;
using TMPro;
namespace SSGFE.Alpha.Phases.Games
{
    public class Stage2LangMan : MonoBehaviour
    {

        public TextMeshProUGUI introText1;
        public TextMeshProUGUI introText2;
        public TextMeshProUGUI introText3;
        public TextMeshProUGUI introText4;
        public TextMeshProUGUI introText5;
        public TextMeshProUGUI introText6;
        public TextMeshProUGUI introText7;
        public TextMeshProUGUI introText8;
        public TextMeshProUGUI introText9;
        public TextMeshProUGUI introText10;
        public TextMeshProUGUI introText11;
        public TextMeshProUGUI introText12;
        public TextMeshProUGUI introText13;
        public TextMeshProUGUI introText14;
        public TextMeshProUGUI introText15;
        public TextMeshProUGUI introText16;
        public TextMeshProUGUI introText17;
        public TextMeshProUGUI introText18;
        public TextMeshProUGUI introText19;
        public TextMeshProUGUI introText20;
        public TextMeshProUGUI introText21;
        public TextMeshProUGUI introText22;
        // public TextMeshProUGUI stage2AssesEnergy;
        // public TextMeshProUGUI stage2AssesResist;

        public TextMeshProUGUI vehicleTitleText;
        public TextMeshProUGUI carText;
        public TextMeshProUGUI toiletText;
        public TextMeshProUGUI skateboardText;
        public TextMeshProUGUI toyCarText;
        public TextMeshProUGUI bedText;
        public TextMeshProUGUI bathText;
        public TextMeshProUGUI taskStage2;

        private void Awake()
        {
            JSONNode defs = SharedState.LanguageDefs;

           // stage2AssesEnergy.text = defs["energyAssTitle"];
            //stage2AssesResist.text = defs["resistanceAssTitle"];

            vehicleTitleText.text = defs["vehicleTitle"];
            carText.text = defs["carName"];
            toiletText.text = defs["toiletName"];
            skateboardText.text = defs["skateBoardName"];
            toyCarText.text = defs["toyCarName"];
            bedText.text = defs["bedName"];
            bathText.text = defs["bathName"];

            introText1.text = defs["stage2MissionText1"];
            introText2.text = defs["stage2MissionText2ChooseCar"];
            introText3.text = defs["stage2MissionText3"];
            introText4.text = defs["stage2MissionText4"];
            introText5.text = defs["stage2MissionText5"];
            introText6.text = defs["stage2MissionText6"];
            introText7.text = defs["stage2MissionText7"];
            introText8.text = defs["stage2MissionText8"];
            introText9.text = defs["stage2MissionText9"];
            introText10.text = defs["stage2MissionText10"];
            introText11.text = defs["stage2MissionText11"];
            introText12.text = defs["stage2MissionText12"];
            introText13.text = defs["stage2MissionText13"];
            introText14.text = defs["stage2MissionText14"];
            introText15.text = defs["stage2MissionText15"];
            introText16.text = defs["stage2MissionText16"];
            introText17.text = defs["stage2MissionText17"];
            introText18.text = defs["stage2MissionText18"];
            introText19.text = defs["stage2MissionText19"];
            introText20.text = defs["stage2MissionText20"];
            introText21.text = defs["stage2MissionText21"];
            introText22.text = defs["stage2MissionText22"];

            taskStage2.text = defs["Stage2Task"];
        }
    }
}
