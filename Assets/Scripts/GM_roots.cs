using System;
using System.Collections;
using System.Collections.Generic;
using SplineMesh;
using UnityEngine;
using Random = UnityEngine.Random;

public class GM_roots : MonoBehaviour
{
    // public GameObject[] objectsWithRootsScript;
    public GameObject[] BranchPrefabs;

    private void Start()
    {
        StartCoroutine(GrowBranchRoutine());
    }

    IEnumerator GrowBranchRoutine()
    {
        while (true)
        {
            GrowBranch();
            yield return new WaitForSeconds(2);
        }
    }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.R))
        // {
        //
        //     // create new branch
        //     GrowBranch();
        // }

    }

    private void GrowBranch()
    {

        GameObject branch = Instantiate(BranchPrefabs[Random.Range(0, BranchPrefabs.Length)]);
        branch.transform.position = RootController.instance.transform.position;
        
        // branch angle range
        branch.transform.localRotation = Quaternion.AngleAxis(Random.Range(-180,180),Vector3.up);

    }
    
    
}
