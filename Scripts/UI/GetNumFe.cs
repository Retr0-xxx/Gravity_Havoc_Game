using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetNumFe : MonoBehaviour
{
    public TextMeshProUGUI TextMeshPro;

    private void Start()
    {
        TextMeshPro = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        TextMeshPro.text = Inventory.Fe.ToString();
    }
}
