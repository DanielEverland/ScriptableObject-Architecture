using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingCubes : MonoBehaviour
{
    [SerializeField]
    private GameObject cubePrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlaceCubes();
        }
        else if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            DeleteCubes();
        }
    }
    private void PlaceCubes()
    {
        Vector3 mousePosInWorld = GetMousePosInWorld();
        GameObject instantiatedCube = SpawnCubeInWorld(mousePosInWorld);
    }
    private void DeleteCubes()
    {
        RaycastHit hitInfo = new RaycastHit();
        if(Physics.Raycast(GetMouseRay(), out hitInfo))
        {
            Destroy(hitInfo.collider.gameObject);
        }
    }
    private Ray GetMouseRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }
    private Vector3 GetMousePosInWorld()
    {
        Vector3 mouseWorldPos = GetMouseRay().GetPoint(0);
        mouseWorldPos.z = 0;

        return mouseWorldPos;
    }
    private GameObject SpawnCubeInWorld(Vector3 position)
    {
        GameObject cube = GameObject.Instantiate(cubePrefab);
        cube.transform.position = position;

        return cube;
    }
}
