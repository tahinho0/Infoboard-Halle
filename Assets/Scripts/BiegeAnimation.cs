using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiegeAnimation : MonoBehaviour
{
    [SerializeField] private GameObject bendingPlate;
    [SerializeField] private GameObject bendingTube;

    [SerializeField] private float bendingPlateRotationX;
    [SerializeField] private float bendingTubeRotationX;
    [SerializeField] private float bendingTubePositionY;
    private const float BendingTubeMoveValue = 1.3f;
    private const float BendingRotateValue = -35f;
    private bool isWorking = false;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    //private void Update()
    //{
    //    if (isWorking)
    //    {
    //        StopCoroutine("Bending_Maschine_WorkAnimnation");
    //        StartCoroutine("Bending_Maschine_WorkAnimnation");
    //    }

    //    if (!isWorking)
    //    {
    //        Bending_Maschine_IdleAnimnation();
    //    }
    //}

    //public void setIsWorking(bool b)
    //{
    //    isWorking = b;
    //}

    public void Bending_Maschine_WorkAnimnation()
    {
        LeanTween.moveLocalY(bendingTube, bendingTubePositionY + BendingTubeMoveValue, 3f)
                .setEaseInOutCubic();
        LeanTween.rotateX(bendingPlate, bendingPlateRotationX + BendingRotateValue, 3f)
            .setDelay(1f)
            .setEaseInOutElastic()
            .setLoopPingPong(1);
        LeanTween.rotateX(bendingTube, bendingTubeRotationX + BendingRotateValue, 3f)
            .setDelay(1f)
            .setEaseInOutElastic()
            .setLoopPingPong(1);
        LeanTween.moveLocalY(bendingTube, 1.3f, 3f)
            .setDelay(1f + 1f * 2)
            ;
        //yield return new WaitForSeconds(5);
    }

    public void Bending_Maschine_IdleAnimnation()
    {
        LeanTween.cancel(bendingPlate);
        LeanTween.cancel(bendingTube);

        LeanTween.moveLocalY(bendingTube, 1.7f, 2f);
        LeanTween.rotateX(bendingTube, bendingTubeRotationX, 2f);
        LeanTween.rotateX(bendingPlate, bendingPlateRotationX, 2f);
    }
}