//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//
//public class FilterAPIExample : MonoBehaviour
//{
//
//		// Use this for initialization
//		void Start ()
//		{
//
//				AddFilters ();
//
//
//				string example = APIExample (new Args{
//					{"name","Max"},
//					{"health",60},
//					{"position",new Vector3(10,0,30)},
//					{"target",new Vector3(15,0,20)},
//				});
//
//				Debug.Log (example);
//		}
//	
//
//		string APIExample (Args newArgs)
//		{
//				Args args = new Args{
//					{"name","John"},
//					{"level",23},
//					{"class","warrior"},
//					{"health",100},
//					{"position",Vector3.zero},
//				};
//				args.MergeWith (newArgs); // Merges passed args with defaults
//
//				// Filter the args before doing anything
//				// so additional arguments can be added from the outside
//
//				args = Filters.Apply ("api-example-args", args)  as Args; 
//				
//				string name = (string)args ["name"];
//				int level = (int)args ["level"];
//				int health = (int)args ["health"];
//				string charClass = (string)args ["class"];
//				Vector3 position = (Vector3)args ["position"];
//
//
//				string output = "This is " + name + ", a level " + level + " " + charClass + ".";
//				output += "His health is at " + health + " and his current position is " + position.ToString ();
//		
//				// Filter the returned string again, so any additional logic can be added from outside
//
//				return (string)Filters.Apply ("api-example-return", output, new object[]{args});
//
//		}
//
//
//		void AddFilters ()
//		{
//
//
//				// This filter adds an "origin" argument to the method args and scales the health
//				Filters.Add ("api-example-args", (args) => {
//						Args tempArgs = args as Args;
//						tempArgs.Add ("origin", new Vector3 (-12, 0, 34));
//						tempArgs ["health"] = (int)tempArgs ["health"] * 5;
//						return tempArgs;
//			
//				});
//				
//				// this filter reacts to the "origin" argument
//				Filters.Add ("api-example-return", (output,args) => {
//						Args tempArgs = args [0] as Args;
//						if (tempArgs.ContainsKey ("origin")) {
//								Vector3 origin = (Vector3)tempArgs ["origin"];
//								Vector3 position = (Vector3)tempArgs ["position"];
//
//								float distance = Vector3.Distance (origin, position);
//				
//								return (string)output + " He's " + distance + "m away from his home.";
//				
//						}
//						return output;
//				});
//
//				// This filter checks if a "target" argument has been passed
//				Filters.Add ("api-example-return", (output,args) => {
//						Args tempArgs = args [0] as Args;
//						if (tempArgs.ContainsKey ("target")) {
//								Vector3 origin = (Vector3)tempArgs ["target"];
//								Vector3 position = (Vector3)tempArgs ["position"];
//				
//								float distance = Vector3.Distance (origin, position);
//				
//								return (string)output + " He's " + distance + "m away from his target.";
//				
//						}
//						return output;
//				});
//		
//		}
//}
