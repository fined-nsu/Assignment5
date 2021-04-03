using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDrop : MonoBehaviour
{
    public Text gameOverText;

    // Update is called once per frame
    void Update()
    {
        gameOverText.transform.Translate(0f, -250f * Time.deltaTime, 0f);
    }
}