using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaidaSuelo : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Jugador")
        {
            StartCoroutine(values());
        }
    }

    public IEnumerator values()
    {
        yield return new WaitForSeconds(0.80f);
        rb.useGravity = true;
        rb.isKinematic = false;
        Destroy(gameObject, 1);
    }
}
