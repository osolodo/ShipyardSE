using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public static readonly float MIN_ZOOM = 5f;
    public static readonly float MAX_ZOOM = 5000f;
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
            myCamera.transform.position = cameraTargetPosition;
            myCamera.transform.Translate(myCamera.transform.forward * -cameraZoom);
        }
    }

    private void Awake() {
        Instance = this;
        myCamera = transform.GetComponentInChildren<Camera>();
        myCamera.transform.position = cameraTargetPosition;
        myCamera.transform.Translate(myCamera.transform.forward * -cameraZoom);
    }

    public void SetCameraZoom(float cameraZoom) {
        this.cameraZoom = Mathf.Clamp(cameraZoom,MIN_ZOOM,MAX_ZOOM);
    }


    private void Update() {
        RotationInput();
        HandleMovement();
        HandleZoom();
        HandleRotate();
    }

    private void RotationInput(){
        // These are rotating in the wrong context, try a multiaxis rotation and find out
        float Horizontal_Rotation = Input.GetAxis(InputAxis.Horizontal.ToString());
        if(Horizontal_Rotation != 0) {
            transform.Rotate(myCamera.transform.up,cameraRotateSpeed*Horizontal_Rotation);
        }
        float Vertical_Rotation = Input.GetAxis(InputAxis.Vertical.ToString());
        if(Vertical_Rotation != 0) {
            transform.Rotate(myCamera.transform.right,cameraRotateSpeed*Vertical_Rotation);
        }
    }

    private void HandleMovement() {
        if (cameraTargetPosition == null) return;

        Vector3 cameraMoveDir = (cameraTargetPosition - transform.position).normalized;
        float distance = Vector3.Distance(cameraTargetPosition, transform.position);

        if (distance > 0) {
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
        if(cameraZoomDifference==0){
            return;
        }
        Vector3 cameraMoveDir = myCamera.transform.forward;
        Vector3 newCameraPosition = cameraMoveDir * cameraZoomDifference * cameraZoomSpeed * Time.deltaTime;
        myCamera.transform.Translate(newCameraPosition);

        float newDistance = Vector3.Distance(myCamera.transform.position, transform.position);
        if (cameraZoomDifference > 0) {
            if (newDistance < cameraZoom) {
                myCamera.transform.position = cameraTargetPosition;
                myCamera.transform.Translate(myCamera.transform.forward * -cameraZoom);
            }
        } else {
            if (newDistance > cameraZoom) {
                myCamera.transform.position = cameraTargetPosition;
                myCamera.transform.Translate(myCamera.transform.forward * -cameraZoom);
            }
        }
    }

    private void HandleRotate(){
        // TODO
    }
}
