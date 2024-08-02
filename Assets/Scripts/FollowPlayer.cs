using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //Player Reference
    [SerializeField] private Transform playerTransform;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Teeh-hee en: " + playerTransform.position);
        //Follow Player position
        if (playerTransform.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, playerTransform.position.y, transform.position.z);
        }
    }
}
