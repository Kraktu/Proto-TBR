using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct CharacterDisplay
{
	public Text lifeDisplay, manaDisplay, rageDisplay,nameDisplay;
	public Image portraitDisplay;
	public Image lifeFiller, manaFiller, rageFiller;
}

public class UIManager : MonoBehaviour
{
	#region Singleton
	static public UIManager Instance { get; private set; }
	
	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
			return;
		}

		Instance = this;
	}
	#endregion
	public CharacterDisplay[] alliesDisplay, enemiesDisplay;
	public Image[] timeLinePortrait;

	public void DisplayCharacter(CharacterDisplay characterDisplay,Character characterToDisplay)
	{
		if (characterToDisplay.isAlly)
		{
			characterDisplay.manaDisplay.text = characterToDisplay.currentMana + " / " + characterToDisplay.maxMana;
			characterDisplay.manaFiller.fillAmount = characterToDisplay.currentMana / characterToDisplay.maxMana;
			characterDisplay.rageDisplay.text = characterToDisplay.currentRage + " / " + characterToDisplay.maxRage;
			characterDisplay.rageFiller.fillAmount = characterToDisplay.currentRage / characterToDisplay.maxRage;
		}
		if (!characterToDisplay.isAlly)
		{
			characterDisplay.nameDisplay.text = characterToDisplay.displayName;
		}
		characterDisplay.lifeDisplay.text = characterToDisplay.currentLife + " / " + characterToDisplay.maxLife;
		characterDisplay.lifeFiller.fillAmount = characterToDisplay.currentLife / characterToDisplay.maxLife;
		characterDisplay.portraitDisplay.sprite = characterToDisplay.myLittleSprite;
	}
	public void HideUnassigned()
	{
		for (int i = 0; i < alliesDisplay.Length; i++)
		{
			if (alliesDisplay[i].portraitDisplay.sprite==null)
			{
				alliesDisplay[i].portraitDisplay.GetComponentInParent<Transform>().gameObject.SetActive(false);
			}
		}
		for (int i = 0; i < enemiesDisplay.Length; i++)
		{
			if (enemiesDisplay[i].portraitDisplay.sprite == null)
			{
				enemiesDisplay[i].portraitDisplay.GetComponentInParent<Transform>().gameObject.SetActive(false);
			}
		}
		for (int i = 0; i < timeLinePortrait.Length; i++)
		{
			if (timeLinePortrait[i].sprite == null)
			{
				timeLinePortrait[i].gameObject.SetActive(false);
			}
		}
	}
}
