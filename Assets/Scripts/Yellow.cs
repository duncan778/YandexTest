using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow : MonoBehaviour
{
    [SerializeField] float horSpeed = 5;
    [SerializeField] float followSpeed = 5;
    [SerializeField] float minRadius = 5;
    [SerializeField] float maxRadius = 8;
    private Player player;
    private bool following;

    public void Init(Player player)
    {
        this.player = player;
    }

    void Update()
    {
        Vector3 wayToPlayer = player.transform.position - transform.position;
        float distance = Vector3.Magnitude(wayToPlayer);

        if (!following && distance < minRadius)
            following = true;
        else if (following && distance > maxRadius)
            following = false;
            
        transform.position = new Vector3(transform.position.x - Time.deltaTime * horSpeed, transform.position.y, 0);

        if (following)
            transform.Translate(wayToPlayer.normalized * Time.deltaTime * followSpeed);
        
        if (transform.position.x < -10)
            JumpRight();
            

    }

    public void JumpRight()
    {
        transform.position = new Vector3(transform.position.x + UnityEngine.Random.Range(30,50), transform.position.y, 0);    
    }
}
