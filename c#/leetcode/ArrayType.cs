using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ArrayType {
    public class Solution {

        // https://leetcode.com/problems/can-place-flowers/
        public bool CanPlaceFlowers(int[] flowerbed, int n) {

            for (int i = 0; i < flowerbed.Length; i++) {
                if (flowerbed[i] == 0 &&
                    ((i - 1) < 0 || flowerbed[i - 1] == 0) &&
                    ((i + 1) == flowerbed.Length || flowerbed[i + 1] == 0)) {

                    flowerbed[i] = 1;
                    n--;
                }

            }

            return n <= 0;
        }

        public int gcd(int x, int y) {
            return x == 0 ? y : gcd(y % x, x);
        }

        // https://leetcode.com/problems/x-of-a-kind-in-a-deck-of-cards/
        public bool HasGroupsSizeX(int[] deck) {
            Dictionary<int, int> dic = new Dictionary<int, int>();

            int minCount = int.MaxValue;
            for (int i = 0; i < deck.Length; i++) {
                dic[deck[i]] = dic.GetValueOrDefault(deck[i], 0) + 1;
            }

            minCount = dic.Values.Min();

            List<int> divisors = new List<int>();
            for (int i = 2; i <= minCount; i++) {
                if (minCount % i == 0) {
                    divisors.Add(i);
                }
            }

            foreach (int d in divisors) {
                bool isDividable = true;

                foreach (int key in dic.Keys) {
                    if (dic[key] % d != 0) {
                        isDividable = false;
                    }
                }

                if (isDividable) return true;
            }

            return false;
        }

        // less code solution
        // https://leetcode.com/problems/valid-mountain-array/
        public bool ValidMountainArray(int[] A) {
            int begin = 0, end = A.Length - 1;

            while (begin < A.Length - 1 && A[begin] < A[begin + 1]) {
                begin++;
            }

            while (end > begin && A[end] < A[end - 1]) {
                end--;
            }

            return begin > 0 && begin == end && begin < A.Length - 1;
        }

        // solution with for loop, but much more code
        // https://leetcode.com/problems/valid-mountain-array/
        public bool ValidMountainArray1(int[] A) {
            if (A.Length <= 2) return false;

            int increaseIndex = 0;
            bool isIncrease = false;
            bool isIncreaseReverse = false;

            for (int i = 1; i < A.Length; i++) {
                if (A[i - 1] < A[i]) {
                    isIncrease = true;
                    increaseIndex = i;
                } else {
                    break;
                }
            }

            for (int i = A.Length - 1; i > increaseIndex; i--) {

                if (A[i] >= A[i - 1]) {
                    return false;
                } else {
                    isIncreaseReverse = true;
                }
            }

            return isIncrease && isIncreaseReverse;

        }

        // https://leetcode.com/problems/contains-duplicate-ii/
        public bool ContainsNearbyDuplicate(int[] nums, int k) {
            Dictionary<int, int> dic = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++) {

                if (dic.ContainsKey(nums[i])) {
                    int diff = i - dic[nums[i]];

                    if (diff <= k) return true;
                }

                dic[nums[i]] = i;
            }

            return false;
        }

        // https://leetcode.com/problems/maximum-average-subarray-i/
        public double FindMaxAverage(int[] nums, int k) {
            double maxAverage = int.MinValue;
            int sumOfk = 0;

            for (int i = 0; i < nums.Length; i++) {
                int beginIndex = i - k;

                if (beginIndex >= 0) {
                    sumOfk -= nums[beginIndex];
                }

                sumOfk += nums[i];

                if (i + 1 >= k) {
                    maxAverage = Math.Max(maxAverage, sumOfk * 1.0 / k);
                }

            }

            return maxAverage;
        }

        // https://leetcode.com/problems/largest-number-at-least-twice-of-others/
        public int DominantIndex(int[] nums) {
            int maxVal = int.MinValue;
            int maxIdx = -1;
            int maxVal2 = int.MinValue;

            for (int i = 0; i < nums.Length; i++) {
                if (nums[i] > maxVal) {
                    maxVal2 = maxVal;
                    maxVal = nums[i];

                    maxIdx = i;
                } else if (nums[i] > maxVal2) { // between maxVal2 and maxVal
                    maxVal2 = nums[i];
                }
            }

            return maxVal2 * 2 > maxVal ? -1 : maxIdx;
        }

        // https://leetcode.com/problems/search-insert-position/
        public int SearchInsert(int[] nums, int target) {

            for (int i = 0; i < nums.Length; i++) {
                if (nums[i] >= target) {
                    return i;
                }
            }

            return nums.Length;
        }

        // https://leetcode.com/problems/maximize-distance-to-closest-person/
        public int MaxDistToClosest(int[] seats) {
            int maxDistance = int.MinValue;
            int count = 0;

            for (int i = 0; i < seats.Length; i++) {
                if (seats[i] == 0) {
                    count++;
                } else {

                    // begins start with zero
                    if ((count - i == 0)) {
                        maxDistance = Math.Max(maxDistance, count);
                    } else {
                        int val = (count + 1) / 2;
                        maxDistance = Math.Max(val, maxDistance);
                    }

                    count = 0;
                }
            }

            return Math.Max(count, maxDistance);
        }

        // https://leetcode.com/problems/remove-duplicates-from-sorted-array/
        public int RemoveDuplicates(int[] nums) {

            if (nums.Length <= 0) return 0;

            int sr = 0;

            for (int i = 1; i < nums.Length; i++) {
                if (nums[sr] != nums[i]) {
                    nums[++sr] = nums[i];
                }
            }

            return sr + 1;
        }

        // https://leetcode.com/problems/find-pivot-index/
        public int PivotIndex(int[] nums) {
            if (nums.Length <= 1) return -1;

            int leftTotal = 0;
            int rightTotal = rightTotal = nums.Sum();;

            for (int i = 0; i < nums.Length; i++) {
                leftTotal += (i == 0) ? 0 : nums[i - 1];
                rightTotal -= nums[i];

                if (leftTotal == rightTotal) {
                    return i;
                }

            }

            return -1;
        }

        // https://leetcode.com/problems/plus-one/
        public int[] PlusOne(int[] digits) {
            Stack<int> stack = new Stack<int>();
            int i = digits.Length - 1;
            int carry = 0;
            int addVal = 1;

            while (i >= 0 || carry > 0) {
                int curr = (i >= 0 ? digits[i] : 0) + addVal + carry;
                int val = curr % 10;
                carry = curr / 10;
                addVal = 0;

                stack.Push(val);
                i--;
            }

            return stack.ToArray();
        }

        // https://leetcode.com/problems/number-of-equivalent-domino-pairs/
        public int NumEquivDominoPairs(int[][] dominoes) {
            int count = 0;
            Dictionary<int, int> dic = new Dictionary<int, int>();

            foreach (int[] dom in dominoes) {
                // normalize
                int key = Math.Min(dom[0], dom[1]) * 10 + Math.Max(dom[0], dom[1]);

                dic[key] = dic.GetValueOrDefault(key, 0) + 1;
            }

            foreach (int key in dic.Keys) {
                int occurence = dic[key];
                count += (occurence * (occurence - 1)) / 2;
            }

            return count;
        }

        // https://leetcode.com/problems/maximum-subarray/
        public int MaxSubArray(int[] nums) {
            int maxRange = int.MinValue;
            int[] sumArr = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++) {
                for (int j = 0; j <= i; j++) {
                    sumArr[j] += nums[i];

                    maxRange = Math.Max(sumArr[j], maxRange);
                }

            }

            return maxRange;
        }

        // https://leetcode.com/problems/add-to-array-form-of-integer/
        public IList<int> AddToArrayForm(int[] A, int K) {
            Stack<int> stackRes = new Stack<int>();
            Stack<int> kStack = new Stack<int>();

            while (K > 0) {
                kStack.Push(K % 10);

                K /= 10;
            }

            int[] kArr = kStack.ToArray();

            int kIt = kArr.Length - 1;
            int aIt = A.Length - 1;
            int carry = 0;

            while ((kIt >= 0 || aIt >= 0) || carry > 0) {
                int a = kIt >= 0 ? kArr[kIt] : 0;
                int b = aIt >= 0 ? A[aIt] : 0;

                int curr = a + b + carry;
                int val = curr % 10;
                carry = curr / 10;

                stackRes.Push(val);

                kIt--;
                aIt--;
            }

            return stackRes.ToList();
        }

        // https://leetcode.com/problems/longest-continuous-increasing-subsequence/
        public int FindLengthOfLCIS(int[] nums) {
            if (nums.Length <= 1) return nums.Length;

            int longest = int.MinValue;
            int count = 0;

            for (int i = 0; i < nums.Length - 1; i++) {
                count++;

                if (nums[i] >= nums[i + 1]) {
                    longest = Math.Max(longest, count);
                    count = 0;
                }

            }

            if (nums[nums.Length - 1] > nums[nums.Length - 2]) {
                count++;
                longest = Math.Max(longest, count);
            }

            return longest;
        }

        // https://leetcode.com/problems/pascals-triangle-ii/
        public IList<int> GetRow(int rowIndex) {

            IList<int> row = new List<int>();

            for (int r = 0; r < rowIndex + 1; r++) {

                for (int col = r - 1; col > 0; col--) {
                    int leftParent = row[col - 1];
                    int rightParent = row[col];

                    row[col] = leftParent + rightParent;
                }

                row.Add(1);

            }

            return row;
        }

        // https://leetcode.com/problems/pascals-triangle/
        public IList<IList<int>> Generate(int numRows) {
            List<IList<int>> res = new List<IList<int>>();
            IList<int> parentRow = new List<int>(new int[] { 1 });

            for (int i = 0; i < numRows; i++) {
                IList<int> row = new List<int>();

                for (int j = 0; j < i + 1; j++) {
                    int leftParent = parentRow.ElementAtOrDefault(j - 1);
                    int rightParent = parentRow.ElementAtOrDefault(j);

                    row.Add(leftParent + rightParent);
                }

                res.Add(row);
                parentRow = row;
            }

            return res;
        }

        // less code 
        // https://leetcode.com/problems/remove-element/
        public int RemoveElement(int[] nums, int val) {
            int i = 0, end = nums.Length;

            while (i < end) {
                if (nums[i] == val) {
                    nums[i] = nums[end - 1];
                    end--;
                } else {
                    i++;
                }
            }

            return end;
        }
        // https://leetcode.com/problems/remove-element/
        public int RemoveElement1(int[] nums, int val) {

            if (nums.Length <= 0) return 0;

            int startIdx = 0, endIdx = nums.Length - 1;

            for (int i = nums.Length - 1; i >= 0; i--) {
                if (nums[i] != val) {
                    endIdx = i;
                    break;
                }
            }

            while (startIdx < endIdx) {
                if (nums[startIdx] == val) {
                    int temp = nums[startIdx];
                    nums[startIdx] = nums[endIdx];
                    nums[endIdx] = temp;
                    endIdx--;

                    while (endIdx > startIdx && nums[endIdx] == val) {
                        endIdx--;
                    }
                }

                startIdx++;
            }

            int length = nums.Length;

            for (int i = 0; i < nums.Length; i++) {
                if (nums[i] == val) {
                    length = i;
                    break;
                }
            }

            return length;
        }

        // https://leetcode.com/problems/pairs-of-songs-with-total-durations-divisible-by-60/
        public int NumPairsDivisibleBy60(int[] time) {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            int count = 0;

            for (int i = 0; i < time.Length; i++) {
                int a = time[i] % 60;
                int b = (60 - a) % 60; // (a + b)%60 = 0
                count += dic.GetValueOrDefault(b, 0);

                dic[a] = dic.GetValueOrDefault(a, 0) + 1;
            }

            return count;
        }

        // https://leetcode.com/problems/pairs-of-songs-with-total-durations-divisible-by-60/
        public int NumPairsDivisibleBy60_1(int[] time) {
            int count = 0;

            for (int i = 0; i < time.Length; i++) {
                for (int j = i + 1; j < time.Length; j++) {
                    if ((time[i] + time[j]) % 60 == 0) {
                        count++;
                    }
                }
            }

            return count;
        }

        // https://leetcode.com/problems/maximum-product-of-three-numbers/
        public int MaximumProduct(int[] nums) {
            if (nums.Length < 3) return 0;

            Array.Sort(nums);

            int first = nums[0] * nums[1] * nums[nums.Length - 1];

            int length = nums.Length;
            int result = nums[nums.Length - 1];

            for (int i = nums.Length - 2; i >= length - 3; i--) {
                result *= nums[i];
            }

            return Math.Max(first, result);
        }

        // https://leetcode.com/problems/binary-prefix-divisible-by-5/
        public IList<bool> PrefixesDivBy5(int[] A) {
            Stack<bool> stack = new Stack<bool>();

            BigInteger x = 1;
            BigInteger accum = 0;

            for (int i = A.Length - 1; i >= 0; i--) {
                int currBit = A[i];
                int val = i == A.Length - 1 ? 1 : 2;
                x *= val;
                accum += currBit * x;
            }

            stack.Push(accum % 5 == 0);
            x = 1;

            for (int i = A.Length - 1; i > 0; i--) {
                int currBit = A[i];
                int val = i == A.Length - 1 ? 1 : 2;
                x *= val;

                accum -= currBit * x;

                bool isDivisible = accum % 5 == 0;

                stack.Push(isDivisible);
            }

            return stack.ToList();
        }

        // https://leetcode.com/problems/min-cost-climbing-stairs/
        // [1, 100, 1, 1, 1, 100, 1, 1, 100, 1]
        public int MinCostClimbingStairs(int[] cost) {

            Dictionary<int, int> dic = new Dictionary<int, int>();
            int a = calcMinCost(0, cost, dic);
            int b = calcMinCost(1, cost, dic);

            return Math.Min(a, b);
        }

        public int calcMinCost(int idx, int[] cost, Dictionary<int, int> dic) {
            if (dic.ContainsKey(idx)) {
                return dic[idx];
            }

            if (idx + 2 > cost.Length - 1) {
                dic[idx] = cost[idx];
                return cost[idx];
            }
            int costForCurr = cost[idx] + Math.Min(calcMinCost(idx + 1, cost, dic), calcMinCost(idx + 2, cost, dic));
            dic[idx] = costForCurr;

            return dic[idx];
        }

        // https://leetcode.com/problems/positions-of-large-groups/
        public IList<IList<int>> LargeGroupPositions(string S) {
            IList<IList<int>> listOfList = new List<IList<int>>();
            int count = 0, begin = 0;

            for (int i = 0; i < S.Length; i++) {
                var list = new List<int>();

                if (i != S.Length - 1 && S[i] == S[i + 1]) {
                    count++;
                } else {
                    if (count >= 2) {
                        // add to list
                        list.Add(begin);
                        list.Add(i);

                        listOfList.Add(list);
                    }

                    count = 0;
                    begin = i + 1;
                }
            }

            return listOfList;
        }

        // with bit manipulation
        // https://leetcode.com/problems/find-the-difference/
        public char FindTheDifference(string s, string t) {
            int result = 0;

            for (int i = 0; i < s.Length; i++) {
                result ^= s[i] ^ t[i];
            }

            char lastLetter = t[t.Length - 1];
            result ^= lastLetter;

            return Convert.ToChar(result);
        }

        // with HashTable
        // https://leetcode.com/problems/find-the-difference/
        public char FindTheDifference1(string s, string t) {
            Dictionary<char, int> dic = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++) {
                dic[s[i]] = dic.GetValueOrDefault(s[i], 0) + 1;
            }

            for (int i = 0; i < t.Length; i++) {
                dic[t[i]] = dic.GetValueOrDefault(t[i], 0) - 1;
            }

            foreach (char key in dic.Keys) {
                if (dic[key] == -1) return key;
            }

            return 'a';
        }

        // https://leetcode.com/problems/single-number/
        public int SingleNumber(int[] nums) {
            int res = 0;
            for (int i = 0; i < nums.Length; i++) {
                res = res ^ nums[i];
            }

            return res;
        }

        // https://leetcode.com/problems/missing-number/
        public int MissingNumber(int[] nums) {
            int length = nums.Length;
            int sum = 0;
            int numsSum = nums.Sum();

            for (int i = 0; i <= length; i++) {
                sum += i;
            }

            return sum - numsSum;
        }

        // https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/
        public int[] TwoSum(int[] numbers, int target) {

            Dictionary<int, int> dic = new Dictionary<int, int>();
            int[] result = new int[2];

            for (int i = 0; i < numbers.Length; i++) {
                int c = target - numbers[i];

                if (dic.ContainsKey(c)) {
                    int idx = dic[c];
                    result[0] = (idx + 1);
                    result[1] = (i + 1);
                    break;
                }

                dic[numbers[i]] = i;
            }

            return result;
        }

        // https://leetcode.com/problems/degree-of-an-array/
        public int FindShortestSubArray(int[] nums) {
            List<int> mostCommons = new List<int>();
            Dictionary<int, int> dic = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++) {
                int curr = nums[i];
                dic[curr] = dic.GetValueOrDefault(curr, 0) + 1;
            }

            int maxQuantity = dic.Values.Max();
            foreach (int key in dic.Keys) {
                if (dic[key] == maxQuantity) {
                    mostCommons.Add(key);
                }
            }

            int minLength = int.MaxValue;
            foreach (int mostCommon in mostCommons) {
                for (int i = 0, j = nums.Length - 1; i <= j;) {
                    if (nums[i] != mostCommon) i++;
                    if (nums[j] != mostCommon) j--;

                    if (nums[i] == nums[j] && nums[i] == mostCommon) {
                        minLength = Math.Min(((j - i) + 1), minLength);
                        break;
                    }
                }
            }

            return minLength;
        }

        // https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/
        public int MaxProfit(int[] prices) {
            int profit = 0, minVal = int.MaxValue, maxVal = int.MinValue;

            for (int i = 0; i < prices.Length; i++) {
                int curr = prices[i];

                if (curr < maxVal) {
                    profit += maxVal - minVal;

                    minVal = curr;
                    maxVal = int.MinValue;

                    continue;
                }

                if (curr < minVal) {
                    minVal = curr;

                } else if (curr > maxVal) {
                    maxVal = curr;
                }

                // last element
                if ((prices.Length - 1 == i && maxVal != int.MinValue)) {
                    profit += maxVal - minVal;
                }

            }

            return profit;
        }

        // https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
        public int MaxProfit1_2(int[] prices) {

            if (prices.Length <= 1) return 0;

            int minVal = int.MaxValue;
            int maxVal = prices.Length - 1;
            int end = prices.Length - 1;

            for (int i = 0; i < end; i++) {
                int curr = prices[i];
                minVal = Math.Min(curr, minVal);
                maxVal = prices[end];

                while (
                    curr > maxVal &&
                    (maxVal - minVal < curr - minVal) &&
                    curr != minVal
                ) {
                    maxVal = prices[--end];
                }
            }

            int profit1 = maxVal - minVal;

            maxVal = int.MinValue;
            int begin = 0;

            for (int j = prices.Length - 1; j >= begin; j--) {
                int curr = prices[j];
                minVal = prices[begin];
                maxVal = Math.Max(curr, maxVal);

                while (
                    curr < minVal &&
                    (maxVal - minVal < maxVal - curr)
                ) {
                    minVal = prices[++begin];
                }
            }

            int profit2 = maxVal - minVal;

            return Math.Max(profit1, profit2);
        }

        // https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
        public int MaxProfit1_1(int[] prices) {
            int profit = int.MinValue;

            for (int i = 0; i < prices.Length; i++) {
                for (int j = i + 1; j < prices.Length; j++) {
                    profit = Math.Max(prices[j] - prices[i], profit);
                }
            }

            return profit > 0 ? profit : 0;
        }

        // https://leetcode.com/problems/majority-element/
        public int MajorityElement(int[] nums) {

            int limit = nums.Length / 2;

            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++) {
                dic[nums[i]] = dic.GetValueOrDefault(nums[i], 0) + 1;

                if (dic[nums[i]] > limit) return nums[i];
            }

            return -1;
        }

        // https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/
        // no extra space, Time: O(N)
        //  [4, 3, 2, 7, 8, 2, 3, 1]
        public IList<int> FindDisappearedNumbers(int[] nums) {
            List<int> result = new List<int>();
            int length = nums.Length;

            for (int i = 0; i < nums.Length; i++) {
                int refIdx = length - Math.Abs(nums[i]);

                if (nums[refIdx] > 0) {
                    nums[refIdx] = nums[refIdx] * (-1);
                }
            }

            for (int i = 0; i < nums.Length; i++) {
                if (nums[i] >= 0) {
                    int missingVal = length - i;
                    result.Add(missingVal);
                }
            }

            return result;
        }

        // https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/
        // with extra space: O(N)
        public IList<int> FindDisappearedNumbers1(int[] nums) {
            List<int> result = new List<int>();

            HashSet<int> set = new HashSet<int>();

            for (int i = 0; i < nums.Length; i++) {
                set.Add(nums[i]);
            }

            for (int i = 1; i <= nums.Length; i++) {
                if (!set.Contains(i)) result.Add(i);
            }

            return result;
        }

        // https://leetcode.com/problems/move-zeroes/
        // Input: [0,1,0,3,12]
        // Output: [1,3,12,0,0]
        public void MoveZeroes(int[] nums) {
            int it = -1;

            for (int i = 0; i < nums.Length; i++) {
                if (nums[i] == 0) {
                    it = i;
                    break;
                }
            }

            if (it < 0) return;

            for (int i = it + 1; i < nums.Length; i++) {
                if (nums[i] != 0) {
                    nums[it] = nums[i];
                    nums[i] = 0;
                    it++;
                }
            }
        }

        // https://leetcode.com/problems/max-consecutive-ones/
        public int FindMaxConsecutiveOnes(int[] nums) {
            int count = 0;
            int max = -1;

            for (int i = 0; i < nums.Length; i++) {

                if (nums[i] == 1) {
                    count++;
                } else {
                    max = Math.Max(max, count);
                    count = 0;
                }
            }

            return Math.Max(count, max);
        }

        // https://leetcode.com/problems/partition-array-into-three-parts-with-equal-sum/
        // [0,2,1,-6,6,-7,9,1,2,0,1]
        public bool CanThreePartsEqualSum(int[] A) {
            int sum = 0;
            Array.ForEach(A, itm => sum += itm);

            if (sum % 3 != 0) return false;

            sum /= 3;

            int part = 0, count = 0;
            for (int i = 0; i < A.Length; i++) {
                part += A[i];

                if (part == sum) {
                    count++;
                    part = 0;
                }
            }

            return count == 3;
        }

        // Space Complexity: O(1), Time: O(N^2)
        // https://leetcode.com/problems/duplicate-zeros/
        public void DuplicateZeros(int[] arr) {
            for (int i = 0; i < arr.Length; i++) {
                if (arr[i] == 0) {
                    for (int j = arr.Length - 1; j >= 1 && j != i; j--) {
                        arr[j] = arr[j - 1];
                    }

                    i++;
                }
            }
        }
        // one pass, clear way
        // https://leetcode.com/problems/monotonic-array/
        public bool IsMonotonic(int[] A) {
            bool isIncreasing = true;
            bool isDecreasing = true;

            for (int i = 0; i < A.Length - 1; i++) {
                if (A[i] > A[i + 1]) isIncreasing = false;
                if (A[i] < A[i + 1]) isDecreasing = false;
            }

            return isIncreasing || isDecreasing;
        }

        // one pass
        // https://leetcode.com/problems/monotonic-array/
        public bool IsMonotonic2(int[] A) {
            bool shouldIncrease = true;
            bool isTheSame = true;

            for (int i = 0; i < A.Length - 1; i++) {
                if (isTheSame && A[i] != A[i + 1]) {
                    isTheSame = false;
                    shouldIncrease = A[i] < A[i + 1];
                }

                if (!isTheSame && !shouldIncrease && A[i] < A[i + 1]) {
                    return false;
                }

                if (!isTheSame && shouldIncrease && A[i] > A[i + 1]) {
                    return false;
                }
            }

            return true;
        }

        //  two pass
        // https://leetcode.com/problems/monotonic-array/
        public bool IsMonotonic1(int[] A) {
            bool isIncrease = true;

            for (int i = 0; i < A.Length - 1; i++) {
                if (A[i] > A[i + 1]) {
                    isIncrease = false;
                    break;
                }
            }

            if (!isIncrease) {
                // should decrease
                for (int i = 0; i < A.Length - 1; i++) {
                    if (A[i] < A[i + 1]) return false;
                }
            }

            return true;
        }

        // https://leetcode.com/problems/fair-candy-swap/
        public int[] FairCandySwap(int[] A, int[] B) {
            int aSum = 0, bSum = 0, delta = 0;
            int[] ans = new int[2];

            aSum = A.Sum();
            bSum = B.Sum();
            delta = (bSum - aSum) / 2;

            HashSet<int> setB = new HashSet<int>();
            Array.ForEach(B, val => setB.Add(val));

            foreach (int a in A) {
                if (setB.Contains(a + delta)) {
                    return new int[] { a, a + delta };
                }
            }

            return ans;
        }

        // https://leetcode.com/problems/fair-candy-swap/
        public int[] FairCandySwap1(int[] A, int[] B) {
            int aSum = 0, bSum = 0, avg = 0;
            int[] ans = new int[2];

            aSum = A.Sum();
            bSum = B.Sum();
            avg = (aSum + bSum) / 2;

            for (int i = 0; i < A.Length; i++) {
                aSum -= A[i];
                for (int j = 0; j < B.Length; j++) {
                    aSum += B[j];

                    if (aSum == avg) {
                        ans[0] = A[i];
                        ans[1] = B[j];

                        return ans;
                    }

                    aSum -= B[j];
                }

                aSum += A[i];
            }

            return ans;
        }

        // https://leetcode.com/problems/reshape-the-matrix/
        public int[][] MatrixReshape(int[][] nums, int r, int c) {
            int R = nums.Length, C = nums[0].Length, count = 0;
            if (R * C != r * c) return nums;

            int[][] ans = new int[r][];

            for (int i = 0; i < r; i++) {
                ans[i] = new int[c];
            }

            for (int i = 0; i < nums.Length; i++) {
                for (int j = 0; j < nums[0].Length; j++) {
                    ans[count / c][count % c] = nums[i][j];
                    count++;
                }
            }

            return ans;
        }

        // https://leetcode.com/problems/reshape-the-matrix/
        public int[][] MatrixReshape1(int[][] nums, int r, int c) {
            int R = nums.Length, C = nums[0].Length;
            if (R * C != r * c) return nums;

            int[][] ans = new int[r][];

            int rIt = 0, cIt = 0;

            for (int i = 0; i < r; i++) {
                ans[i] = new int[c];

                for (int j = 0; j < c; j++) {
                    ans[i][j] = nums[rIt][cIt];
                    cIt++;

                    if (cIt == C) {
                        cIt = 0;
                        rIt++;
                    }
                }
            }

            return ans;
        }

        // https://leetcode.com/problems/toeplitz-matrix/
        public bool IsToeplitzMatrix(int[][] matrix) {
            for (int r = 0; r < matrix.Length - 1; r++) {
                int[] row = matrix[r];

                for (int c = 0; c < row.Length - 1; c++) {
                    if (matrix[r][c] != matrix[r + 1][c + 1]) return false;
                }
            }

            return true;
        }

        // Time limit:  O(A.length) + O(queryes.length)) 
        // https://leetcode.com/problems/sum-of-even-numbers-after-queries/
        public int[] SumEvenAfterQueries(int[] A, int[][] queries) {
            int[] ans = new int[queries.Length];
            int evens = A.Sum(val => val % 2 == 0 ? val : 0);

            for (int r = 0; r < queries.Length; r++) {
                int[] queryRow = queries[r];
                int index = queryRow[1], val = queryRow[0];

                if (A[index] % 2 == 0) {
                    int rem = evens - A[index];
                    A[index] += val;

                    evens = A[index] % 2 == 0 ? rem + A[index] : rem;
                } else {
                    // odd becomes even
                    A[index] += val;
                    if (A[index] % 2 == 0) evens += A[index];
                }

                ans[r] = evens;
            }

            return ans;
        }

        // https://leetcode.com/problems/transpose-matrix/
        public int[][] Transpose(int[][] A) {
            int C = A[0].Length, R = A.Length;
            int[][] result = new int[C][];

            for (int c = 0; c < C; c++) {
                result[c] = new int[R];

                for (int r = 0; r < R; r++) {
                    result[c][r] = A[r][c];
                }
            }

            return result;
        }

        // https://leetcode.com/problems/find-common-characters/
        public IList<string> CommonChars(string[] A) {
            List<string> commonList = new List<string>();
            if (A.Length == 0) return commonList;

            int[] count = new int[26];
            Array.Fill(count, int.MaxValue);

            for (int i = 0; i < A.Length; i++) {
                int[] currArr = new int[26];
                string word = A[i];

                for (int j = 0; j < word.Length; j++) {
                    currArr[word[j] - 'a']++;
                }

                for (int j = 0; j < 26; j++) {
                    count[j] = Math.Min(count[j], currArr[j]);
                }
            }

            for (char c = 'a'; c <= 'z'; c++) {
                while (count[c - 'a'] > 0) {
                    commonList.Add(c + "");
                    count[c - 'a']--;
                }
            }

            return commonList;
        }

        // https://leetcode.com/problems/find-common-characters/
        public IList<string> CommonChars1(string[] A) {
            List<string> commonList = new List<string>();
            if (A.Length == 0) return commonList;

            Dictionary<char, int> mainDic = new Dictionary<char, int>();

            for (int i = 0; i < A[0].Length; i++) {
                string firstWord = A[0];
                mainDic[firstWord[i]] = mainDic.GetValueOrDefault(firstWord[i], 0) + 1;
            }

            for (int i = 1; i < A.Length; i++) {
                Dictionary<char, int> wordDic = new Dictionary<char, int>();
                string word = A[i];

                for (int j = 0; j < word.Length; j++) {
                    wordDic[word[j]] = wordDic.GetValueOrDefault(word[j], 0) + 1;
                }

                for (int j = 0; j < mainDic.Keys.Count; j++) {
                    char letterKey = mainDic.Keys.ElementAt(j);
                    mainDic[letterKey] = Math.Min(mainDic[letterKey], wordDic.GetValueOrDefault(letterKey, 0));
                }

            }

            foreach (var letterKey in mainDic.Keys) {
                for (int i = 0; i < mainDic[letterKey]; i++) {
                    commonList.Add(letterKey.ToString());
                }
            }

            return commonList;
        }

        // https://leetcode.com/problems/fibonacci-number/
        public int Fib(int N) {
            if (N == 0) return 0;
            if (N == 1) return 1;

            return Fib(N - 1) + Fib(N - 2);
        }

        // in place
        // https://leetcode.com/problems/sort-array-by-parity-ii/
        public int[] SortArrayByParityII(int[] A) {
            for (int i = 0, it = 0; i < A.Length && it < A.Length;) {
                if (it % 2 == A[i] % 2) {
                    if (it != i) {
                        int temp = A[it];
                        A[it] = A[i];
                        A[i] = temp;

                        i = it;
                    }

                    it++;
                    i++;
                }

                i++;
            }

            return A;
        }
        // https://leetcode.com/problems/sort-array-by-parity-ii/
        public int[] SortArrayByParityII1(int[] A) {
            int[] result = new int[A.Length];
            int[] tempArr = new int[A.Length];
            int tempIt = 0;

            for (int i = 0; i < A.Length; i++) {
                if (A[i] % 2 == 0) {
                    tempArr[tempIt++] = A[i];
                }
            }

            for (int i = 0; i < A.Length; i++) {
                if (A[i] % 2 == 1) {
                    tempArr[tempIt++] = A[i];
                }
            }

            int evenIt = 0;
            int oddIt = tempArr.Length / 2;

            for (int i = 0; i < result.Length; i++) {
                if (i % 2 == 0) {
                    result[i] = tempArr[evenIt++];
                } else {
                    result[i] = tempArr[oddIt++];
                }
            }

            return result;
        }

        // https://leetcode.com/problems/squares-of-a-sorted-array/
        public int[] SortedSquares(int[] A) {
            for (int i = 0; i < A.Length; i++) {
                A[i] = A[i] * A[i];
            }

            Array.Sort(A);

            return A;
        }
        // https://leetcode.com/problems/sort-array-by-parity/
        public int[] SortArrayByParity(int[] A) {
            int i = 0, j = A.Length - 1;
            while (i < j) {
                if (A[i] % 2 > A[j] % 2) {
                    int temp = A[i];
                    A[i] = A[j];
                    A[j] = temp;
                }

                if (A[i] % 2 == 0) i++;
                if (A[j] % 2 == 1) j--;
            }

            return A;

        }

        // https://leetcode.com/problems/sort-array-by-parity/
        public int[] SortArrayByParity1(int[] A) {
            for (int i = 0; i < A.Length; i++) {
                if (A[i] % 2 == 0) continue;

                for (int j = i + 1; j < A.Length; j++) {
                    if (A[j] % 2 == 0) {
                        int temp = A[i];
                        A[i] = A[j];
                        A[j] = temp;

                        break;
                    }
                }
            }

            return A;
        }

        // https://leetcode.com/problems/flipping-an-image/
        public int[][] FlipAndInvertImage(int[][] A) {
            for (int i = 0; i < A.Length; i++) {
                int[] row = A[i];
                for (int j = 0; j < (row.Length + 1) / 2; j++) {
                    int temp = row[j] ^ 1;
                    row[j] = row[row.Length - 1 - j] ^ 1;
                    row[row.Length - 1 - j] = temp;
                }
            }

            return A;
        }
    }
}