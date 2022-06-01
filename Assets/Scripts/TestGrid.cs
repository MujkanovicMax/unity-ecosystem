using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGrid : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        //GridWorld grid2 = new GridWorld(5,3,10f);
        Vector3 from = Vector3.zero;
        Vector3 to = Vector3.zero;
        from.x = transform.position.x - transform.localScale.x/2;
        from.z = transform.position.z - transform.localScale.z/2;
        to.x = transform.position.x + transform.localScale.x/2;
        to.z = transform.position.z + transform.localScale.z/2;
        print(from);
        print(to);
        GridWorld grid = new GridWorld(25,25,from, to);
        print(grid.getCellSizeX());
        print(grid.getCellSizeZ());
        int x,z;
        Vector3 pos = new Vector3(12,0,12);
        grid.GetXZ(pos, out x, out z);
        print(new Vector2(x,z));
    }

    
}
