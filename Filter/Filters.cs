using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Com.Github.DataStructures;

using NoParamFilterDict = System.Collections.Generic.Dictionary<string,Com.Github.DataStructures.OrderedDictionary<string,System.Func<object,object>>> ;
using OneParamFilterDict = System.Collections.Generic.Dictionary<string,Com.Github.DataStructures.OrderedDictionary<string,System.Func<object,object,object>>> ;
using TwoParamFilterDict = System.Collections.Generic.Dictionary<string,Com.Github.DataStructures.OrderedDictionary<string,System.Func<object,object,object,object>>> ;

using NoParamActionDict = System.Collections.Generic.Dictionary<string,Com.Github.DataStructures.OrderedDictionary<string,System.Action>> ;
using OneParamActionDict = System.Collections.Generic.Dictionary<string,Com.Github.DataStructures.OrderedDictionary<string,System.Action<object>>> ;
using TwoParamActionDict = System.Collections.Generic.Dictionary<string,Com.Github.DataStructures.OrderedDictionary<string,System.Action<object,object>>> ;
using ThreeParamActionDict = System.Collections.Generic.Dictionary<string,Com.Github.DataStructures.OrderedDictionary<string,System.Action<object,object,object>>> ;

public class HookCollection
{

		private NoParamFilterDict filters1 = new NoParamFilterDict ();
		private OneParamFilterDict filters2 = new OneParamFilterDict ();
		private TwoParamFilterDict filters3 = new TwoParamFilterDict ();
		// Actions (No return value)
		private NoParamActionDict actions = new NoParamActionDict ();
		private OneParamActionDict actions1 = new OneParamActionDict ();
		private TwoParamActionDict actions2 = new TwoParamActionDict ();
		private ThreeParamActionDict actions3 = new ThreeParamActionDict ();


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
		
				int dictPriority = GetPriority <NoParamFilterDict> (priority, filters1);
		
		
				KeyValuePair<string, Func<object, object>> data = new KeyValuePair<string, Func<object, object>> (filterTag, action);
		
		
				if (filters1.ContainsKey (filterName)) {
						if (filters1 [filterName].Count >= dictPriority) {
								filters1 [filterName].Insert (dictPriority, data);
						} else {
								filters1 [filterName].Add (data);
				
						}
				} else {
						filters1.Add (filterName, new OrderedDictionary<string,Func<object,object>> (){{filterTag,action}});
				}
				return filterTag;
		
		}

		/// <summary>
		/// Adds a filter with no additional arguments. Returns the filterTag
		/// </summary>
		/// <param name="filterName">Filter name.</param>
		/// <param name="action">Action.</param>
		/// <param name="filterTag">Filter tag.</param>
		public string AddFilter (string filterName, Func<object,object,object> action, string filterTag = null, int? priority=null)
		{
		
				if (filterTag == null) {
						filterTag = Guid.NewGuid ().ToString ();
				}
		
				int dictPriority = GetPriority <OneParamFilterDict> (priority, filters2);
				
		
				KeyValuePair<string, Func<object, object,object>> data = new KeyValuePair<string, Func<object, object,object>> (filterTag, action);
		
		
				if (filters2.ContainsKey (filterName)) {
						if (filters2 [filterName].Count >= dictPriority) {
								filters2 [filterName].Insert (dictPriority, data);
						} else {
								filters2 [filterName].Add (data);
				
						}
				} else {
						filters2.Add (filterName, new OrderedDictionary<string,Func<object,object,object>> (){{filterTag,action}});
				}
				return filterTag;
		
		}

		/// <summary>
		/// Adds a filter with no additional arguments. Returns the filterTag
		/// </summary>
		/// <param name="filterName">Filter name.</param>
		/// <param name="action">Action.</param>
		/// <param name="filterTag">Filter tag.</param>
		public string AddFilter (string filterName, Func<object,object,object,object> action, string filterTag = null, int? priority=null)
		{
		
				if (filterTag == null) {
						filterTag = Guid.NewGuid ().ToString ();
				}
		
				int dictPriority = GetPriority <TwoParamFilterDict> (priority, filters3);

		
				KeyValuePair<string, Func<object, object,object,object>> data = new KeyValuePair<string, Func<object, object,object,object>> (filterTag, action);
		
		
				if (filters3.ContainsKey (filterName)) {
						if (filters3 [filterName].Count >= dictPriority) {
								filters3 [filterName].Insert (dictPriority, data);
						} else {
								filters3 [filterName].Add (data);
				
						}
				} else {
						filters3.Add (filterName, new OrderedDictionary<string,Func<object,object,object,object>> (){{filterTag,action}});
				}
				return filterTag;
		
		}

		private int GetPriority<T> (int? priority, T collection) where T : IDictionary
		{
				if (priority != null) {
						return (int)priority;
				} else {
						return collection.Count;
			
				}
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

		/// <summary>
		/// Remove all Filters for this filterName
		/// </summary>
		/// <param name="filterName">Filter name.</param>
		public void RemoveFilter (string filterName)
		{
		
				filters1.Remove (filterName);
//		filtersArguments.Remove (filterName);
		
		}
	
		/// <summary>
		/// Remove the specified Filter by filterTag.
		/// </summary>
		/// <param name="filterName">Filter name.</param>
		/// <param name="filterTag">Filter tag.</param>
		public void RemoveFilter (string filterName, string filterTag)
		{
				if (filters1.ContainsKey (filterName)) {
			
						if (filters1 [filterName].Remove (filterTag)) {
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
		
				if (filters1.ContainsKey (filterName)) {
			
						foreach (KeyValuePair<string, Func<object,object> > action in filters1[filterName]) {
				
								source = action.Value (source);
						}
			
				} else {
						//						Debug.Log ("There were no filters added for " + filterName);
				}
		
				return source;
		}

		/// <summary>
		/// Applies a Filter with one extra argument
		/// </summary>
		/// <param name="filterName">Filter name.</param>
		/// <param name="source">Source.</param>
		public object ApplyFilters (string filterName, object source, object param1)
		{
		
				if (filters2.ContainsKey (filterName)) {
			
						foreach (KeyValuePair<string, Func<object,object,object> > action in filters2[filterName]) {
				
								source = action.Value (source, param1);
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

		/// <summary>
		/// Adds a filter with no additional arguments. Returns the filterTag
		/// </summary>
		/// <param name="filterName">Filter name.</param>
		/// <param name="action">Action.</param>
		/// <param name="filterTag">Filter tag.</param>
		public static string AddFilter (string filterName, Func<object,object,object> action, string filterTag = null, int? priority=null)
		{
		
				return hooks.AddFilter (filterName, action, filterTag, priority);
		
		}

		/// <summary>
		/// Adds a filter with no additional arguments. Returns the filterTag
		/// </summary>
		/// <param name="filterName">Filter name.</param>
		/// <param name="action">Action.</param>
		/// <param name="filterTag">Filter tag.</param>
		public static string AddFilter (string filterName, Func<object,object,object,object> action, string filterTag = null, int? priority=null)
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


