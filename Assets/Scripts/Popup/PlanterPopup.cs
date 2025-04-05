// Example implementation of IEventReceiver
using TMPro;
using UnityEngine;

public class PlanterPopup : MonoBehaviour, IRayEventReceiver, PopupEvent
{
    [SerializeField]
    private GameObject child;
    [SerializeField]
    private GameObject focusPoint;

    [SerializeField]
    private PlanterController childController;

    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Vector3 initialScale;

    private Vector3 targetPosition;
    private Quaternion targetRotation;
    private bool isActive = false;
    private float moveSpeed = 2.0f;

    void Start()
    {
        if (child)
        {
            initialPosition = child.transform.position;
            initialRotation = child.transform.rotation;
            initialScale = child.transform.localScale;

            targetPosition = initialPosition;
            targetRotation = initialRotation;
        }
    }

    void Update()
    {
        child.transform.position = Vector3.Lerp(child.transform.position, targetPosition, moveSpeed * Time.deltaTime);
        child.transform.rotation = Quaternion.Lerp(child.transform.rotation, targetRotation, moveSpeed * Time.deltaTime);
    }

    public void Activate()
    {
        OpenPopup();
        isActive = true;
    }

    public void DeActivate()
    {
        ClosePopup();
        isActive = false;
    }

    public void OpenPopup() {
        targetPosition = focusPoint.transform.position;
        targetRotation = focusPoint.transform.rotation;
        GameManager.Instance.setCurrentRayAction(this);
        Invoke("ActivateChildController", 1.5f); // triggers function after 1 second. stops notes animation from triggering immediately.
    }

    public void ClosePopup() {
        targetPosition = initialPosition;
        targetRotation = initialRotation;
        DisableChildController();
    }

    private void ActivateChildController()
    {
        if (!isActive) return;
        if (!childController) return;
        childController.setIsActive(true);
    }
    private void DisableChildController()
    {
        if (!childController) return;
        childController.setIsActive(false);
    }

    public bool CanReceiveRays()
    {
        return !GameManager.Instance.isFocused() && !isActive;
    }

    public void OnRaycastEnter() {}

    public void OnRaycastExit() {}
}
