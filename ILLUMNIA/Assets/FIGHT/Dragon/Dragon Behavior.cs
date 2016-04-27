using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DragonBehavior : MonoBehaviour {
    private GameObject enemyhealthSliderObjectGameObject;
    public Slider enemyHealthSlider;
    EnemyHealth enemyHealth;                    // Reference to this enemy's health.
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
    }
}
