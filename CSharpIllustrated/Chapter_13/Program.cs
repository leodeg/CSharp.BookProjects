using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_13
{
	static class Program
	{
		static void Main (string[] args)
		{
			TestArrayReturnRef ();
		}

		static void ArrayInitialization ()
		{
			int[] arr1 = new int[] { 10, 20, 30, 40 };
			int[] arr2 = { 20, 30, 40 };

			int[,] arr3 = new int[,] { { 10, 20 }, { 30, 40 }, { 50, 60 } };
			int[,] arr4 = { { 10, 20 }, { 30, 40 }, { 50, 60 } };

			string[] sArr = new string[] { "hello", "you", "are", "the", "best" };
			var sArr2 = new[] { "hello", "you", "are", "the", "best" };
			//var sArr3 = { "hello", "you", "are", "the", "best" }; // ERROR

			int[,,] mArr = new int[3, 2, 2]
			{
				{{9,1}, {2,1} },
				{{9,2}, {2,2} },
				{{9,3}, {2,3} }
			};

			int[,,] mArr2 =
			{
				{{9,1}, {2,1} },
				{{9,2}, {2,2} },
				{{9,3}, {2,3} }
			};

			var mArr3 = new[, ,]
			{
				{{9,1}, {2,1} },
				{{9,2}, {2,2} },
				{{9,3}, {2,3} }
			};
		}

		static void UseTwoDimensionArray ()
		{
			var arr_2 = new int[,] { { 0, 1, 2 }, { 10, 11, 12 } };

			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					Console.WriteLine ($"Element [{i}, {j}] is {arr_2[i, j]}");
				}
			}
		}

		static void UseThreeDimensionArray ()
		{
			var arr_3 = new int[,,]
			{
				{{ 1,2,3 }, { 4,5,6 }},
				{{ 7,8, 9 }, { 10,11,12 }},
				{{ 13,14,15 }, { 16,17,18 }}
			};

			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 2; j++)
				{
					for (int k = 0; k < 3; k++)
					{
						Console.WriteLine ($"Elements [{i}][{j},{k}] is {arr_3[i, j, k]}");
					}
					Console.WriteLine ();
				}
			}
		}

		static void JaggedArray ()
		{
			int total = 0;

			int[][] arr = new int[2][];
			arr[0] = new int[] { 10, 11 };
			arr[1] = new int[] { 12, 13, 14 };

			foreach (int[] array in arr)
			{
				Console.WriteLine ("Starting new array:");
				foreach (int item in array)
				{
					total += item;
					Console.WriteLine ($"Item: {item}, Current Total: {total}");
				}
			}
		}

		static void ArrayCovariance ()
		{
			A[] aArr = new A[3];
			A[] aArr2 = new A[3];

			// Normal
			aArr[0] = new A ();
			aArr[1] = new A ();
			aArr[2] = new A ();

			// Covariant
			aArr2[0] = new B ();
			aArr2[1] = new B ();
			aArr2[2] = new B ();
		}

		static void CloneArray ()
		{
			int[] Arr1 = { 1, 2, 3 };
			int[] Arr2 = (int[]) Arr1.Clone ();

			foreach (var item in Arr2)
			{
				Console.WriteLine (item.ToString());
			}

			Arr2[0] = 100;
			Arr2[1] = 200;
			Arr2[2] = 300;

			foreach (var item in Arr2)
			{
				Console.WriteLine (item.ToString ());
			}
		}

		static void CloningAReference()
		{
			CloneReference[] tempArr = { new CloneReference (), new CloneReference (), new CloneReference () };
			CloneReference[] cloneReferenceArr = tempArr.Clone () as CloneReference[];

			if (cloneReferenceArr != null)
			{
				Console.WriteLine ("Before changing a value:");
				Console.WriteLine ("Temp array");
				foreach (var item in tempArr)
				{
					Console.WriteLine (item.value);
				}
				Console.WriteLine ("Clone reference array");
				foreach (var item in cloneReferenceArr)
				{
					Console.WriteLine (item.value);
				}

				cloneReferenceArr[0].value = 240;
				cloneReferenceArr[1].value = 350;
				cloneReferenceArr[2].value = 460;

				Console.WriteLine ("\n\nAfter changing a value:");
				Console.WriteLine ("Temp array");
				foreach (var item in tempArr)
				{
					Console.WriteLine (item.value);
				}
				Console.WriteLine ("Clone reference array");
				foreach (var item in cloneReferenceArr)
				{
					Console.WriteLine (item.value);
				}
			}
		}

		static void TestArrayReturnRef()
		{
			int[] scores = { 5, 80 };

			Console.WriteLine ($"Before: {scores[0]}, {scores[1]}");

			// Get reference to a highest value in the array
			ref int locationOfHigher = ref PointerToHighestPosValue (scores);
			// Change the value to zero
			locationOfHigher = 0;

			Console.WriteLine ($"After: {scores[0]}, {scores[1]}");
		}

		static ref int PointerToHighestPosValue(int[] numbers)
		{
			int highest = 0;
			int indexOfHeighest = 0;

			for (int i = 0; i < numbers.Length; i++)
			{
				if (numbers[i] > highest)
				{
					indexOfHeighest = i;
					highest = numbers[indexOfHeighest];
				}
			}

			return ref numbers[indexOfHeighest];
		}
	}

	class A { }
	class B : A { }

	public class CloneReference
	{
		public int value = 5;
	}
}
