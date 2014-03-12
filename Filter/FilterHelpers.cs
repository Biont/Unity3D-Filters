using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class FilterExtensions
{

		public static IEnumerable<T> Each<T> (this IEnumerable<T> Container, System.Action<T> func)
		{
				foreach (T Element in Container) {
						func (Element);
				}
				return Container;
		}


//		public static IEnumerable<T> Each<I,T> (this IEnumerable<I> source, System.Func<I,T> func)
//		{
//				Debug.Log ("Gehe ...");
//		
//				foreach (I item in source) {
//						Debug.Log ("Gehe durch...");
//						yield return func (item);
//				}
//		}


}

public class Args : Dictionary<string, object>
{
		public void MergeWith (Args newArgs)
		{
				foreach (KeyValuePair<string,object> item in newArgs) {
						this [item.Key] = item.Value;
				}
		}
}
