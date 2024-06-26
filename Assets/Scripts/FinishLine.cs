using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private int _goalDiamonds = 1;
    [SerializeField] private TextMeshPro _textDiamondsNumber;
    public UnityEvent<FinishLine> HasWon;
    public void Start()
    {
        _textDiamondsNumber.text = _goalDiamonds.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory player = other.GetComponent<PlayerInventory>();
            if (_goalDiamonds <= player.NumberOfDiamonds)
            {
                HasWon.Invoke(this);
            }
            
        }
    }
}
