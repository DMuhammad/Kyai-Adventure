using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    PlayerLogic logicmovement;

    // Start is called before the first frame update
    void Start()
    {
        logicmovement = this.GetComponentInParent<PlayerLogic>();
    }

    private void OnTriggerEnter(Collider other)
    {
        logicmovement.groundedchanger();
    }

    // Update is called once per frame
    void Update()
    {

    }
}