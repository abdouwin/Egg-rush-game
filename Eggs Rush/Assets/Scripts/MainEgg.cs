using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEgg : MonoBehaviour, IObstacle
{

   public Reset_Transform reset_Transform;


    private List<GameObject> ringCollecteds = new List<GameObject>();
    public static float offset = -0.01747f;

    int i = 0;

    // Tags 
    public const string _egg = "Egg";
    public const string _egg_collected = "Egg_collected";
    public const string _hummer = "Hummer";
    public const string _cock = "Cock";
    public const string _fryer = "Fryer";
    public const string _sale = "Sale";


    [HideInInspector] public GameObject coqe;



    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(_egg))
        {
            ringCollecteds.Add(collision.gameObject);
            i++;
            // Set new parent object and reset the transofrm with an offset in z axis

            collision.gameObject.transform.parent = this.transform;
            collision.gameObject.tag = _egg_collected;
            collision.gameObject.transform.localRotation = reset_Transform.Resetrotation();
            collision.gameObject.transform.localScale = reset_Transform.Resetscale();
            collision.gameObject.transform.localPosition = new Vector3(reset_Transform.Resetposition().x, reset_Transform.Resetposition().y + offset, reset_Transform.Resetposition().z);

            if (collision.gameObject.GetComponent<EggsCollected>() == null)
                collision.gameObject.AddComponent<EggsCollected>();
            else
                collision.gameObject.GetComponent<EggsCollected>().enabled = true;

            
            offset = offset + -0.01747f;

        }

        if (collision.gameObject.CompareTag(_hummer))
        {
            //hummer script
        }

        if (collision.gameObject.CompareTag(_cock))
        {
            //coqe script
        }

        if (collision.gameObject.CompareTag(_fryer))
        {
            //mqla script
        }
        if (collision.gameObject.CompareTag(_sale))
        {
            //mqla script
        }

    }

    public void Obstacle(GameObject egg)
    {

        //define target
        Vector3 target = egg.transform.position;
        coqe.transform.LookAt(target);
        //run to target
        coqe.transform.position = Vector3.Lerp(coqe.transform.position, target, 0.25f * Time.deltaTime);

        // animation of coqe
    }


}



/// <summary>
/// Rest the transform of object
/// </summary>
public readonly struct Reset_Transform
{
    readonly Vector3 position;
    readonly Vector3 rotation;
    readonly Vector3 scale;

    public Vector3 Resetposition()
    {
        return new Vector3(0, 0, 0);
    }
    public Quaternion Resetrotation()
    {
        return new Quaternion(0, 0, 0, 0);
    }
    public Vector3 Resetscale()
    {
        return new Vector3(1, 1, 1);
    }
}
