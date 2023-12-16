using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject gameObjectObjeto;
    protected Vector3 posicionOrigenObjeto;
    protected Vector3 posicionOrigenCamara;


    // Start is called before the first frame update
    void Start()
    {
        posicionOrigenObjeto = gameObjectObjeto.transform.position;
        posicionOrigenCamara = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (gameObjectObjeto.transform.position - posicionOrigenObjeto) + posicionOrigenCamara;
    }
}
