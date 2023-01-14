using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SelectedAnimation : ScriptableObject
{
    public enum Animation_
    {
        Macarena = 0,
        HipHop = 1,
        House = 2,
        NoDance = -1
    }
    [SerializeField] Animation_ selection;
    public Animation_ Selection { get => selection; set => selection = value; }
}
