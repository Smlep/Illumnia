using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DragonBehavior : MonoBehaviour {
    float TimerMecanic = 5;
    private GameObject enemyhealthSliderObjectGameObject;
    public Slider enemyHealthSlider;
    EnemyHealth enemyHealth;                    // Reference to this enemy's health.
    Animation Anim;
    // Use this for initialization
    void Start () {
        enemyHealth = GetComponent<EnemyHealth>();
        enemyhealthSliderObjectGameObject = GameObject.FindGameObjectWithTag("BossHealthSlider2");
        enemyHealthSlider = enemyhealthSliderObjectGameObject.GetComponent<Slider>();
        enemyHealthSlider.maxValue = enemyHealth.startingHealth;
    }
	
	// Update is called once per frame
	void Update () {
        // Slider de vie
        enemyHealthSlider.value = enemyHealth.currentHealth;
        TimerMecanic -= Time.deltaTime;
        if (TimerMecanic < 0)
        {
            Mecanic2();
            TimerMecanic = 10;
        }
    }
    //Souffle
    void Mecanic1()
    {
        Anim.Play("Armature|Envol");
    }
    //Coup d'aile droite ou gauche
    void Mecanic2()
    {
        Anim.Play("Armature|Envol");
    }
    //Envol
    void Mecanic3()
    {
        Anim.Play("Armature|Envol");
    }
}
