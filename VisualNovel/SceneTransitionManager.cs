using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* In charge of transitioning scenes. Kind of acts like the theater tech crew
 * for our purposes.
 * @author John Angeles
 */
public class SceneTransitionManager : MonoBehaviour
{
    /* Scenes to load up.
     */
    public GameObject[] _scenesToLoad;

    /* Transition to scene whose name is scene.
     */
    public void Transition(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
