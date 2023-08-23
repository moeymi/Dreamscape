using UnityEngine;

[CreateAssetMenu(fileName = "New Character Body", menuName = "Character Body")]
public class CharacterBody_SO : ScriptableObject
{
    public BodyPart_SO headBodyPart;

    public BodyPart_SO clothesBodyPart;
}