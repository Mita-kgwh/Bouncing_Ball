using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRing : MonoBehaviour
{
    [SerializeField] SpriteRenderer spritetop;
    [SerializeField] SpriteRenderer spritebottom;
    [SerializeField] Sprite newspritetop;
    [SerializeField] Sprite newspritebottom;
    public bool ispassed = false;
    // Start is called before the first frame update
    private void Update()
    {
        if (ispassed)
        {
            spritetop.sprite = newspritetop;
            spritebottom.sprite = newspritebottom;
        }
    }
    
}
