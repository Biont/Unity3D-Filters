﻿//using UnityEngine;
//using System.Collections;
//
//public class FilterExample : MonoBehaviour
//{
//
//		// Use this for initialization
//		void Start ()
//		{
//
//				#region string example
//
//				/**
//				 * A Filter is added by providing the filter name and your function to execute.
//				 * The third parameter is an optional tag if you wish to exchange or remove the filter later on
//				 * 
//		 		 */
//				Filters.Add ("test-string", (filterString) => {
//						return "Filtered: " + (string)filterString;
//				}, "string-override");
//
//
//				/**
//		 		 * This is an example without the tag parameter
//		 		 */ 
//				Filters.Add ("test-string", (filterString) => {
//						// You need to cast from object to your actual type
//						return (string)filterString + " ...and I love it";
//				});
//
//
//				/* It's also possible to add a Filter at a specific position. 
//				 * Probably the most common use case is adding a high priority filter
//				 * at the very beginning of the filter list.
//				 * 
//				 * So let's add a filter that changes the input string before any other operation takes place
//				 * By setting the optional priority argument to 0
//				 * 
//		 		 */
//				Filters.Add ("test-string", (filterString) => {
//						return "We replaced the entire string";
//				}, null, 0);
//				
//
//				string testString = "This is our string";
//
//
//
//				/** You can also remove filters if you know their tag. Uncomment this to test it: */
//
////				Filters.Remove ("test-string", "string-override");
//				
//
//				/**
//				 * To apply all filters, pass the filter name and the variable to filter into the Apply() function.
//				 * Don't forget to cast to the correct type again as all variables are handled as objects internally
//		 		 */
//				testString = (string)Filters.Apply ("test-string", testString);
//
//				/** Now let's see what we've got */
//				Debug.Log (testString);
//
//				#endregion
//
//
//				#region Vector3 Example
//				Filters.Add ("test-vector3", (filterVector3) => {
//						Vector3 tempVec = (Vector3)filterVector3;
//						Debug.Log ("We now replace the Vector3.zero with Vector3.one");
//						return Vector3.one;
//				});
//		
//		
//				Vector3 testVec = Vector3.zero;
//		
//				testVec = (Vector3)Filters.Apply ("test-vector3", testVec);
//				Debug.Log (testVec);
//				#endregion
//
//				#region additional arguments
//				/**
//				 * You can pass additional arguments as an object array
//				 * Filters that utilize these arguments will be called before filters that don't use them.
//				 * But this works only one-way: Applying filters without arguments (Like any example above)
//				 * will omit any filter with arguments, so be careful
//				 */ 
//
//				Filters.Add ("test-arguments", (vec,args) => {
//						Vector3 tempVec = (Vector3)vec;
//
//						Vector3 arg1 = (Vector3)args [0];
//						string playerName = (string)args [1];
//
//
//						Debug.Log ("This Filter is called before...");
//
//						if (playerName == "PlayerName") {
//								tempVec = new Vector3 (99, 99, 99);
//						}
//
//						return tempVec;
//
//				});
//
//				Filters.Add ("test-arguments", (vec) => {
//						Vector3 tempVec = (Vector3)vec;
//						Debug.Log ("...this one");
//						if (Vector3.Distance (tempVec, new Vector3 (99, 99, 99)) < 0.1) {
//								tempVec = new Vector3 (66, 66, 66);
//						}
//			
//						return tempVec;
//			
//				});
//				
//
//				testVec = (Vector3)Filters.Apply ("test-arguments", testVec, new object[] {new Vector3 (20, 10, 30), "PlayerName"});
//				Debug.Log (testVec);
//
//
//				#endregion
//
//
//				
//
//		}
//	
//
//}
