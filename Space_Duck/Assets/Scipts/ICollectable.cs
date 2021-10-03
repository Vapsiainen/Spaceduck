using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectable 
{
    public Sprite GrayScaleSprite { get; set; }
    public Sprite CollectedSprite { get; set; }
}
