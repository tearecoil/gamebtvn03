using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;

    private bool isGameEnded = false;

    public int maxHealth = 5;
    public int health { get { return currentHealth; } }
    public int currentHealth;

    public Rigidbody2D rigidbody2d;

    public float _speed = 2.5f;
    float horizontal;
    float vertical;

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;
            isInvincible = true;
            invincibleTimer = timeInvincible;
            
        }
        
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }

    void Start()
    {
        
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
        if(currentHealth == 0)
        {
            _speed = 0f;
            EndGame();
        }
        
    }
    private void FixedUpdate()
    {
        Vector2 position = transform.position;
        position.x = position.x + _speed * horizontal * Time.deltaTime;
        position.y = position.y + _speed * vertical * Time.deltaTime;
       
        rigidbody2d.MovePosition(position);
        
        
    }
    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 50;
        style.normal.textColor = Color.white;
        GUI.Label(new Rect(10,10,100,20), "Health: " + currentHealth + " / " + maxHealth,style);
    }
    void EndGame()
    {
       
        StopGameObjects();

        
        isGameEnded = true;
    }

    void StopGameObjects()
    {
        foreach (var gameObject in FindObjectsOfType<MonoBehaviour>())
        {
            gameObject.enabled = false;
        }
    }


}