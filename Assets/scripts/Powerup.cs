using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _Speed = 3.0f;

    // ID for powerups
    // 0 = Triple shot
    // 1 = Speed
    // 2 = Shield
    [SerializeField]
    private int powerdupID;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // move down at a speed of 3
        // when we leave the screen, destroy the object
        transform.Translate(Vector3.down * _Speed * Time.deltaTime);

        if (transform.position.y < -4.5f)
        {
            Destroy(this.gameObject);
        }
    }

    // OnTriggerCollision
    // only be collectable by the player (HINT: Use Tags)
    // on collected, destory

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                switch (powerdupID)
                {
                    case 0:
                        player.TripleShotActive();
                        break;
                    case 1:
                        player.SpeedBoostActive();
                        break;
                    case 2:
                        player.ShieldsActive();
                        break;
                }
                Destroy(this.gameObject);
            }
        }
    }
}
