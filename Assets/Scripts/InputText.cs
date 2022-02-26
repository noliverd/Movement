using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputText : MonoBehaviour
{
   private Text _input;
   public bool _textY, _textX;

   private void Start() 
   {
       _input = this.gameObject.GetComponent<Text>();        
   }

   private void Update() 
   {

    Vector2 playerInput;

    playerInput.x = Input.GetAxis("Horizontal");
    playerInput.y = Input.GetAxis("Vertical");

    if (_textX)  _input.text = playerInput.x.ToString("0.00");
    if (_textY)  _input.text = playerInput.y.ToString("0.00");

   }
}
