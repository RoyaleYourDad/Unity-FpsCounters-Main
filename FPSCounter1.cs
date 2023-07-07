using UnityEngine;
using UnityEngine.UI;
 
public class FPSCounter : MonoBehaviour
{
    public int avgFrameRate;
    public Text display_Text;
 
    public void Update ()
    {
        float current = 0;
        current = Time.frameCount / Time.time;
        avgFrameRate = (int)current;
        display_Text.text = avgFrameRate.ToString() + " FPS";
    }
}

// how to use?:
// create canvas
// create empty gameobject into canvas
// add text component to empty gameobject
// and move for where you need
// see the result