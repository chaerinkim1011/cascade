using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    private float speed = 10;

    private float horizontal;
    public int maxHP = 3;
    private int currentHP;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        currentHP = maxHP;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        PlayerMove();
        ScreenChk();
    }

    private void PlayerMove()
    {
        rigidbody.velocity = new Vector2(horizontal*speed, rigidbody.velocity.y);
    }
   
    private void ScreenChk()
    {
        Vector3 worlpons = Camera.main.WorldToViewportPoint(this.transform.position);
        if (worlpons.x < 0.05f) worlpons.x = 0.05f;
        if (worlpons.x > 0.95f) worlpons.x = 0.95f;
        this.transform.position = Camera.main.ViewportToWorldPoint(worlpons);
    }
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log("플레이어 HP: " + currentHP);

        if (currentHP <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Debug.Log("플레이어 사망");
        Destroy(gameObject);
    }
}