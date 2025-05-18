using Chapter_StringAndArray.CustomAttributes;
using Chapter_StringAndArray.Interface;
using System;

namespace Chapter_StringAndArray.Algorithms
{
	[Test(10000, false)]
	public class MergeSortedArray : IAlgorithm
	{
		//leetcodeUrl: https://leetcode.cn/problems/merge-sorted-array/?envType=study-plan-v2&envId=top-interview-150

		public void Merge(int[] nums1, int m, int[] nums2, int n)
		{
			int index1 = m - 1;
			int index2 = n - 1;
			int lastIndex = m + n - 1;
			while (index1 >= 0 || index2 >= 0)
			{
				if (index1 == -1)
				{
					nums1[lastIndex] = nums2[index2--];	
				}
				else if (index2 == -1)
				{
					nums1[lastIndex] = nums1[index1--];
				}
				else if (nums1[index1] > nums2[index2])
				{
					nums1[lastIndex] = nums1[index1--];
				}
				else
				{
					nums1[lastIndex] = nums2[index2--];
				}
				lastIndex--;
			}
		}

		public void ShowResult()
		{
			var nums1 = new int[] { 1, 2, 3, 0, 0, 0 };
			int m = 3;
			var nums2 = new int[] { 2, 5, 6 };
			var n = 3;
			Merge(nums1, m, nums2, n);
			Console.WriteLine(String.Join(',', nums1));
		}

	}
}
