using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public static class Filters
{

		private static Dictionary<string,Dictionary<string,Func<object,object>>> filters = new Dictionary<string,Dictionary<string,Func<object,object>>> ();
		private static Dictionary<string,Dictionary<string,Func<object,object[],object>>> filtersArguments = new Dictionary<string,Dictionary<string,Func<object,object[],object>>> ();

		/// <summary>
		/// Adds a filter with no additional arguments. Returns the filterTag
		/// </summary>
		/// <param name="filterName">Filter name.</param>
		/// <param name="action">Action.</param>
		/// <param name="filterTag">Filter tag.</param>
		public static string Add (string filterName, Func<object,object> action, string filterTag = "")
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
				return filterTag;
	
		}
		/// <summary>
		/// Adds a filter with additional arguments. Returns the filterTag
		/// </summary>
		/// <param name="filterName">Filter name.</param>
		/// <param name="action">Action.</param>
		/// <param name="filterTag">Filter tag.</param>
		public static string Add (string filterName, Func<object,object[],object> action, string filterTag = "")
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
				return filterTag;
			
			
		}
		/// <summary>
		/// Remove all Filters for this filterName
		/// </summary>
		/// <param name="filterName">Filter name.</param>
		public static void Remove (string filterName)
		{
			
				filters.Remove (filterName);
				filtersArguments.Remove (filterName);

		}

		/// <summary>
		/// Remove the specified Filter by filterTag.
		/// </summary>
		/// <param name="filterName">Filter name.</param>
		/// <param name="filterTag">Filter tag.</param>
		public static void Remove (string filterName, string filterTag)
		{
				Dictionary<string,Func<object,object>> actionList = null;
				if (filters.TryGetValue (filterName, out actionList)) {

						if (actionList.Remove (filterTag)) {
								Debug.Log (filterTag + " removed successfully from Filter " + filterName);
						}
								
				}

				Dictionary<string,Func<object,object[],object>> actionListArguments = null;
		
				if (filtersArguments.TryGetValue (filterName, out actionListArguments)) {
			
						if (actionListArguments.Remove (filterTag)) {
								Debug.Log (filterTag + " removed successfully from Filter " + filterName);
						}
			
				}
		}



		/// <summary>
		/// Applies a Filter
		/// </summary>
		/// <param name="filterName">Filter name.</param>
		/// <param name="source">Source.</param>
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

		/// <summary>
		/// Applies a Filter with additional arguments
		/// </summary>
		/// <param name="filterName">Filter name.</param>
		/// <param name="source">Source.</param>
		/// <param name="arguments">Arguments.</param>
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


