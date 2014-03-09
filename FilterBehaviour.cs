using UnityEngine;
using System.Collections;
using BiontTools;

public class FilterBehaviour : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{


				Filters.Add ("test-string", (filterString) => {
						return "Das geht!";
				}, "string-override");


				string testString = "Was geht?";

				Filters.Remove ("test-string", "string-override");

				testString = (string)Filters.Apply ("test-string", testString);
				Debug.Log (testString);


				Filters.Add ("test-vector3", (filterVector3) => {
						Vector3 tempVec = (Vector3)filterVector3;

						return new Vector3 (1, 1, 1);
				});
		
		
				Vector3 testVec = Vector3.zero;
		
				testVec = (Vector3)Filters.Apply ("test-vector3", testVec);
				Debug.Log (testVec);




		}
	

}
