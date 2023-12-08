using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StapeliaGames{

public class LookingScript : MonoBehaviour {
    public float sensitivity = 5.0f;
    Vector2 mouseLook;
    GameObject character;
    public static bool can_look;
    
    void Start() {
        character = this.transform.parent.gameObject;
        EnableLook();
        LockCursor();
    }

    void Update() {
        if(can_look) {
            var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            md = Vector2.Scale(md, new Vector2(sensitivity, sensitivity));
            mouseLook += md;
            mouseLook.y = Mathf.Clamp(mouseLook.y, -75, 75);
            transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
            character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
        }
    }

    public void DisableLook() {
        can_look = false;
    }

    public void EnableLook() {
        can_look = true;
    }

    public void LockCursor() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UnlockCursor() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
}
