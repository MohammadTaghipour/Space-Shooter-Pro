using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private Text _scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _scoreText.text = "Score: "+0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int score)
    {
        _scoreText.text = "Score: " + score;
    }


}
