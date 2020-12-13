using UnityEngine;
using UnityEngine.UI;

public class ui : MonoBehaviour
{
    public Text movesLeftText;
    public int movesLeft;

    private void Start()
    {
        movesLeftText.text = "MovesLeft: " + movesLeft;

    }
    public void MoveUsed()
    {
        movesLeft -= 1;
        movesLeftText.text = "MovesLeft: " + movesLeft;

    }
}
