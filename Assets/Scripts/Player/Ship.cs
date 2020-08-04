using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ship : MonoBehaviour
{

    public int health = 1;
    public int maxHealth = 1;
    public int abilityCells = 1;
    public int maxAbilityCells = 1;
    public Slider healthSlider;
    public Slider abilitySlider;
    public GameObject bulletPrefab;
    public GameObject bulletSpawn;

    // Start is called before the first frame update
    void Start()
    {

        PlayerMovement.Instance.shootEvent.AddListener(shoot);

    }

    public void Damage(int amount)
    {

        health -= amount;

        //TODO: Make the ship die if it takes too much damage (negative HP)

    }
    void shoot()
    {

        GameObject bullet = Instantiate<GameObject>(bulletPrefab, bulletSpawn.transform);
        bullet.transform.parent = null;

    }

    // Update is called once per frame
    void Update()
    {

        healthSlider.value = (float)health / maxHealth;
        abilitySlider.value = (float)abilityCells / maxAbilityCells;

    }
}
