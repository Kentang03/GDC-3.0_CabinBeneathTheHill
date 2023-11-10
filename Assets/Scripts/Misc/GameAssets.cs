using UnityEngine;
using System.Reflection;

public class GameAssets : MonoBehaviour {
    private static GameAssets instance;

    public static GameAssets Instance {
        get {
            if (instance == null) instance = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            return instance;
        }
    }

    public Transform pfTextPopup;
}