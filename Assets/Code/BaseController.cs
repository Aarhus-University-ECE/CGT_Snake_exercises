using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    // Start is called before the first frame update
    public abstract void GrowSnake();
    public abstract void SpawnApple();
    public abstract void SpawnCoin();
    public abstract void SpawnPortal();
}
