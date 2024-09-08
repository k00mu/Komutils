// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Komutils.Typewriter
{
	[Serializable]
	public class TypewriterString
	{
		private int charIndex;
		
		private float timer;
		private float timePerChar = 0.05f;

		private string fullString;
		private string displayString;
		
		public Action OnFinishedCallback;
		
		public string FullString
		{
			get
			{
				OnFinishedCallback?.Invoke();
				return fullString;
			}
		}
		public string DisplayString => displayString;



		public TypewriterString(string stringToWrite, Action onFinishedCallback = null)
		{
			fullString = stringToWrite;
			OnFinishedCallback = onFinishedCallback;
		}
		
		
		public void Tick()
		{
			if (string.IsNullOrEmpty(fullString))
				return;
			
			timer -= Time.deltaTime;
			if (timer <= 0)
			{
				timer += timePerChar;
				charIndex++;

				displayString = fullString.Substring(0, charIndex);

				if (charIndex >= fullString.Length)
				{
					OnFinishedCallback?.Invoke();
					fullString = "";
				}
			}
		}
		
		
		public bool IsActive()
		{
			if (string.IsNullOrEmpty(fullString))
				return false;
			
			return charIndex < fullString.Length;
		}
	}
	
	public class Typewriter : MonoBehaviourSingleton<Typewriter>
	{
		public TextMeshProUGUI textMP;
		
		private List<TypewriterString> tsList = new List<TypewriterString>();

		private int tsIndex;
		
		private TypewriterString currentTS;


		public static void Add(string stringToWrite, Action callback = null)
		{
			TypewriterString newTypewriterString = new TypewriterString(stringToWrite, callback);
			Instance.tsList.Add(newTypewriterString);
		}

		public static void Add(TypewriterSO typewriterSO)
		{
			foreach (TypewriterString ts in typewriterSO.TsList)
			{
				TypewriterString newTypewriterString = new TypewriterString(ts.FullString);
				Instance.tsList.Add(newTypewriterString);
			}
		}


		public static void Activate()
		{
			Instance.currentTS = Instance.tsList[0];
		}


		private void Update()
		{
			if (tsList.Count <= 0 || currentTS == null)
				return;
			currentTS.Tick();
			textMP.text = currentTS.DisplayString;
		}
		
		public void WriteNextStringInQueue()
		{
			if (currentTS != null && currentTS.IsActive())
			{
				textMP.text = currentTS.FullString;
				currentTS = null;
				return;
			}

			tsIndex++;

			if (tsIndex >= tsList.Count)
			{
				currentTS = null;
				textMP.text = "";
				return;
			}
			
			currentTS = tsList[tsIndex];
		}
	}
}