using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public GameObject Player;
    [SerializeField] WalletUI walletUI;
    public GameObject SkinUI;
    public GameObject[] outfits;
    private int Count;
    public bool[] BuyOutfit;
    public int[] prices;
    public RuntimeAnimatorController[] animatorController;

    private void OnEnable()
    {
        Count = 0;
    }

    void Update()
    {
        if(Count >= 4)
        {
            Count = 0;
        } 
        else if(Count <= -1)
        {
            Count = 3;
        }

        if (SkinUI.activeSelf)
        {
            walletUI.Show();
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SkinUI.SetActive(false);
                walletUI.Close();
            }
                
        }

        outfits[Count].SetActive(true);

    }

    public void NextOption()
    {
        Count += 1;

        if (Count - 1 == -1)
        {
            outfits[3].SetActive(false);
        }
        else
        {
            outfits[Count - 1].SetActive(false);
        }
        
    }

    public void BackOption()
    {
        Count -= 1;

        if (Count + 1 == 4)
        {
            outfits[0].SetActive(false);
        }
        else
        {
            outfits[Count + 1].SetActive(false);
        }
    }

    public void PlayGame()
    {
        if (BuyOutfit[Count] == false && Wallet.i.money >= prices[Count])
        {
            Wallet.i.TakeMoney(prices[Count]);
            Player.GetComponent<Animator>().runtimeAnimatorController = animatorController[Count];
            SkinUI.SetActive(false);
        }
        else if(BuyOutfit[Count] == false && Wallet.i.money < prices[Count])
        {

        }     
        
        if(BuyOutfit[Count] == true)
        {
            Player.GetComponent<Animator>().runtimeAnimatorController = animatorController[Count];
            SkinUI.SetActive(false);
        }
    }
}


