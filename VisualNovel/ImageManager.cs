using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* A class just so we can place images properly.
 * @author John Angeles
 */
public class ImageManager : MonoBehaviour {

    private void Awake()
    {
        inkManager = GetComponent<InkManager>();
    }

    /* Requesting access to our inkManager script.
     */
    private InkManager inkManager;

    /* The gameobject that we activate to display an image.
     */
    public GameObject imageToDisplayThings;

    /* Set of available sprites for this scene. Basically, anytime our script writer would like to display an image,
     * he or she would have to call DisplayImage with exactly the name of the sprite to display it on the screen.
     */
    public Sprite[] _images;

    /* The most recently placed button on the screen.
     */
    private Button activeButton;

    /* Displays the sprite whose name is SPRITEIMAGENAME until the person clicks continue.
     */
    public void DisplayImage(string spriteImageName)
    {
        // Find the sprite to change
        for (int i = 0; i < _images.Length; i ++)
        {
            if (_images[i].name == spriteImageName)
            {
                imageToDisplayThings.GetComponent<Image>().sprite = _images[i];
            }
        }

        // Activate the Image
        imageToDisplayThings.SetActive(true);

        // Create a button so that we can close the image.
        Button closeImageButton = inkManager.CreateChoiceView("Close Image");
        closeImageButton.onClick.AddListener(delegate
        {
            CloseImage();
        });

        activeButton = closeImageButton;
    }

    /* Closes the image, and place a new continue button.
     */
    public void CloseImage()
    {
        imageToDisplayThings.SetActive(false);
        Destroy(activeButton.gameObject);
        Button newContinueButton = inkManager.AddContinueButton();
        inkManager.PlaceButton(newContinueButton, 0);
        activeButton = null;
    }

    [SerializeField]
    private Button buttonPrefab;


}
