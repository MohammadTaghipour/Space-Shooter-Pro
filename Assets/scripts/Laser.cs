using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float _speed = 8.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
        if(transform.position.y > 8.0f)
        {
            if (this.transform.parent != null) { 
                Destroy(this.transform.parent.gameObject);
            }
            Destroy(this.gameObject, 0); // delay to destroy
        }

    }
}
