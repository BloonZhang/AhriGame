using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AhriController : MonoBehaviour
{

    // setting variables
    private float shakeTime = 0.1f;
    private float shakeDistance = .15f;

    // helper variables
    private Vector3 shakeOriginLocation;

    void Start()
    {
        shakeOriginLocation = this.gameObject.transform.position;
    }

    public void MoveToPosition(Vector3 destination)
    {
        StopAllCoroutines();
        this.gameObject.transform.position = destination;
        shakeOriginLocation = this.gameObject.transform.position;
    }

    public void Shake()
    {
        StopAllCoroutines(); 
        this.gameObject.transform.position = shakeOriginLocation;
        StartCoroutine(ShakeCoroutine());
    }
    public void Dip()
    {
        StopAllCoroutines();
        this.gameObject.transform.position = shakeOriginLocation;
        StartCoroutine(DipCoroutine());
    }
    public void Return()
    {
        StopAllCoroutines();
        this.gameObject.transform.position = new Vector3(
                                                    shakeOriginLocation.x, 
                                                    shakeOriginLocation.y - shakeDistance, 
                                                    shakeOriginLocation.z);
        StartCoroutine(ReturnCoroutine());
    }

    // helper methods
    private void Reset()
    {
        StopAllCoroutines();
    }

    // Couroutines
    IEnumerator ShakeCoroutine()
    {
        yield return StartCoroutine(DipCoroutine());
        yield return StartCoroutine(ReturnCoroutine());
    }
    IEnumerator DipCoroutine()
    {
        float movementInterval = shakeDistance / 10f;
        for (int i = 0; i < 10; i++)
        {
            this.gameObject.transform.position = new Vector3(
                                                        this.gameObject.transform.position.x,
                                                        this.gameObject.transform.position.y - movementInterval,
                                                        this.gameObject.transform.position.z);
            yield return new WaitForSeconds((shakeTime/2f) / 10f);
        }
    }
    IEnumerator ReturnCoroutine()
    {
        float movementInterval = shakeDistance / 10f;
        for (int i = 0; i < 10; i++)
        {
            this.gameObject.transform.position = new Vector3(
                                                        this.gameObject.transform.position.x,
                                                        this.gameObject.transform.position.y + movementInterval,
                                                        this.gameObject.transform.position.z);
            yield return new WaitForSeconds((shakeTime/2f) / 10f);
        }
    }

}
