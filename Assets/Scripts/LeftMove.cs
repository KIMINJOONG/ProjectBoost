using UnityEngine;
using UnityEngine.EventSystems;

public class LeftMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isPressed = false;
    public GameObject Rocket;
    Rigidbody rb;
    [SerializeField] ParticleSystem rightBooster;
    [SerializeField] float rotationThrust = 100f;

    void Start()
    {
        // "Player"라는 이름을 가진 GameObject를 찾습니다.
        Rocket = GameObject.Find("Rocket");
        if (Rocket == null)
        {
            Debug.LogError("Player GameObject not found!");
        }

        if (Rocket != null)
        {
            // Rocket에서 Rigidbody를 접근
            rb = Rocket.GetComponent<Rigidbody>();
            Transform rightBoosterTransform = Rocket.GetComponent<Transform>().Find("Right Thruster Particles");
            rightBooster = rightBoosterTransform.GetComponent<ParticleSystem>();

            if (rb == null)
            {
                Debug.LogError("Rigidbody not found on targetObject!");
            }

            if (rightBooster == null)
            {
                Debug.LogError("rightBooster null");
            }
        }
        else
        {
            Debug.LogError("targetObject is not assigned!");
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed)
        {
            RotateRight();
        }
        else
        {
            rightBooster.Stop();
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }

    void RotateRight()
    {
        AapplyRotation(rotationThrust);
        if (!rightBooster.isPlaying)
        {
            rightBooster.Play();
        }

    }

    void AapplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // 수동제어를 할 수 있도록 회전을 고정한다.
        Rocket.transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // 물리 시스템이 적용되도록 회전 고정을 해제한다.
    }




}
