using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS : MonoBehaviour
{
    public Transform player;
    public bool isFlipped = false;

    float speed = 8f;
    Vector3 targetPos;   
    /*int pointIndex;
    int pointCount;*/
    /*int direction = 1;*/
    float step;
    [SerializeField] Transform Playertarget;
    float minimumDistance;
    public HealthManager healthBar3;
    float healthAmount = 100;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        minimumDistance = 20f;
        healthBar3 = GetComponent<HealthManager>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthAmount <= 0)
        {
            Destroy(gameObject);
            anim.SetTrigger("Death");
        }
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if( transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
    private void FixedUpdate()
    {

        step = speed * Time.fixedDeltaTime;

        if (Vector2.Distance(transform.position, Playertarget.position) < minimumDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Playertarget.position, step);
        }

    }

}
