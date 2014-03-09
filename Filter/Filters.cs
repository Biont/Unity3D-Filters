using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public static class Filters
{

		private static Dictionary<string,Dictionary<string,Func<object,object>>> filters = new Dictionary<string,Dictionary<string,Func<object,object>>> ();
		private static Dictionary<string,Dictionary<string,Func<object,object[],object>>> filtersArguments = new Dictionary<string,Dictionary<string,Func<object,object[],object>>> ();

		public static void Add (string filterName, Func<object,object> action, string filterTag = "")
		{

				if (filterTag == "") {
						filterTag = Guid.NewGuid ().ToString ();
				}
			

				Dictionary<string,Func<object,object>> actionList = null;
				if (filters.TryGetValue (filterName, out actionList)) {
						actionList.Add (filterTag, action);
				} else {
						filters.Add (filterName, new Dictionary<string,Func<object,object>> (){{filterTag,action}});
				}

	
		}

		public static void Add (string filterName, Func<object,object[],object> action, string filterTag = "")
		{
			
				if (filterTag == "") {
						filterTag = Guid.NewGuid ().ToString ();
				}
			
			
				Dictionary<string,Func<object,object[],object>> actionList = null;
				if (filtersArguments.TryGetValue (filterName, out actionList)) {
						actionList.Add (filterTag, action);
				} else {
						filtersArguments.Add (filterName, new Dictionary<string,Func<object,object[],object>> (){{filterTag,action}});
				}
			
			
		}


		public static void Remove (string filterName, string filterTag)
		{
				Dictionary<string,Func<object,object>> actionList = null;
				if (filters.TryGetValue (filterName, out actionList)) {

						if (actionList.Remove (filterTag)) {
								Debug.Log (filterTag + " removed successfully from Filter " + filterName);
						} else {
								Debug.Log (filterTag + " not found in " + filterName);
					
						}
								
				} else {
						Debug.Log ("Filter " + filterName + " could not be foundr ");
				
				}
		}

	
		public static object Apply (string filterName, object source)
		{

				Dictionary<string,Func<object,object>> actionList = null;
				if (filters.TryGetValue (filterName, out actionList)) {

						foreach (KeyValuePair<string, Func<object,object> > action in actionList) {

								source = action.Value (source);
						}

				} else {
						Debug.Log ("There were no filters added for " + filterName);
				}

				return source;
		}

		public static object Apply (string filterName, object source, object[] arguments)
		{
			
				Dictionary<string,Func<object,object[],object>> actionList = null;
				if (filtersArguments.TryGetValue (filterName, out actionList)) {
				
						foreach (KeyValuePair<string, Func<object,object[],object> > action in actionList) {
								//								foreach (Func<object,object> action in actionList) {
					
								source = action.Value (source, arguments);
						}
				
				} else {
						Debug.Log ("There were no filters added for " + filterName);
				}
			
				return Apply (filterName, source);
		}
}


