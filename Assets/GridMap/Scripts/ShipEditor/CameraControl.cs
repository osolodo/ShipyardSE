using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public static readonly float MIN_ZOOM = 5f;
    public static readonly float MAX_ZOOM = 5000f;
    public static readonly float Deadzone = 0.01f;
    public static readonly float cameraMoveSpeed = 3f;
    public static readonly float cameraZoomSpeed = 1f;
    public static readonly float cameraRotateSpeed = 0.1f;
    public static CameraControl Instance { get; private set; }

    private Camera myCamera;
    private Vector3 cameraTargetPosition;
    private float cameraZoom = MIN_ZOOM;

    public void Setup(Vector3 cameraTargetPosition, float cameraZoom, bool teleportToFollowPosition) {
        this.cameraTargetPosition = cameraTargetPosition;
        this.cameraZoom = Mathf.Clamp(cameraZoom,MIN_ZOOM,MAX_ZOOM);

        if (teleportToFollowPosition) {
            Debug.Log(cameraTargetPosition);
            transform.position = cameraTargetPosition;
            InstantZoom();
        }
    }

    private void Awake() {
        Instance = this;
        myCamera = transform.GetComponentInChildren<Camera>();
        InstantZoom();
    }

    public void SetCameraZoom(float cameraZoom) {
        this.cameraZoom = Mathf.Clamp(cameraZoom,MIN_ZOOM,MAX_ZOOM);
    }


    private void Update() {
        HandleInput();
        HandleMovement();
        HandleZoom();
    }

    private void HandleInput(){
        float Horizontal_Rotation = Input.GetAxis(InputAxis.Horizontal.ToString());
        if(Horizontal_Rotation != 0) {
            transform.Rotate(myCamera.transform.up,cameraRotateSpeed*Horizontal_Rotation*-1, Space.World);
        }
        float Vertical_Rotation = Input.GetAxis(InputAxis.Vertical.ToString());
        if(Vertical_Rotation != 0) {
            transform.Rotate(myCamera.transform.right,cameraRotateSpeed*Vertical_Rotation, Space.World);
        }
        float Roll_Rotation = Input.GetAxis(InputAxis.Roll.ToString());
        if(Roll_Rotation != 0) {
            transform.Rotate(myCamera.transform.forward,cameraRotateSpeed*Roll_Rotation, Space.World);
        }
        float ZoomDelta = Input.GetAxis(InputAxis.Zoom.ToString());
        if(ZoomDelta != 0) {
            SetCameraZoom(cameraZoom + ZoomDelta);
            InstantZoom();
        }
    }

    private void HandleMovement() {

        float distance = Vector3.Distance(cameraTargetPosition, transform.position);

        if (distance > Deadzone) {
            Vector3 cameraMoveDir = (cameraTargetPosition - transform.position).normalized;
            Vector3 newCameraPosition = transform.position + cameraMoveDir * distance * cameraMoveSpeed * Time.deltaTime;

            float distanceAfterMoving = Vector3.Distance(newCameraPosition, cameraTargetPosition);

            if (distanceAfterMoving > distance) {
                // Overshot the target
                newCameraPosition = cameraTargetPosition;
            }

            transform.position = newCameraPosition;
        }
    }

    private void HandleZoom() {
        float cameraZoomCurrent = Vector3.Distance(myCamera.transform.position, transform.position);
        float cameraZoomDifference = cameraZoomCurrent - cameraZoom; // Positive means zooming in (forward)
        if(Mathf.Abs(cameraZoomDifference) <= Deadzone){
            return;
        }
        
        float newDistance =  cameraZoomCurrent + cameraZoomDifference * cameraZoomSpeed * Time.deltaTime;
        myCamera.transform.localPosition = Vector3.forward * -newDistance;
        Debug.Log($"{cameraZoomCurrent}, {cameraZoomDifference}, {newDistance}");

        if (cameraZoomDifference > 0) {
            if (newDistance < cameraZoom) {
                InstantZoom();
            }
        } else {
            if (newDistance > cameraZoom) {
                InstantZoom();
            }
        }
    }

    private void InstantZoom(){
        myCamera.transform.localPosition = Vector3.zero;
        myCamera.transform.localPosition = Vector3.forward * -cameraZoom;
    }
}
