using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AhriController : MonoBehaviour
{


    public void MoveToPosition(Vector3 destination)
    {
        this.gameObject.transform.position = destination;
    }

}
