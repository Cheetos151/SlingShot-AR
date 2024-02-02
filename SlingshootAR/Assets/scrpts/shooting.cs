
using UnityEngine;


public class shooting : MonoBehaviour
{
    private GameObject Projectile;
    private Rigidbody ProjectileRB;
    [SerializeField] private GameObject ProjectilePrefab;
    private float distance;
    private Vector2 startpos, endpos;

    
    void Update()
    {
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            startpos = touch.position;
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            endpos = touch.position;
        }


        if (Input.touchCount > 0)
        {
            if (touch.phase == TouchPhase.Began)
            {

                Projectile = Instantiate(ProjectilePrefab, startpos, Quaternion.identity);
                ProjectileRB = ProjectilePrefab.GetComponent<Rigidbody>();
                ProjectileRB.useGravity = false;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Projectile.transform.position = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                distance = Vector2.Distance(startpos, endpos);
                ProjectileRB.AddForce(new Vector3(0f, 0f, distance) * 3f);
                ProjectileRB.useGravity = true;
                
            }
            
        }
        
    }
}

