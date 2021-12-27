using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoqeMechanic : MonoBehaviour
{




    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Egg_collected"))
        {
            Debug.Log("hhhhhh");
            transform.LookAt(other.gameObject.transform.position);
            transform.position = Vector3.Lerp(transform.position, other.gameObject.transform.position, 0.25f * Time.deltaTime);

        }
    }
}
