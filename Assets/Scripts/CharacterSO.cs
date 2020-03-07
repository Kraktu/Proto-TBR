using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character",menuName ="Character")]
public class CharacterSO : ScriptableObject
{
	public string displayNameSO,descriptionSO;
	public float lifeSO, manaSO, rageSO, strenghtSO, speedSO, criticalChanceSO;
	public bool isAllySO;
	public Sprite myLittleSpriteSO;
}
