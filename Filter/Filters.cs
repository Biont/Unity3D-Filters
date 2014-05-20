using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Com.Github.DataStructures;


public class HookCollection
{

		private Dictionary<string,OrderedDictionary<string,Func<object,object>>> filters = new Dictionary<string,OrderedDictionary<string,Func<object,object>>> ();
		private Dictionary<string,OrderedDictionary<string,Action>> actions = new Dictionary<string,OrderedDictionary<string,Action>> ();
		private Dictionary<string,OrderedDictionary<string,Action<object>>> actions1 = new Dictionary<string,OrderedDictionary<string,Action<object>>> ();
//	private Dictionary<string,OrderedDictionary<string,Func<object,object[],object>>> filtersArguments = new Dictionary<string,OrderedDictionary<string,Func<object,object[],object>>> ();


		/// <summary>
		/// Adds a filter with no additional arguments. Returns the filterTag
		/// </summary>
		/// <param name="filterName">Filter name.</param>
		/// <param name="action">Action.</param>
		/// <param name="filterTag">Filter tag.</param>
		public string AddFilter (string filterName, Func<object,object> action, string filterTag = null, int? priority=null)
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

		public string AddAction (string actionName, Action action, string actionTag = null, int? priority=null)
		{
		
				if (actionTag == null) {
						actionTag = Guid.NewGuid ().ToString ();
				}
		
				int dictPriority;
				if (priority != null) {
						dictPriority = (int)priority;
				} else {
						dictPriority = actions.Count;
			
				}
		
				KeyValuePair<string, Action> data = new KeyValuePair<string, Action> (actionTag, action);
		
		
				if (actions.ContainsKey (actionName)) {
						if (actions [actionName].Count >= dictPriority) {
								actions [actionName].Insert (dictPriority, data);
						} else {
								actions [actionName].Add (data);
				
						}
				} else {
						actions.Add (actionName, new OrderedDictionary<string,Action> (){{actionTag,action}});
				}
				return actionTag;
		
		}

		public string AddAction (string actionName, Action<object> action, string actionTag = null, int? priority=null)
		{
		
				if (actionTag == null) {
						actionTag = Guid.NewGuid ().ToString ();
				}
		
				int dictPriority;
				if (priority != null) {
						dictPriority = (int)priority;
				} else {
						dictPriority = actions.Count;
			
				}
		
				KeyValuePair<string, Action<object>> data = new KeyValuePair<string, Action<object>> (actionTag, action);
		
		
				if (actions.ContainsKey (actionName)) {
						if (actions1 [actionName].Count >= dictPriority) {
								actions1 [actionName].Insert (dictPriority, data);
						} else {
								actions1 [actionName].Add (data);
				
						}
				} else {
						actions1.Add (actionName, new OrderedDictionary<string,Action<object>> (){{actionTag,action}});
				}
				return actionTag;
		
		}
		//	/// <summary>
		//	/// Adds a filter with additional arguments. Returns the filterTag
//	/// </summary>
//	/// <param name="filterName">Filter name.</param>
//	/// <param name="action">Action.</param>
//	/// <param name="filterTag">Filter tag.</param>
//	public string Add (string filterName, Func<object,object[],object> action, string filterTag = "", int? priority=null)
//	{
//		
//		if (filterTag == "") {
//			filterTag = Guid.NewGuid ().ToString ();
//		}
//		
//		int dictPriority;
//		if (priority != null) {
//			dictPriority = (int)priority;
//		} else {
//			dictPriority = filtersArguments.Count;
//			
//		}
//		
//		KeyValuePair<string, Func<object,object[], object>> data = new KeyValuePair<string, Func<object,object[], object>> (filterTag, action);
//		
//		
//		if (filtersArguments.ContainsKey (filterName)) {
//			if (filtersArguments [filterName].Count >= dictPriority) {
//				filtersArguments [filterName].Insert (dictPriority, data);
//			} else {
//				filtersArguments [filterName].Add (data);
//				
//			}
//		} else {
//			filtersArguments.Add (filterName, new OrderedDictionary<string,Func<object,object[],object>> (){{filterTag,action}});
//		}
//		return filterTag;
//		
//		
//	}
		/// <summary>
		/// Remove all Filters for this filterName
		/// </summary>
		/// <param name="filterName">Filter name.</param>
		public void RemoveFilter (string filterName)
		{
		
				filters.Remove (filterName);
//		filtersArguments.Remove (filterName);
		
		}
	
