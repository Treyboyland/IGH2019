using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IImpact
{
    void Affect(Enemy enemy);
    void Cancel(Enemy enemy);
}
