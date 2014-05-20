using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class FilterBehaviour : MonoBehaviour
{

		protected HookCollection api = new HookCollection ();

		/// <summary>
		/// Adds a filter with no additional arguments. Returns the filterTag
		/// </summary>
		/// <param name="filterName">Filter name.</param>
		/// <param name="action">Action.</param>
		/// <param name="filterTag">Filter tag.</param>
		public  string AddFilter (string filterName, Func<object,object> action, string filterTag = null, int? priority=null)
		{
		
				return api.AddFilter (filterName, action, filterTag, priority);
		
		}

		public string AddAction (string actionName, Action action, string actionTag = null, int? priority=null)
		{
				return api.AddAction (actionName, action, actionTag, priority);
		}

		public string AddAction (string actionName, Action<object> action, string actionTag = null, int? priority=null)
		{
				return api.AddAction (actionName, action, actionTag, priority);
		}
//	/// <summary>
//	/// Adds a filter with additional arguments. Returns the filterTag
//	/// </summary>
//	/// <param name="filterName">Filter name.</param>
//	/// <param name="action">Action.</param>
//	/// <param name="filterTag">Filter tag.</param>
//	public  string Add (string filterName, Func<object,object[],object> action, string filterTag = "", int? priority=null)
//	{
//		return api.Add (filterName, action, filterTag, priority);
//		
//	}
		/// <summary>
		/// Remove all Filters for this filterName
		/// </summary>
		/// <param name="filterName">Filter name.</param>
		public  void RemoveFilter (string filterName)
		{
		
				api.RemoveFilter (filterName);
		
		}
	
		/// <summary>
		/// Remove the specified Filter by filterTag.
		/// </summary>
		/// <param name="filterName">Filter name.</param>
		/// <param name="filterTag">Filter tag.</param>
		public  void RemoveFilter (string filterName, string filterTag)
		{
				api.RemoveFilter (filterName, filterTag);
		
		}
	
	
	
		/// <summary>
		/// Applies a Filter
		/// </summary>
		/// <param name="filterName">Filter name.</param>
		/// <param name="source">Source.</param>
		public  object ApplyFilters (string filterName, object source)
		{
		
		
				return api.ApplyFilters (filterName, source);
		}
	
//	/// <summary>
//	/// Applies a Filter with additional arguments
//	/// </summary>
//	/// <param name="filterName">Filter name.</param>
//	/// <param name="source">Source.</param>
//	/// <param name="arguments">Arguments.</param>
//	public  object Apply (string filterName, object source, object[] arguments)
//	{
//		
//		
//		return api.Apply (filterName, source,arguments);
//	}
}
