// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using System.Collections.Generic;
using UnityEngine;

namespace Komutils.Typewriter
{
	[CreateAssetMenu(fileName = "NewTypewriterData", menuName = "Komutils/Typewriter/TypewriterSO")]
	public class TypewriterSO : ScriptableObject
	{
		public readonly List<TypewriterString> TsList = new List<TypewriterString>();
	}
}