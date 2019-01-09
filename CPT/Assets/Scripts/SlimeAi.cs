using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SlimeAi : MonoBehaviour {

    public float speed;
    public float Followspeed;
    public float distance;

    public Animator animator;

    private bool movingLeft = true;
    private bool m_FacingRight;
    public bool PlayerFound;

    private Collider2D target;
    private Transform targetPos;

    public Transform groundDetection;
    public Transform playerDetection;

    public int damage;

    public RaycastHit2D groundInfo;

    public void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        targetPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void Update()
    {
        if ((GameObject.Find("Player") != null))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);

            RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
            if (groundInfo.collider == false)
            {
                if (movingLeft == true)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingLeft = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    movingLeft = true;

                }
            }
            else
            {
                FindPlayer();
            }
        }
    }


    public void FindPlayer ()
    {
        RaycastHit2D playerDetect = Physics2D.Raycast(playerDetection.position, Vector2.left, distance);
        
            if (playerDetect.collider == target)
            {
                PlayerFound = true;
                FollowPlayer();
            }
            else
            {
                PlayerFound = false;
            }
        

    }

    public void FollowPlayer ()
    {
        if (PlayerFound == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos.position, Followspeed * Time.deltaTime);
        }
            
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
