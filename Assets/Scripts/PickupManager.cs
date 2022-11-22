using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickupManager : MonoBehaviour
{
    public TextMeshProUGUI pickupScore;
    public int pickupScoreNumber;

    private void Update()
    {
        pickupScore.text = pickupScoreNumber.ToString();
    }
}
