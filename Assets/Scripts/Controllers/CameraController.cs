﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour, ICameraController
{
    //Cached references
    protected Camera mainCamera;
    protected Transform cameraTransform;


    //State variables
    protected float xMax = 8.5f;
    protected float yMax = 4.5f;
    protected float xBoundary;
    protected float yBoundary;
    protected float sensitivityModifier = 1f;
    protected float speedModifier = 1f;
    protected Vector3 mousePos;
    protected Vector3 cameraPosToBe;
    protected bool movementEnabled = false;

    public float SensitivityModifier { get => sensitivityModifier; set => sensitivityModifier = value; }
    public float SpeedModifier { get => speedModifier; set => speedModifier = value; }

    public void ToggleCameraControls(bool cameraControlOnOff) => movementEnabled = cameraControlOnOff;

    protected void Awake()
    {
        mainCamera = Camera.main;
        //gameManager = FindObjectOfType<GameManager>();
        cameraTransform = mainCamera.transform;
        //ConfigManager.instance.CameraController = this;
    }

    protected void Start()
    {
        //SensitivityModifier = ConfigManager.instance.SensitivityModifier;
        //SpeedModifier = ConfigManager.instance.SpeedModifier;
    }

    protected void Update()
    {
        CameraMovement();
    }

    protected void CameraMovement()
    {
        if (movementEnabled)
        {
            mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            //if (gameManager != null)
            //{
            //    cameraPosToBe.x = Mathf.Clamp(mousePos.x, -gameManager.GridSize, gameManager.GridSize);
            //    cameraPosToBe.y = Mathf.Clamp(mousePos.y, -gameManager.GridSize, gameManager.GridSize);
            //    cameraPosToBe.z = mainCamera.transform.position.z;
            //}

            if (mousePos.x > mainCamera.transform.position.x + xMax / sensitivityModifier ||
                mousePos.x < mainCamera.transform.position.x - xMax / sensitivityModifier ||
                mousePos.y > mainCamera.transform.position.y + yMax / sensitivityModifier ||
                mousePos.y < mainCamera.transform.position.y - yMax / sensitivityModifier)
            {
                mainCamera.transform.position = Vector3.Lerp(transform.position, cameraPosToBe, speedModifier * Time.deltaTime);
            }
        }

        else
        {
            mainCamera.transform.position = Vector3.Lerp(transform.position, cameraPosToBe, speedModifier * Time.deltaTime);
        }
    }

    public void RepositionCamera(Vector3 cameraPosition)
    {
        cameraPosToBe.x = cameraPosition.x;
        cameraPosToBe.y = cameraPosition.y;
        cameraPosToBe.z = mainCamera.transform.position.z;
    }

    public void SetCameraPosition(Vector3 cameraPosition)
    {
        cameraPosToBe.x = cameraPosition.x;
        cameraPosToBe.y = cameraPosition.y;
        cameraPosToBe.z = mainCamera.transform.position.z;

        mainCamera.transform.position = cameraPosToBe;
    }
}
