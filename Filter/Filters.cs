using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Com.Github.DataStructures;


public static class Filters
{

		private static Dictionary<string,OrderedDictionary<string,Func<object,object>>> filters = new Dictionary<string,OrderedDictionary<string,Func<object,object>>> ();
		private static Dictionary<string,OrderedDictionary<string,Func<object,object[],object>>> filtersArguments = new Dictionary<string,OrderedDictionary<string,Func<object,object[],object>>> ();

		/// <summary>
		/// Adds a filter with no additional arguments. Returns the filterTag
		/// </summary>
		/// <param name="filterName">Filter name.</param>
		/// <param name="action">Action.</param>
		/// <param name="filterTag">Filter tag.</param>
		public static string Add (string filterName, Func<object,object> action, string filterTag = null, int? priority=null)
		{

				if (filterTag == null) {
						filterTag = Guid.NewGuid ().ToString ();
				}

				int dictPriority;
				if (priority != null) {
						dictPriority = (int)priority;
				} else {
						dictPriority = filters.Count;
			
				}

				KeyValuePair<string, Func<object, object>> data = new KeyValuePair<string, Func<object, object>> (filterTag, action);


				if (filters.ContainsKey (filterName)) {
						if (filters [filterName].Count >= dictPriority) {
								filters [filterName].Insert (dictPriority, data);
						} else {
								filters [filterName].Add (data);
				
						}
				} else {
						filters.Add (filterName, new OrderedDictionary<string,Func<object,object>> (){{filterTag,action}});
				}
				return filterTag;
	
		}
		/// <summary>
		/// Adds a filter with additional arguments. Returns the filterTag
		/// </summary>
		/// <param name="filterName">Filter name.</param>
		/// <param name="action">Action.</param>
		/// <param name="filterTag">Filter tag.</param>
		public static string Add (string filterName, Func<object,object[],object> action, string filterTag = "", int? priority=null)
		{
			
				if (filterTag == "") {
						filterTag = Guid.NewGuid ().ToString ();
				}

				int dictPriority;
				if (priority != null) {
						dictPriority = (int)priority;
				} else {
						dictPriority = filtersArguments.Count;
			
				}
			
				KeyValuePair<string, Func<object,object[], object>> data = new KeyValuePair<string, Func<object,object[], object>> (filterTag, action);
		
			
				if (filtersArguments.ContainsKey (filterName)) {
						if (filtersArguments [filterName].Count >= dictPriority) {
								filtersArguments [filterName].Insert (dictPriority, data);
						} else {
								filtersArguments [filterName].Add (data);
				
						}
				} else {
						filtersArguments.Add (filterName, new OrderedDictionary<string,Func<object,object[],object>> (){{filterTag,action}});
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
				if (filters.ContainsKey (filterName)) {

						if (filters [filterName].Remove (filterTag)) {
//								Debug.Log (filterTag + " removed successfully from Filter " + filterName);
						}
								
				}

		
				if (filtersArguments.ContainsKey (filterName)) {
			
						if (filtersArguments [filterName].Remove (filterTag)) {
//								Debug.Log (filterTag + " removed successfully from Filter " + filterName);
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

				if (filters.ContainsKey (filterName)) {

						foreach (KeyValuePair<string, Func<object,object> > action in filters[filterName]) {

								source = action.Value (source);
						}

				} else {
//						Debug.Log ("There were no filters added for " + filterName);
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
			
				if (filtersArguments.ContainsKey (filterName)) {
				
						foreach (KeyValuePair<string, Func<object,object[],object> > action in filtersArguments[filterName]) {
					
								source = action.Value (source, arguments);
						}
				
				} else {
//						Debug.Log ("There were no filters added for " + filterName);
				}
			
				return Apply (filterName, source);
		}
}


