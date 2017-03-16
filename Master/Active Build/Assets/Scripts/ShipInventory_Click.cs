using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShipInventory_Click : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //Public Variables
	public int ID;
	public int avalible_Ships = 0;
    public int shipLevel;
	public Text avalibleShip_Display;
	public Button slotButton;
	public GameObject shipPrefab;
    public GameObject shipDescriptionPanel;
    public Material coloredHex;

	//Private Variables
	GameObject objectsParent;
	BuildManager buildManager;

    void Awake()
    {
        this.gameObject.name = "Ship_" + ID;
        shipPrefab.GetComponent<ShipParameters>().invSlot = this.transform.gameObject;


    }

	// Use this for initialization
	void Start () 
	{

		//this.gameObject.name = "Ship_" + ID;
		buildManager = GameObject.Find ("GameManagers").GetComponent<BuildManager> ();

        //if we start with 0 ships set the button to not interactable
        if (avalible_Ships == 0)
        {

            slotButton.interactable = false;

        }


	}

	// Update is called once per frame
	void Update () 
	{

		//Updating the text prefab with the amount of ships we have avalible. 
		avalibleShip_Display.text = "" + avalible_Ships;

		//Running the UpdateShipAvalibleNumber function.
		UpdateShipAvalibleNumber (0);
	
	}

    //When we click the slot if we have ships we can deploy them.
    public void OnMouseClick()
    {

        if (avalible_Ships > 0) 
		{
			
			Debug.Log ("You have ships");
            if (buildManager.allyShip == null)
            {
                avalible_Ships--;
                buildManager.allyShip = shipPrefab;

                //Now change the color of our avalible hexs
                buildManager.GetOurAvalibleHexs();
                buildManager.ChangeOurHexMaterial(coloredHex);



            }

			if (avalible_Ships == 0) 
				
			{

				Debug.Log ("You Don't have any ships");
				slotButton.interactable = false;

			}
        }
	}

    public void OnPointerEnter(PointerEventData eventData)
    {

            ShipDesc();

    }

    public void OnPointerExit(PointerEventData eventData)
    {


        StartCoroutine(DestroyUIDesc(1F));


    }

    void ShipDesc()
    {

        if (UIManager.shipDescriptionAvtice == false)
        {
            GameObject panelOrigin = GameObject.FindGameObjectWithTag("ShipDescriptionPanel");

            //Instantiate 
            GameObject BuildingPanel = (GameObject)Instantiate(shipDescriptionPanel, panelOrigin.transform.position, panelOrigin.transform.rotation);
            BuildingPanel.transform.SetParent(panelOrigin.transform, false);
            BuildingPanel.transform.localPosition = Vector3.zero;
            ShipDescription.ourShipInfo = shipPrefab;

            UIManager.shipDescriptionAvtice = true;

        }

    }

    //If we have ships. Button becomes avalible.
    public void UpdateShipAvalibleNumber (int shipCounterValue)
	{

		avalible_Ships += shipCounterValue;

		if (avalible_Ships > 0) 
		{

			slotButton.interactable = true;
		
		}

	}

    IEnumerator DestroyUIDesc(float timer)
    {

        yield return new WaitForSeconds(timer);
        Destroy(GameObject.Find("shipDesc(Clone)"));
        UIManager.shipDescriptionAvtice = false;

    }
}
