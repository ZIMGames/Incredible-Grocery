using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuyer
{
    void GoToCassa();
    void LeaveCassa();
    virtual void showProducts(List<Sprite> productSprites) { }
}
