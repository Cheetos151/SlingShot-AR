using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;

public class shooting : MonoBehaviour
{

    [SerializeField] private Rigidbody Bulletrb;
    private bool isshoot;
    [SerializeField] private Transform BulletSpawnPoint;
    [SerializeField] private GameObject Bullet;
    private float shootingforce = 5f;
    private Vector2 touchstartpos;
    private Vector2 touchendpos;
    void Start()
    {
  
        isshoot = false;
        Bulletrb.useGravity = false;
       
    }

     void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Instantiate(Bullet, BulletSpawnPoint.position, Quaternion.identity);

            if (touch.phase == TouchPhase.Began)
            {
                touchstartpos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                touchendpos = touch.position;
            }
        }

        float distance = Vector2.Distance(touchstartpos, touchendpos);
        Bulletrb.AddForce(new Vector3(0f, 0f, distance) * shootingforce, ForceMode.Impulse);
        isshoot = true;
        Bulletrb.useGravity = true;
        Invoke("DestroyBullet", 3f);
    }

    void DestroyBullet()
    {
        Destroy(Bullet);
    }


}
