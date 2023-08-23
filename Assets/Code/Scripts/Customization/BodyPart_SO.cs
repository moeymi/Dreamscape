using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Body Part", menuName = "Body Part")]
public class BodyPart_SO : Item_SO, IEquippable
{
    public int partAnimationID;
    public string partType;
    public List<AnimationClip> partAnimationClips = new List<AnimationClip>();

    public void Equip()
    {
        // TODO
    }
}
