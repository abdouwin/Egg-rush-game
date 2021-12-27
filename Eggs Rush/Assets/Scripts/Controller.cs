using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    [SerializeField] GameObject Egg;
    [SerializeField] Camera camera;
    [SerializeField] float Zoffset_camera;
    public static bool AllowtoPlay = true;
    float x = 0;
    Vector3 moving;
    public float _speed_Movement_X = 2f;
    public float _speed_Movement_forward = 2f;


    // Ring behaviour
    [Header("Ring Attributs")]
    [SerializeField] float speed_forward;
    [SerializeField] Vector3 minScaleDown;
    [SerializeField] Vector3 defaultScale;
    [SerializeField] float minScale;
    [SerializeField] float timing = 10;
    Touch touch;


    float worldWidth = 1.0f;  //serialized, example value
    float ratioScreenToWorld = 2.0f; //serialized, example value

    float screenWidth = (float)Screen.width;

    public static float offset = 0.52f;


    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Input_Controller();
    }

    private void FixedUpdate()
    {
        Camera_Follow();
        MoveForward();
    }

    //Control [Input]
    private void Input_Controller()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                x = touch.deltaPosition.x * Time.deltaTime;
                moving = new Vector3(x * _speed_Movement_X, 0, 0);
                transform.Translate(moving);
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.7f, 1.7f), transform.position.y, transform.position.z);
            }
        }

    }

    //Movement in forward direction
    private void MoveForward()
    {
        if (AllowtoPlay)
        {
            transform.position += Vector3.forward * speed_forward * Time.deltaTime;
        }
    }

    //Camera follow
    private void Camera_Follow()
    {
        float y_lerp = Mathf.Lerp(camera.transform.position.y, transform.position.y + 4.65f, 10 * Time.deltaTime);
        camera.transform.position = new Vector3(camera.transform.position.x, y_lerp, transform.position.z - Zoffset_camera);
    }



}
