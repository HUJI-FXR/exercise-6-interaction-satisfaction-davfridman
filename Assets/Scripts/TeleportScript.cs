using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportScript : MonoBehaviour
{
    [Header("Activation Settings")]
    [SerializeField] private GameObject activationObject;
    [SerializeField] private float stayDuration = 2f;
    [SerializeField] private float activationDelay = 0f;

    [Header("Teleportation Settings")]
    [SerializeField] private Transform teleportDestination;

    private TeleportationProvider teleportationProvider;
    private float stayTimer = 0f;

    private void Start()
    {
        teleportationProvider = FindObjectOfType<TeleportationProvider>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            stayTimer += Time.deltaTime;
            if (stayTimer >= stayDuration)
            {
                if (activationDelay > 0)
                {
                    Invoke(nameof(ActivateAndTeleport), activationDelay);
                }
                else
                {
                    ActivateAndTeleport();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            stayTimer = 0f;
        }
    }

    private void ActivateAndTeleport()
    {
        activationObject.SetActive(true);
        TeleportRequest request = new TeleportRequest
        {
            destinationPosition = teleportDestination.position
        };
        teleportationProvider.QueueTeleportRequest(request);
    }
}