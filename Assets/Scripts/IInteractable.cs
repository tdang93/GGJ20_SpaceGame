using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable {
    void interact(GameObject go);
    void repair(GameObject go);
}
