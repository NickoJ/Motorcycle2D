using Klyukay.CoreLogic;
using Klyukay.UnityLogic.Cars;
using Klyukay.UnityLogic.Ground;
using Klyukay.UnityLogic.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Klyukay.UnityLogic
{
    
    public sealed class GameController : MonoBehaviour
    {

        [Header("Settings")] 
        [SerializeField] private CarSettings carSettings = default;
        [SerializeField] private GroundSettings groundSettings = default;
        
        [Header("Controllers")]
        [SerializeField] private CarController carController = default;
        [SerializeField] private GroundController groundController = default;
        [SerializeField] private UIController uiController = default;

        private GameManager gameManager;
        
        private void Start()
        {
            gameManager = GameManager.Instance;

            gameManager.GameEnd += ReloadScene;
            
            carController.Init(gameManager.Car, carSettings);
            groundController.Init(groundSettings, carController);
            uiController.Init(gameManager.Car);

            StartGame();
        }

        private void OnDestroy()
        {
            gameManager.GameEnd -= ReloadScene;
        }

        private void StartGame()
        {
            if (!gameManager.StartGame()) return;
            
            groundController.ResetGround();
            carController.Enable();
        }

        private void ReloadScene()
        {
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.buildIndex, LoadSceneMode.Single);
        }
        
        private void Reset()
        {
            carController = FindObjectOfType<CarController>(true);
            groundController = FindObjectOfType<GroundController>(true);
            uiController = FindObjectOfType<UIController>(true);
        }
        
    }
    
}