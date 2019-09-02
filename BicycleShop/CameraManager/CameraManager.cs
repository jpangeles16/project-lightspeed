using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Attatch me to the main camera. I manage the camera, and the main menu buttons.
 * @author John Angeles.
 */
public class CameraManager : MonoBehaviour
{
    //[SerializeField]
    //private Camera _camera;
    [SerializeField]
    [Tooltip("Put the bicycle here for the camera to focus on.")]
    private GameObject _bicycle;

    /* Clicking this changes the camera view to where the bicycle is located.
     */
    public void ClickInspectBike()
    {
        Debug.Log("click");
        SetCameraToBikeView();
        transform.position += new Vector3(0, 0, -10);
    }

    /* Sets the camera to the original view.
     */
    private void SetCameraToOriginalView()
    {
        transform.position = originalCameraPosition;
        transform.localScale = originalCameraScale;
    }

    /* Sets the camera to wherever the bike is located.
     */
    private void SetCameraToBikeView()
    {
        transform.localScale = _bicycle.transform.localScale;
        transform.position = _bicycle.transform.position;
    }

    // ===== Set of functions to set camera to certain bike parts ===== //

    public void ClickOnBrakes()
    {
        GameObject brakes = _bicycle.transform.Find("Brakes").gameObject;
        transform.localScale = brakes.transform.localScale;
        transform.position = brakes.transform.position;
        transform.position += new Vector3(0, 0, -10);
        transform.gameObject.GetComponent<Camera>().orthographicSize = BIKE_PART_SIZE;

    }

    public void ClickOnEngine()
    {
        GameObject engine = _bicycle.transform.Find("Engine").gameObject;
        transform.localScale = engine.transform.localScale;
        transform.position = engine.transform.position;
        transform.position += new Vector3(0, 0, -10);
        transform.gameObject.GetComponent<Camera>().orthographicSize = BIKE_PART_SIZE;

    }

    public void ClickOnChain()
    {
        GameObject chain = _bicycle.transform.Find("Chain").gameObject;
        transform.localScale = chain.transform.localScale;
        transform.position = chain.transform.position;
        transform.position += new Vector3(0, 0, -10);
        transform.gameObject.GetComponent<Camera>().orthographicSize = BIKE_PART_SIZE;
    }

    public void ClickOnLeftMirror()
    {
        GameObject leftMirror = _bicycle.transform.Find("LeftMirror").gameObject;
        transform.localScale = leftMirror.transform.localScale;
        transform.position = leftMirror.transform.position;
        transform.position += new Vector3(0, 0, -10);
        transform.gameObject.GetComponent<Camera>().orthographicSize = BIKE_PART_SIZE;
    }

    public void ClickOnRightMirror()
    {
        GameObject rightMirror = _bicycle.transform.Find("RightMirror").gameObject;
        transform.localScale = rightMirror.transform.localScale;
        transform.position = rightMirror.transform.position;
        transform.position += new Vector3(0, 0, -10);
        transform.gameObject.GetComponent<Camera>().orthographicSize = BIKE_PART_SIZE;
    }

    public void ClickOnHandleBars()
    {
        GameObject handleBars = _bicycle.transform.Find("HandleBars").gameObject;
        transform.localScale = handleBars.transform.localScale;
        transform.position = handleBars.transform.position;
        transform.position += new Vector3(0, 0, -10);
        transform.gameObject.GetComponent<Camera>().orthographicSize = BIKE_PART_SIZE;
    }

    public void ClickOnOil()
    {
        GameObject oil = _bicycle.transform.Find("Oil").gameObject;
        transform.localScale = oil.transform.localScale;
        transform.position = oil.transform.position;
        transform.position += new Vector3(0, 0, -10);
        transform.gameObject.GetComponent<Camera>().orthographicSize = MINI_BIKE_PART_SIZE;
    }

    public void ClickOnSuspension()
    {
        GameObject suspension = _bicycle.transform.Find("Suspension").gameObject;
        transform.localScale = suspension.transform.localScale;
        transform.position = suspension.transform.position;
        transform.position += new Vector3(0, 0, -10);
        transform.gameObject.GetComponent<Camera>().orthographicSize = BIKE_PART_SIZE;
    }

