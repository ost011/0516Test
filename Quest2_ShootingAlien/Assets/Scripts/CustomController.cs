using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit.UI;

public enum HandState { NONE = 0, RIGHT, LEFT };

public class CustomController : MonoBehaviour
{
    public InputDeviceCharacteristics characteristics;
    [SerializeField]
    private List<GameObject> controllerModels;
    private GameObject controllerInstance;
    private InputDevice availableDevice;

    public bool renderController ; // Hand와 Controller 사이를 변경할 변수
    public GameObject handModel;   // 핸드 모델
    private GameObject handInstance; // 핸드 인스턴스

    private Animator handModelAnimator; // 핸드 모델 애니메이션 변수

    public GameObject HandGun;

    bool triggerButton;

   
    public HandState currentHand;


    // Start is called before the first frame update
    void Start()
    {

        TryInitialize();

       
    }

    void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(characteristics, devices);
        foreach (var device in devices)
        {
            Debug.Log($"Available Device Name: {device.name}, Characteristic: { device.characteristics}");
        }
        if (devices.Count > 0)
        {
            availableDevice = devices[0];
            GameObject currentControllerModel; 
            if(availableDevice.name.Contains("Left"))
            {
                currentControllerModel = controllerModels[1];
                currentHand = HandState.LEFT;
            }
            else if(availableDevice.name.Contains("Left"))
            {
                currentControllerModel = controllerModels[1];
                currentHand = HandState.LEFT;
            }
            else
            {
                currentControllerModel = null;
                currentHand = HandState.NONE;
            }
            if (currentControllerModel)
            {
                controllerInstance = Instantiate(currentControllerModel, transform);
            }
            else
            {
                Debug.LogError("Didn't get suitable controller model");
                controllerInstance = Instantiate(controllerModels[0], transform);
            }
            handInstance = Instantiate(handModel, transform); // 핸드 인스턴스추가
            handModelAnimator = handInstance.GetComponent<Animator>(); // 핸드 모델 애니메이션 설정
        }
    }


    // Update is called once per frame

    void Update()
    {
        if (!availableDevice.isValid)
        {
            TryInitialize();
            return;
        }
        if (renderController)
        {
            handInstance.SetActive(false);
            controllerInstance.SetActive(true);
        }
        else
        {
            handInstance.SetActive(true);
            controllerInstance.SetActive(false);
            UpdateHandAnimation(); // 핸드 애니메이션은 여기서만 수행
        }

        if (HandGun != null)
        {
            bool menuButtonValue;
            if (availableDevice.TryGetFeatureValue(CommonUsages.triggerButton, out menuButtonValue) && menuButtonValue)
            {
                if(triggerButton == false && currentHand == HandGun.GetComponent<SimpleShoot>().currentGrab)
                {
                    HandGun.GetComponent<SimpleShoot>().Shoot();
                    triggerButton = true;
                }                
            }
            else
            {
                triggerButton = false;
            }
        }
        
        if (FindObjectOfType<GameManager>().isGameOver)
        {
            bool menuButtonValue;
            if (availableDevice.TryGetFeatureValue(CommonUsages.menuButton, out menuButtonValue) && menuButtonValue)
            {
                FindObjectOfType<GameManager>().RestartGame();
            }
        }
    }

    void UpdateHandAnimation()
    {
        if (availableDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handModelAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handModelAnimator.SetFloat("Trigger", 0);
        }

        if (availableDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handModelAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handModelAnimator.SetFloat("Grip", 0);
        }
    }
}

