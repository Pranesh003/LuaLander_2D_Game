using TMPro;
using UnityEngine;

public class StatusUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI statsTextMesh;


    private void Update()
    {
        UpdateStatsTextMeshPro();
    }
    private void UpdateStatsTextMeshPro()
    {

       statsTextMesh.text= GameManager.Instance.GetScore() +"\n"+
                           Mathf.Round( GameManager.Instance.GetTime()) + "\n" + 
                           Mathf.Round( Lander.Instance.GetSpeedX() * 10f) + "\n" + 
                           Mathf.Round( Lander.Instance.GetSpeedY() * 10f) + "\n" + 
                           Lander.Instance.GetFuelAmount()
                           ;
    }
}
