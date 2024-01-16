using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    #region Variables

    public GameObject Player;
    [SerializeField] WalletUI walletUI;
    public GameObject SkinUI;
    public GameObject noMoney;
    public GameObject[] outfits;
    private int Count;
    public bool[] BuyOutfit;
    public int[] prices;
    public RuntimeAnimatorController[] animatorController;
    public GameObject[] textBuy;
    public GameObject[] textPlay;


    #endregion

    #region Methods
    private void OnEnable()
    {
        Count = 0;
        noMoney.SetActive(false);
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
                walletUI.Close();
                gameObject.GetComponent<ShopController>().OnBackFromBuying();
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
            BuyOutfit[Count] = true;
            Player.GetComponent<Animator>().runtimeAnimatorController = animatorController[Count];
            SkinUI.SetActive(false);
            walletUI.Close();
            noMoney.SetActive(false);
            textBuy[Count].SetActive(false);
            textPlay[Count].SetActive(true);
            gameObject.GetComponent<ShopController>().Buyed();
        }
        else if(BuyOutfit[Count] == false && Wallet.i.money < prices[Count])
        {
            noMoney.SetActive(true);
            Invoke("NoMoney", 5f);
        }     
        
        if(BuyOutfit[Count] == true)
        {
            Player.GetComponent<Animator>().runtimeAnimatorController = animatorController[Count];
            SkinUI.SetActive(false);
            walletUI.Close();
            noMoney.SetActive(false);
            gameObject.GetComponent<ShopController>().Buyed();
        }
    }

    public void NoMoney()
    {
        noMoney.SetActive(false);
    }

    #endregion
}


