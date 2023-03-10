using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed;
    [SerializeField] int health;
    [SerializeField] float force = 80f;
    float x = -9.94f;
    float y = 1.91f;
    public int spawnVariant = 1;

    private bool flipRight = true;
    private Vector3 direction;
    public GameObject PlayerInGunRotation;
    public float offset;

    private Vector2 hitDir;

    void Start()
    {
        
    }
    void Update()
    {
        Vector2 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float move = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * speed, moveVertical * speed);

        if(diference.x > 0f)
{
            Quaternion rot = transform.rotation;
            rot.y = 0;
            rot.x = 0;
            transform.rotation = rot;
        }

        if (diference.x < 0f)
        {
            Quaternion rot = transform.rotation;
            rot.y = 180;
            rot.x = 0;
            transform.rotation = rot;
        }
        //direction.y -= gravity * Time.deltaTime;
        //controller.Move(direction * Time.deltaTime);
    }

    private void Flip()
    {
        flipRight = !flipRight;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
            if (hitInfo.tag == "Enemys")
            {
                //hitInfo.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, force, 0), ForceMode2D.Impulse);
                //hitDir = contact.normal;
                //добавляем импульс объекту в сторону противоположную стороне соприкосновения
                hitInfo.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 0, force), ForceMode2D.Impulse);
                return;
            }
    }

    public void Teleport()
    {
        if (spawnVariant == 1)
        {
            x = -9.94f;
            y = 1.91f;
            spawnVariant = 0;
        }
        else if (spawnVariant == 0)
        {
            x = -9.94f;
            y = -3.87f;
            spawnVariant = 1;
        }
        transform.position = new Vector2(x, y);
        //return;
    }
}
