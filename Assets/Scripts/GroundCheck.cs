using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    MovementLogic logicmovement;

    // Start is called before the first frame update
    void Start()
    {
        logicmovement = this.GetComponentInParent<MovementLogic>();
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
