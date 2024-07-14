using System.Collections;
using System.Collections.Generic;
using System.IO;
using LoLSDK;
using SimpleJSON;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

namespace SSGFE.Alpha.Phases.Games
{

    [System.Serializable] // serialize this save data
    public class SSQFESaveData
    {
        [Header("StageProgress")] // header for the save location for the robot
        public int current_stage; // int to hold the level number

        [Header("StageTasks")] // header for the save location for the robot       
        public int task_number;
        public int task_number_crew_quarter;
        public int task_number_comms_room;
        public int task_number_dock;
        public int task_number_ship;

    }

    public class SSQREMain : MonoBehaviour
    {
        #region global code
        [SerializeField, Header("Initial State Data")]
        SSQFESaveData sSQFESaveData; // get access to save section of this script

        public int taskNumber;
        public int taskNumberCrewQuarters;
        public int taskNumberCommsRoom;
        public int taskNumberDock;
        public int taskNumberShip;

        public int currentStage;

        public bool loadSavesOnce;


        #region "stage1stufftobecollapsed"
        [SerializeField, Header("Stage 1 Code")]
        #endregion
        JSONNode _langNode; // declare lanuage code for this game so we know if its spanish or english
        public string _langCode = "en"; // declare string for english text
        string _langCodeSpanish = "es"; // declare string for spanish text

       // public GameObject logo;

        [SerializeField] Button continueButton, newGameButton; // declare two buttons for the start new game and continue game options

        public TextMeshProUGUI newGameText; // TMP for the new game button
        public TextMeshProUGUI continueText; // TMP for the continue game button
      //  public Animator logoAnim;


        private void Awake() // on awake of script
        {
            Application.runInBackground = false; // dont let the game run in the background
            DontDestroyOnLoad(this.gameObject);
            //  stage1Started = true;
            //    currentStage = 1;
        }

        void Start()
        {
            newGameButton.onClick.AddListener(RemoveMainMenuUINewGame); // new game button after pressing, hides the button - see script at the bottom of the script
            continueButton.onClick.AddListener(RemoveMainMenuUIContinue); ; // continune saved game button after pressing, hides the button - see script at the bottom of the script

#if UNITY_EDITOR
            ILOLSDK sdk = new LoLSDK.MockWebGL();
#elif UNITY_WEBGL
	    ILOLSDK sdk = new LoLSDK.WebGL();
#endif
            Helper.StateButtonInitialize<SSQFESaveData>(newGameButton, continueButton, OnLoad); // initialise LOLSDK helper function and attached both new game and continue buttons to it
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Save()
        {
            LOLSDK.Instance.SaveState(sSQFESaveData); // save data to cargoSaveData
            Debug.Log("Game Saved");
        }

        void OnLoad(SSQFESaveData ssQFESaveData)
        {
            JSONNode langs = SharedState.LanguageDefs;
            // Overrides serialized state data or continues with editor serialized values.
            if (sSQFESaveData != null)
                sSQFESaveData = ssQFESaveData;
            //  currentStage = tusomSaveData.current_stage;

            if (currentStage == 1)
            {

                if (!loadSavesOnce)
                {
                    SceneManager.LoadScene("Stage 1 Motion Intro");
                   // taskNumber = sSQFESaveData.task_number;
                    loadSavesOnce = true;
                    Debug.Log("Stage 1 update runs - load save data from save");
                }

            }
            /*
            if (sSQFESaveData.current_stage == 2)
            {
                if (!loadSavesOnce)
                {
                    SceneManager.LoadScene("CrewQuaters");
                    taskNumberCrewQuarters = sSQFESaveData.task_number_crew_quarter;
                    Debug.Log("Stage 2 update runs - load save data from save");
                    loadSavesOnce = true;
                }
            }


            if (sSQFESaveData.current_stage == 3)
            {
                SceneManager.LoadScene("CommsRoom");
                if (!loadSavesOnce)
                {
                    taskNumberCommsRoom = sSQFESaveData.task_number_comms_room;

                    loadSavesOnce = true;
                    Debug.Log("Stage 3 update runs - load save data from save");

                }
            }

            if (sSQFESaveData.current_stage == 4)
            {
                SceneManager.LoadScene("Stage4DockingBay");
                if (!loadSavesOnce)
                {
                    taskNumberDock = sSQFESaveData.task_number_dock;
                    // currentStage = tusomSaveData.current_stage;
                    loadSavesOnce = true;
                    Debug.Log("Stage 4 update runs - load save data from save");
                }
            }
            */
            Debug.Log("Load Function Called");
        }

        void RemoveMainMenuUINewGame()
        {

            currentStage = 1;
            SaveStage();

        }
        void RemoveMainMenuUIContinue()
        {

            currentStage = sSQFESaveData.current_stage;
            /*
                        if (currentStage == 1)
                        {
                            // employeeBadgeCollected = digiWavesSaveData.employee_badge_collected;
                            //  keyboadCollected = digiWavesSaveData.keyboad_collected;
                            taskNumber = digiWavesSaveData.task_number;
                            //   itemsCollected = digiWavesSaveData.items_collected;
                        }

                        if (currentStage == 2)
                        {
                            SceneManager.LoadScene("CrewQuaters");
                            crewQuarters2StartedAlready = digiWavesSaveData.crew_quaters_2_started_already;
                            //   phoneCollected = digiWavesSaveData.stage_2_phone_collected;
                            //   tabletCollected = digiWavesSaveData.stage_2_watch_collected;
                            //   watchCollected = digiWavesSaveData.stage_2_watch_collected;
                            stage2ItemsCollected = digiWavesSaveData.stage_2_items_collected;
                            // stage2LightsOn = digiWavesSaveData.stage_2_lights_on;
                            taskNumberCrewQuarters = digiWavesSaveData.task_number_crew_quarter;
                            stage2CodeFound = digiWavesSaveData.stage_2_code_found;
                            Debug.Log("Loaded Stage 2");
                        }

                        if (currentStage == 3)
                        {
                            commsRoom3StartedAkready = digiWavesSaveData.comms_room_3_started_already;
                            stage3ConsoleRead = digiWavesSaveData.stage_3_console_read;
                            //    stage3FolderCollected = digiWavesSaveData.stage_3_folders_collected;
                            stage3DoorKeyCollected = digiWavesSaveData.stage_3_door_key_collected;
                            taskNumberCommsRoom = digiWavesSaveData.task_number_comms_room;
                        }

                        if (currentStage == 4)
                        {
                            dockingBay4StartedAlready = digiWavesSaveData.docking_bay_4_started_already;
                            taskNumberDock = digiWavesSaveData.task_number_dock;
                        }

                        if (currentStage == 5)
                        {
                            aboardTheShip5StartedAlready = digiWavesSaveData.abour_ship_5_started_already;
                            taskNumberShip = digiWavesSaveData.task_number_ship;

                        }
            */
            Debug.Log("Loaded Save");
        }

        public void SaveStage()
        {

            sSQFESaveData.current_stage = currentStage;
            Save();
            Debug.Log("Forces Saved Fired");
        }
        #endregion
    }

}
