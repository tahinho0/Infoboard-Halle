using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FräsAnimation : MonoBehaviour
{
    [SerializeField] private GameObject doorL;
    [SerializeField] private GameObject doorR;

    private float doorLStartPosX;
    private float doorRStartPosX;
    private const float DoorMoveValue = -0.65f;

    [Header("Milling Machine movement")]
    [SerializeField] private GameObject millingMachine;

    private Vector3 millingMachineStartPos;

    // Start is called before the first frame update
    private void Start()
    {
        doorLStartPosX = doorL.transform.localPosition.x;
        doorRStartPosX = doorR.transform.localPosition.x;

        millingMachineStartPos = millingMachine.transform.localPosition;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void Milling_Maschine_WorkAnimation()
    {
        LeanTween.moveLocalX(millingMachine, millingMachineStartPos.x + -0.8f, 1f)
               .setEaseInOutCubic()
               .setDelay(1f);
        LeanTween.moveLocalX(millingMachine, millingMachineStartPos.x + 0.6f, 1f)
            .setDelay(1f + 1f)
            .setEaseInOutCubic()
            .setLoopPingPong();
    }

    public void Milling_Maschine_IdleAnimation()
    {
        LeanTween.cancel(millingMachine);

        LeanTween.moveLocal(millingMachine, millingMachineStartPos, 1f)
            .setEaseInOutCubic();
    }

    public void Doors_Open()
    {
        LeanTween.moveLocalX(doorL, doorLStartPosX, 1f)
                 .setEaseInOutCubic()
                 .setDelay(1f);
        LeanTween.moveLocalX(doorR, doorRStartPosX, 1f)
            .setEaseInOutCubic().
            setDelay(1f);
    }

    public void Doors_Close()
    {
        LeanTween.cancel(doorL);
        LeanTween.cancel(doorR);

        LeanTween.moveLocalX(doorL, doorLStartPosX + DoorMoveValue, 1f)
            .setEaseInOutCubic();
        LeanTween.moveLocalX(doorR, doorRStartPosX - DoorMoveValue, 1f)
            .setEaseInOutCubic();
    }
}