    public void ClickOnBackWheel()
    {
        GameObject backWheel = _bicycle.transform.Find("BackWheel").gameObject;
        transform.localScale = backWheel.transform.localScale;
        transform.position = backWheel.transform.position;
        transform.position += new Vector3(0, 0, -10);
        transform.gameObject.GetComponent<Camera>().orthographicSize = BIKE_PART_SIZE;
    }

    public void ClickOnFrontWheel()
    {
        GameObject frontWheel = _bicycle.transform.Find("FrontWheel").gameObject;
        transform.localScale = frontWheel.transform.localScale;
        transform.position = frontWheel.transform.position;
        transform.position += new Vector3(0, 0, -10);
        transform.gameObject.GetComponent<Camera>().orthographicSize = BIKE_PART_SIZE;
    }

    public void ClickOnSparkplugs()
    {
        GameObject sparkplugs = _bicycle.transform.Find("Sparkplugs").gameObject;
        transform.localScale = sparkplugs.transform.localScale;
        transform.position = sparkplugs.transform.position;
        transform.position += new Vector3(0, 0, -10);
        transform.gameObject.GetComponent<Camera>().orthographicSize = MINI_BIKE_PART_SIZE;
    }

    public void ClickOnRadiator()
    {
        GameObject radiator = _bicycle.transform.Find("Radiator").gameObject;
        transform.localScale = radiator.transform.localScale;
        transform.position = radiator.transform.position;
        transform.position += new Vector3(0, 0, -10);
        transform.gameObject.GetComponent<Camera>().orthographicSize = BIKE_PART_SIZE;
    }

    public void ClickOnHeadlight()
    {
        GameObject headlight = _bicycle.transform.Find("Headlight").gameObject;
        transform.localScale = headlight.transform.localScale;
        transform.position = headlight.transform.position;
        transform.position += new Vector3(0, 0, -10);
        transform.gameObject.GetComponent<Camera>().orthographicSize = BIKE_PART_SIZE;
    }

    public void ClickOnExhaust()
    {
        GameObject exhaust = _bicycle.transform.Find("Exhaust").gameObject;
        transform.localScale = exhaust.transform.localScale;
        transform.position = exhaust.transform.position;
        transform.position += new Vector3(0, 0, -10);
        transform.gameObject.GetComponent<Camera>().orthographicSize = BIKE_PART_SIZE;
    }

    public void ClickOnClutch()
    {
        GameObject clutch = _bicycle.transform.Find("Clutch").gameObject;
        transform.localScale = clutch.transform.localScale;
        transform.position = clutch.transform.position;
        transform.position += new Vector3(0, 0, -10);
        transform.gameObject.GetComponent<Camera>().orthographicSize = MINI_BIKE_PART_SIZE;
    }

    // ===== Useful BackButton functions ===== //

    // Be sure to use setactive properly!
    public void ClickOnBackToFirstMenuButton()
    {
        transform.localScale = originalCameraScale;
        transform.position = originalCameraPosition;
        transform.position += new Vector3(0, 0, -10);
        transform.gameObject.GetComponent<Camera>().orthographicSize = ORIGNIAL_CAMERA_SIZE;
    }

    // Sets camera back to bikepartssecondmenu
    public void ClickBackToBikePartsSecondMenu()
    {
        ClickInspectBike();
        transform.gameObject.GetComponent<Camera>().orthographicSize = ORIGNIAL_CAMERA_SIZE;
    }

    // ===== Useful Camera Constants ===== //
    // Note that minis are components of other bike parts
    private static float ORIGNIAL_CAMERA_SIZE = 82.34186f;
    private static float BIKE_PART_SIZE = 40f;
    private static float MINI_BIKE_PART_SIZE = 20f;
    private static Vector3 originalCameraPosition = new Vector3(0, 0, -10);
    private static Vector3 originalCameraScale = new Vector3(10, 10, 0.66518f);

    // ===== Useful Bike TextBox options ===== //


}
