using UnityEngine;
using SimpleJSON;
using TMPro;

namespace SSGFE.Alpha.Phases.Games
{
    public class Stage3LangMan : MonoBehaviour
    {

        public TextMeshProUGUI vehicleTitleText;
        public TextMeshProUGUI carText;
        public TextMeshProUGUI toiletText;
        public TextMeshProUGUI skateboardText;
        public TextMeshProUGUI toyCarText;
        public TextMeshProUGUI bedText;
        public TextMeshProUGUI bathText;

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

        public TextMeshProUGUI wallTitle;
        public TextMeshProUGUI wall1Name;
        public TextMeshProUGUI wall2Name;
        public TextMeshProUGUI wall3Name;

        public TextMeshProUGUI taskTitle;
        private void Awake()
        {
            JSONNode defs = SharedState.LanguageDefs;


            vehicleTitleText.text = defs["vehicleTitle"];
            carText.text = defs["carName"];
            toiletText.text = defs["toiletName"];
            skateboardText.text = defs["skateBoardName"];
            toyCarText.text = defs["toyCarName"];
            bedText.text = defs["bedName"];
            bathText.text = defs["bathName"];

            introText1.text = defs["stage3MissionText1"];
            introText2.text = defs["stage3MissionText2ChooseCar"];
            introText3.text = defs["stage3MissionText3"];
            introText4.text = defs["stage3MissionText4"];
            introText5.text = defs["stage3MissionText5"];
            introText6.text = defs["stage3MissionText6"];
            introText7.text = defs["stage3MissionText7"];
            introText8.text = defs["stage3MissionText8"];
            introText9.text = defs["stage3MissionText9"];
            introText10.text = defs["stage3MissionText10"];
            introText11.text = defs["stage3MissionText11"];
            introText12.text = defs["stage3MissionText12"];
            introText13.text = defs["stage3MissionText13"];
            introText14.text = defs["stage3MissionText14"];
            introText15.text = defs["stage3MissionText15"];
            introText16.text = defs["stage3MissionText16"];
            introText17.text = defs["stage3MissionText17"];


            wallTitle.text = defs["WallTitle"];
            wall1Name.text = defs["Wall1"];
            wall2Name.text = defs["Wall2"];
            wall3Name.text = defs["Wall3"];

            taskTitle.text = defs["Stage3Task"];
        }
    }
}
