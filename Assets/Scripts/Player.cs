using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float playerUpForce;
    private float currentForce = 0;
    private View view;
    private int count;

    public void Init(View view)
    {
        this.view = view;
        ShowTale();
    }

    void FixedUpdate()
    {
        Vector2 upForce = new Vector2(0, playerUpForce);

        if (Input.GetKey(KeyCode.Space))
            currentForce += playerUpForce;
        else if (currentForce > 0)
            currentForce -= playerUpForce;

        if (currentForce < 0)
            currentForce = 0;
        
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, currentForce));

    }

    public  void ShowTale()
    {
        transform.GetChild(0).GetComponent<ParticleSystem>().Play();
    }


    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.TryGetComponent(out Yellow yellow))
        {
            yellow.JumpRight();
            count++;
            view.UpdateCounter(count);
        }
        else
            SceneManager.LoadScene(0);
    }

}
