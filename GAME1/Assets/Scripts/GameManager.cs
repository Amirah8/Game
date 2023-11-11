using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI CoinText;
    public TextMeshProUGUI HealthText;
    public Slider HealthSlider;

    // Start is called before the first frame update
    void Start()
    {
        CoinText.text = "Coin 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void UpdateCoinText(int coins)
    {
        CoinText.text = "Coin " + coins.ToString() ;
    }
    public void UpdateHealthText(int CurrentHealth , int MaxHealth)
    {
        HealthText.text = CurrentHealth + "/" + MaxHealth.ToString() ;
         float NewCurrentHealth = (float)CurrentHealth / MaxHealth;
        HealthSlider.value = NewCurrentHealth;
    }

}
