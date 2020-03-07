using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
	#region Singleton
	static public CombatManager Instance { get; private set; }

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

	[HideInInspector]
	List<Character> allyCurrentCombat = new List<Character>();
	[HideInInspector]
	List<Character> enemyCurrentCombat= new List<Character>();
	public List<Character> currentCombatCharacters = new List<Character>();


	private void Start()
	{
		CombatStartSetup();
	}
	public void CombatStartSetup()
	{
		OrderCharacters();
		AssignCharacterDisplay();
		UIManager.Instance.HideUnassigned();
		RefreshAllCharDisplay();
	}

	public void OrderCharacters()
	{
		currentCombatCharacters.Sort((char2, char1) => char1.currentSpeed.CompareTo(char2.currentSpeed));
		for (int i = 0; i < currentCombatCharacters.Count; i++)
		{
			UIManager.Instance.timeLinePortrait[i].sprite = currentCombatCharacters[i].myLittleSprite;
			if (allyCurrentCombat.Count < 4 && currentCombatCharacters[i].isAlly == true)
			{
				allyCurrentCombat.Add(currentCombatCharacters[i]);
			}
			else if (enemyCurrentCombat.Count < 4 && currentCombatCharacters[i].isAlly == false)
			{
				enemyCurrentCombat.Add(currentCombatCharacters[i]);
			}
			// Temporaire j'enlève les chars en trop de la liste
			else
			{
				currentCombatCharacters.Remove(currentCombatCharacters[i]);
				i--;
			}
		}
	}
	public void AssignCharacterDisplay()
	{
		for (int i = 0; i < allyCurrentCombat.Count; i++)
		{
			allyCurrentCombat[i].myDisplay = UIManager.Instance.alliesDisplay[i];
		}
		for (int i = 0; i < enemyCurrentCombat.Count; i++)
		{
			enemyCurrentCombat[i].myDisplay = UIManager.Instance.enemiesDisplay[i];
		}
	}
	public void RefreshAllCharDisplay()
	{
		for (int i = 0; i < currentCombatCharacters.Count; i++)
		{
			currentCombatCharacters[i].RefreshDisplayInfo();
		}
	}


}
