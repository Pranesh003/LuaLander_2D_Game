using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    private int score;
    private float time;

    private void Awake()
    {
        Instance= this;
    }


    private void Start()
    {

        Lander.Instance.OnCoinPickUp += Lander_OnCoinPickUp;
        Lander.Instance.OnLanded += Lander_OnLanded;
    }

    private void Update()
    {
        time += Time.deltaTime;
    }

    private void Lander_OnLanded(object sender, Lander.onLandedEventArgs e)
    {
        AddScore(e.Score);
    }

    private void Lander_OnCoinPickUp(object sender, System.EventArgs e)
    {
        AddScore(500);
    }

    private void AddScore(int addScoreAmount)
    {
        score += addScoreAmount;
        Debug.Log($"Score: {score}");
    }

    public int GetScore()
    {
        return score;
    }

    public float GetTime()
        {
            return time;
    }
}