		/// <summary>
		/// Remove the specified Filter by filterTag.
		/// </summary>
		/// <param name="filterName">Filter name.</param>
		/// <param name="filterTag">Filter tag.</param>
		public void RemoveFilter (string filterName, string filterTag)
		{
				if (filters.ContainsKey (filterName)) {
			
						if (filters [filterName].Remove (filterTag)) {
								//								Debug.Log (filterTag + " removed successfully from Filter " + filterName);
						}
			
				}
		
		
//		if (filtersArguments.ContainsKey (filterName)) {
//			
//			if (filtersArguments [filterName].Remove (filterTag)) {
//				//								Debug.Log (filterTag + " removed successfully from Filter " + filterName);
//			}
//			
//		}
		}
	
	
	
		/// <summary>
		/// Applies a Filter
		/// </summary>
		/// <param name="filterName">Filter name.</param>
		/// <param name="source">Source.</param>
		public object ApplyFilters (string filterName, object source)
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

		public void DoAction (string actionName)
		{
		
				if (actions.ContainsKey (actionName)) {
			
						foreach (KeyValuePair<string,Action> action in actions[actionName]) {
				
								action.Value ();
						}
			
				} else {
						//						Debug.Log ("There were no actions added for " + actionName);
				}

		
		
		}
	
		public void DoAction (string actionName, object source)
		{


				if (actions1.ContainsKey (actionName)) {
			
						foreach (KeyValuePair<string, Action<object> > action in actions1[actionName]) {
				
								action.Value (source);
						}
			
				} else {
						//						Debug.Log ("There were no actions added for " + actionName);
				}
		
		
		}
	
	
	
		//	/// <summary>
//	/// Applies a Filter with additional arguments
//	/// </summary>
//	/// <param name="filterName">Filter name.</param>
//	/// <param name="source">Source.</param>
//	/// <param name="arguments">Arguments.</param>
//	public object Apply (string filterName, object source, object[] arguments)
//	{
//		
//		if (filtersArguments.ContainsKey (filterName)) {
//			
//			foreach (KeyValuePair<string, Func<object,object[],object> > action in filtersArguments[filterName]) {
//				
//				source = action.Value (source, arguments);
//			}
//			
//		} else {
//			//						Debug.Log ("There were no filters added for " + filterName);
//		}
//		
//		return Apply (filterName, source);
//	}

}

public static class Hooks
{


		private static HookCollection hooks = new HookCollection ();


		/// <summary>
		/// Adds a filter with no additional arguments. Returns the filterTag
		/// </summary>
		/// <param name="filterName">Filter name.</param>
		/// <param name="action">Action.</param>
		/// <param name="filterTag">Filter tag.</param>
		public static string AddFilter (string filterName, Func<object,object> action, string filterTag = null, int? priority=null)
		{

				return hooks.AddFilter (filterName, action, filterTag, priority);
	
		}
//		/// <summary>
//		/// Adds a filter with additional arguments. Returns the filterTag
//		/// </summary>
//		/// <param name="filterName">Filter name.</param>
//		/// <param name="action">Action.</param>
//		/// <param name="filterTag">Filter tag.</param>
//		public static string Add (string filterName, Func<object,object[],object> action, string filterTag = "", int? priority=null)
//		{
//		return hooks.Add (filterName, action, filterTag, priority);
//			
//		}
		/// <summary>
		/// Remove all Filters for this filterName
		/// </summary>
		/// <param name="filterName">Filter name.</param>
		public static void RemoveFilter (string filterName)
		{
			
				hooks.RemoveFilter (filterName);

		}

		/// <summary>
		/// Remove the specified Filter by filterTag.
		/// </summary>
		/// <param name="filterName">Filter name.</param>
		/// <param name="filterTag">Filter tag.</param>
		public static void RemoveFilter (string filterName, string filterTag)
		{
				hooks.RemoveFilter (filterName, filterTag);
		
		}



		/// <summary>
		/// Applies a Filter
		/// </summary>
		/// <param name="filterName">Filter name.</param>
		/// <param name="source">Source.</param>
		public static object ApplyFilters (string filterName, object source)
		{
	

				return hooks.ApplyFilters (filterName, source);
		}

//		/// <summary>
//		/// Applies a Filter with additional arguments
//		/// </summary>
//		/// <param name="filterName">Filter name.</param>
//		/// <param name="source">Source.</param>
//		/// <param name="arguments">Arguments.</param>
//		public static object ApplyFilters (string filterName, object source, object[] arguments)
//		{
//			
//			
//		return hooks.ApplyFilters (filterName, source,arguments);
//		}
}


