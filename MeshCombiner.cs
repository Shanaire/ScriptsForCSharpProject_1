using System.Collections.Generic;
using UnityEngine;



public class MeshCombiner : MonoBehaviour
{
    /* 
     * This script is also linked with the MeshCombineEditor script, which is used to creat a button that when the button is 
     * clicked the new merged mesh is created, through the running of the Combine Mesh functuion.
     * 
     * This script is used to create a combined mesh by grabbing all the meshfilters and conbiming them into one new object.
     * 
     * In using this script: 
     *      Apply it an empty gameObject that will be the parent to the objects that you want to combine.
     *      The gameObject will need the mesh renderer script and the the mesh filter script.
     *      When the button is pressed the new objects will be added to the filter of that game object.
     * 
     * Find away to Add the names of the respected material
     * 
     * NEED TO WORK ON THE 65K VERTS LIMITATION 
     * 
     */

    // Maximum amount of verticies that should be joined before crearting a different object.
    [System.NonSerialized]
    public int vertexLimit = 5000;

    public Transform ParentTransform;
    public GameObject ParentMeshes;


    public void AdvanceMeshCombine()
    {
        int vertexCount = 0;

        // This is getting the MeshFilter component of the parent gameobject and storing it in myMeshFilter
        MeshFilter myMeshFilter = new MeshFilter();
        myMeshFilter = GetComponent<MeshFilter>();

        // Getting the previous position and rotation so that it can be applied to the newly created objects
        Quaternion oldRot = transform.rotation;
        Vector3 oldPos = transform.position;

        // Then setting the postition and rotation back to zero.
        transform.rotation = Quaternion.identity;
        transform.position = Vector3.zero;

        // Getting all MeshFilters (For this gameObjects get all the mesh filters from the children that are attached to it)
        MeshFilter[] filters = GetComponentsInChildren<MeshFilter>(false); // Make if FALSE because we don't want to flatten the structure of the filters.

        // This is getting a list of all the different materials that are in the selected object. 
        List<Material> materials = new List<Material>();
        
        // findout what false means in this context// For each of the objects that are in our list, get the mesh renderer for each of those objects
        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>(false);
        
        // Now we iterate through the mesgh renderers adding all the materials to the list, this time we can skip the parent object that has an material
        foreach (MeshRenderer item in renderers)
        {
            if (item.transform == transform) // This statement is to skip our selves from being added to the list of materials.
            {
                continue;
            }
            Material[] localMats = item.sharedMaterials; // this is to give us a list of all the materials on that renderer and add it to this array. 
            foreach (Material item_2 in localMats)// for we can iterate through the arrange and add the items to the list, not repeating any items that are already in that list.
            {
                if (!materials.Contains(item_2))
                {
                    materials.Add(item_2); // This is adding all materials that are in the scene to the list given that the material is not already in the list.
                    Debug.Log("Marteials Added " + item_2);
                }
                Debug.Log("Materials " + item_2);
            }
        }


        // Now we are going to go through the process of creating a mesh for each of the materials that has been added to the materials list.
        // We are going to create a list of meshes, and it is going to be one for each materials.
        List<Mesh> submeshes = new List<Mesh>();
        for (int item = 0; item < materials.Count; item++)
        {
            // This is going to go through the process of creating a combine instance for each of the materials that we are going to create a mesh for.
            // This will also go through all the children submeshes to see if anyof them have the materials that we are currently trying to find.
            // This basically checking all the materials that are already collected with the materials that are in the one the mesh filter to match it, so that it can be applied.
            List<CombineInstance> combiners = new List<CombineInstance>();

            for (int item_2 = 0; item_2 < filters.Length; item_2++)
            { 
                // Add this statement so that the function skips adding our parent object the calculation
                if (myMeshFilter == filters[item_2].GetComponent<MeshFilter>())
                {
                    continue;
                }
                Debug.Log("Mesh Filter items " + item_2);

                MeshRenderer renderer = filters[item_2].GetComponent<MeshRenderer>(); // We have to use the mesh renderer to check if the childern item from the mesh filter are using the same material that we are trying to find.

                Debug.Log("Mesh Renderer we are dealing with " + filters[item_2].GetComponent<MeshRenderer>().name);

                if (renderer == null)
                {
                    Debug.Log(filters[item_2].name + "No MeshRenderer");
                    continue;
                }
                // Now lets create an instance of all the materials that are on the current meshrenderer and add it to the array.
                Material[] localMaterials = renderer.sharedMaterials; // Adding all materials on that are availabel through the mesh rendenerers to the array

                Debug.Log("The Number of Mesh Renderers on the currrent item " + renderer.sharedMaterials.Length);

                for (int materialIndex = 0; materialIndex < localMaterials.Length; materialIndex++)
                {
                    if (localMaterials[materialIndex] != materials[item])
                    {
                        continue;
                    }
                    // Another for loop to prevent unused material positions to be created.
                    for (int materialUsed = 0; materialUsed < localMaterials.Length; materialUsed++)
                    {
                        // But if the material is in the list and it is the material we are looking for, the add it to the combineinstance
                        CombineInstance ci = new CombineInstance
                        {
                            mesh = filters[item_2].sharedMesh,
                            subMeshIndex = materialUsed,
                            transform = filters[item_2].transform.localToWorldMatrix
                        };
                        Debug.Log("Sub Mesh index Count " + ci.subMeshIndex);
                        combiners.Add(ci);
                        Debug.Log("Combiners Count " + combiners.Count);
                    }
                }

            }

            // Now we can flatten the all the meshes into a single mesh creatign one submesh for each material
            Mesh mesh = new Mesh();
            mesh.CombineMeshes(combiners.ToArray(), true);

            Debug.Log("Submesh Count " + submeshes.Count);

            vertexCount += mesh.vertexCount;
            Debug.Log("Vert Count " + vertexCount);

            if (vertexCount < vertexLimit)
            {
                submeshes.Add(mesh);
            }

            else if (vertexCount > vertexLimit)
            {
                // change the foreach loop to a for loop, then i can do i -1
                item -= 1;
                // Remove the last mesh we added to the list as the limit was exceeded.
                Debug.Log("Submesh Count " + submeshes.Count);
                submeshes.RemoveAt(submeshes.Count - 1);

                // Instantiate an new gameObject withthe current geometry
                CreateCombinedMesh(submeshes, ParentMeshes);

                // set number of verts back to 0;
                vertexCount = 0;
                submeshes.Clear();

            }

        }

        CreateCombinedMesh(submeshes, ParentMeshes);

    }


