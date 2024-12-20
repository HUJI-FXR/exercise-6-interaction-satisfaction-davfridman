using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ThrowableObject : MonoBehaviour
{

    [Header("Activation Settings")]
    [SerializeField] private GameObject xrRig;
    [SerializeField] private GameObject moveLocomotionObject;
    [SerializeField] private GameObject firstPlatfromObject;
    [SerializeField] private GameObject secondPlatfromObject;



    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void update()
    {
        float distance = Vector3.Distance(xrRig.transform.position, gameObject.transform.position);
        if(distance>4)
        {
            UnlockNextStep();
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Platform"))
        {
            UnlockNextStep();
        }

    }

    private void UnlockNextStep()
    {
        moveLocomotionObject.SetActive(true);
        secondPlatfromObject.SetActive(true);

        gameObject.SetActive(false);
        firstPlatfromObject.SetActive(false);
    }

}

