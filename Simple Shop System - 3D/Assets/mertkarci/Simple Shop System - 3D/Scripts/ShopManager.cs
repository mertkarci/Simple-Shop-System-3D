using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;
using Palmmedia.ReportGenerator.Core.Reporting.Builders.Rendering;

public class ShopManager : MonoBehaviour
{

    [Header("Buttons")]
    public Button[] next_previous;
    public GameObject[] select_buy; // 0 select button , 1 buy button
    [Header("Items you want to display")]
    public myObject[] objectsToBuy;
    [Header("Spawnpoint of objects")]
    
    [Header("Text UI Objects (TMPro)")]
    public TextMeshProUGUI price;
    public TextMeshProUGUI idShow;
    public TextMeshProUGUI playerMoneyText;
    [Header("Spinning Platform")]
    public Transform platform;
    [SerializeField]
    private int objects_id; 

    private int playerMoney = 9999999;     // Change this value according to the structure of your own game.
    [SerializeField]
    [Header("Spawnpoints of succesful buy animation effects")]
    private Transform[] fireworksSpawnPoint;
    [SerializeField]
    [Header("Animation effect on succesful buy event")]
    private GameObject firework;
    [Header("Sound Effects")]
    [SerializeField]
    private AudioSource fireworkExplosion;
    [SerializeField]
    private AudioSource buySound;
    void Start()
    {
        
        objects_id = 0;
        Show(objects_id);
        playerMoneyText.text = ""+ playerMoney.ToString();
    }

    void Update()
    {

    }

    public void TryToBuy() // Call this function on click event of buy button
    {
        if (playerMoney >= objectsToBuy[objects_id].price && objectsToBuy[objects_id].isAvailable == false)
        {
            playerMoney -= objectsToBuy[objects_id].price;
            objectsToBuy[objects_id].isAvailable = true;
            ShowCorrectButton(objectsToBuy[objects_id].isAvailable);
            playerMoneyText.text = "" + playerMoney.ToString();
            for(int i = 0; i < fireworksSpawnPoint.Length; i++) 
            {
                buySound.Play();
                Instantiate(firework, fireworksSpawnPoint[i]);
                Invoke("PlayExplosion", 1);
            }
        }
        else
        {
            // not enough money text or play warning animation bla bla ...
        }
        CheckStatus();
    }
    void PlayExplosion()  // Sound Effect
    {
        fireworkExplosion.Play();
    }
    public void Select(string type) // Call this function on click event of select button. Write "type1" in empty box.
    {
        switch (type)
        {
            case "type1":
                for (int i = 0; i < objectsToBuy.Length; i++)
                {
                    objectsToBuy[i].isTaken = false;
                }
                objectsToBuy[objects_id].isTaken = true;
                price.text = "Selected";
                break;
            case "type2": // Still developing.....
                break;
        }
    }
    public void Show(int _id) // Spawns the correct object.
    {
        CheckStatus();
        idShow.text = _id.ToString();

        if (platform.childCount > 0)
        {
            Destroy(platform.GetChild(0).gameObject);
        }

        GameObject spawn = objectsToBuy[_id].SpawnIt();
        spawn.transform.SetParent(platform);
        

        ShowCorrectButton(objectsToBuy[_id].isAvailable);
    }

    public void ShowCorrectButton(bool isAvailable) 
    {
        select_buy[0].SetActive(isAvailable);
        select_buy[1].SetActive(!isAvailable);
    }

    public void ChangeObject(bool isNext) // Call this function on next and previous buttons. Tick the box if its the next button.
    {
        if (isNext)
        {
            if (objects_id + 1 > objectsToBuy.Length - 1)
            {
                objects_id = 0;
            }
            else
            {
                objects_id++;

            }

        }
        else
        {
            if (objects_id - 1 < 0)
            {
                objects_id = objectsToBuy.Length - 1;
            }
            else
            {
                objects_id--;

            }
        }
        Show(objects_id);

        if (objectsToBuy[objects_id].isTaken)
        {
            price.text = "Selected";
        }

    }
    public void CheckStatus() // Sets the texts
    {
        if (objectsToBuy[objects_id].isAvailable)
        {
            price.text = objectsToBuy[objects_id].isTaken ? "Selected" : "";
        }
        else
        {
            price.text = objectsToBuy[objects_id].price.ToString();
            objectsToBuy[objects_id].isTaken = false;
        }
    }
}
