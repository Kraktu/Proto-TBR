using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
	[HideInInspector]
	public string displayName, description;
	[HideInInspector]
	public float maxLife, maxMana, maxRage,maxStrenght,maxSpeed,maxCriticalChance;
	[HideInInspector]
	public float currentLife, currentMana, currentRage, currentStrenght, currentSpeed, currentCriticalChance;
	[HideInInspector]
	public bool isAlly;
	[HideInInspector]
	public Sprite myLittleSprite;
	[HideInInspector]
	public CharacterDisplay myDisplay;
	public CharacterSO myCharSO;

	public void Awake()
	{
		TakeInfoFromData();
		SetStartingStats();
	}
	public void TakeInfoFromData()
	{
		displayName = myCharSO.displayNameSO;
		description = myCharSO.descriptionSO;
		maxLife = myCharSO.lifeSO;
		maxMana = myCharSO.manaSO;
		maxRage = myCharSO.rageSO;
		maxStrenght = myCharSO.strenghtSO;
		maxSpeed = myCharSO.speedSO;
		maxCriticalChance = myCharSO.criticalChanceSO;
		myLittleSprite = myCharSO.myLittleSpriteSO;
		isAlly = myCharSO.isAllySO;
	}
	public void SetStartingStats()
	{
		currentLife = maxLife;
		currentMana = maxMana;
		currentRage = 0;
		currentSpeed = maxSpeed;
		currentStrenght = maxStrenght;
		currentCriticalChance = maxCriticalChance;
	}
	public void RefreshDisplayInfo()
	{
		UIManager.Instance.DisplayCharacter(myDisplay, this);
	}
}
