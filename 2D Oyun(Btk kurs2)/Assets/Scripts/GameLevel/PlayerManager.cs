using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour
{
    public float health;
    bool dead = false;

    Transform muzzle;

    public Transform bullet,floatingText,bloodParticle;
    public float bulletSpeed=10;

    public Slider slider;

    bool mouseIsNotOverUI;
    
    void Start()
    {
        muzzle = transform.GetChild(1);
        slider.maxValue = health;
        slider.value = health;
    }

    void Update()
    {
        mouseIsNotOverUI = EventSystem.current.currentSelectedGameObject == null;
        if (Input.GetMouseButtonDown(0) && mouseIsNotOverUI)
        {
            shootBullet();
        }
        
    }
    public void GetDamage(float damage)
    {
       
        
        Instantiate(floatingText,transform.position, Quaternion.identity).GetComponent<TextMesh>().text = damage.ToString();
        
        if ((health-damage)>=0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
        slider.value = health;
        AmIDead();

    }
    void AmIDead()
    {
        if (health<=0)
        {
            Destroy(Instantiate(bloodParticle, transform.position, Quaternion.identity), 3);
            dead = true;
            Destroy(gameObject);
        }
        else
        {
            dead = false;
        }

    }

    void shootBullet()
    {
        Transform tempBullet; 
        tempBullet= Instantiate(bullet, muzzle.position,Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward*bulletSpeed);
        DataManager.Instance.ShotBullet++;
    }
}
