using UnityEngine;
using System.Collections;

public class UI_Armory : MonoBehaviour 
{

	public GameObject[] allyShips;

	public Transform armoryPanel;
	public Transform armoryPanelSlot;

	UIManager uimanager;
    SoundManager soundManager;
    public AudioClip audioClip;

	// Use this for initialization
	void Start () 
	{

		allyShips = Resources.LoadAll<GameObject>("Prefabs/Ships/Ally");
		uimanager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<UIManager>();
        soundManager = GetComponent<SoundManager>();


        for (int i = 0; i < allyShips.Length; i++) 
		{

			Transform create_armorySlots = (Transform)Instantiate(armoryPanelSlot, 
				armoryPanel.position, armoryPanel.rotation) as Transform;

            create_armorySlots.GetComponent<UI_ArmortSlot>().thisShip = allyShips[i].gameObject;

            create_armorySlots.transform.SetParent(armoryPanel, true);
			
		}
	
	}
		
	public void ClosePanel()
	{

        soundManager.PlaySound(audioClip);
        Destroy(GameObject.FindGameObjectWithTag("_buildPanel"));
		uimanager.panelActive = false;

	}
}
