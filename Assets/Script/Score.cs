using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{

    [SerializeField] Text text;
    private int score;

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        if(text != null)
        {
            text.text = score.ToString();
        }
    }

    public void AddScore() { score++; }
}
