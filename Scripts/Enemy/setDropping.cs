using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setDropping : MonoBehaviour
{
    private CollectPopUp collectPopUp;

    private void Start()
    {
        collectPopUp = GetComponent<CollectPopUp>();

        collectPopUp.Fe = 2;

        int rd = Random.Range(1, 10);

        if (rd == 1 || rd == 2 || rd == 3)
            collectPopUp.Pb = 1;

        if (rd == 4 || rd == 5 || rd == 6)
            collectPopUp.Au = 1;


    }

}
