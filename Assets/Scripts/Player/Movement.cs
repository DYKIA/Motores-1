using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TP-Final Arraigada Gonzalo
namespace Movement
{
    interface IMovement
    {
        public float jumpForce { get; set; }
        public float move { get; set; }
        public Rigidbody rb { get; set; }
       
    }
}
