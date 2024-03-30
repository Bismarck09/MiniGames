using UnityEngine;

public class OpenShop : MonoBehaviour
{

    private int clickCounts = 0;
    [SerializeField] private GameObject shopMenu;
    void ClickLogic()
    {
        if(clickCounts % 2 != 0)
            shopMenu.SetActive(true);
        else
            shopMenu.SetActive(false);

    }

    public void Click()
    {
        clickCounts++;
        ClickLogic();
    }
}