    // This function is used to instantiate or create a new gameobject to the parent that is specified, to house the combined meshes.
    // Function to create the combined meshes;
    public void CreateCombinedMesh(List<Mesh> ListOfMeshes, GameObject ObjToSaveTo)
    {
        // Create an instance of a new mesh to hold the combined meshes
        List<CombineInstance> finalCombiners = new List<CombineInstance>(); // A list to hold all the final set of combine instances that is to be placed into the final mesh


        foreach (Mesh item in ListOfMeshes)
        {
            CombineInstance ci = new CombineInstance
            {
                mesh = item,
                subMeshIndex = 0,
                transform = Matrix4x4.identity
            };

            finalCombiners.Add(ci);
        }

        Mesh newMesh = new Mesh();

        newMesh.CombineMeshes(finalCombiners.ToArray(),false);

        // Instantiate a new game object to hold the combined meshes.
        GameObject _newGameObject = Instantiate(ObjToSaveTo, Vector3.zero, Quaternion.identity) as GameObject;

        _newGameObject.transform.parent = ParentTransform;
        // Add the mesh to the mesh filter of the new game object;
        _newGameObject.GetComponent<MeshFilter>().sharedMesh = newMesh;

        _newGameObject.GetComponent<MeshFilter>().sharedMesh.name = "newMeshes";


    }
}