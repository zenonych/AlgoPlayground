﻿using Algos.Code.Sort;
using Algos.Code.Tests.Extensions;
using System;
using System.Linq;
using Xunit;

namespace Algos.Code.Tests.Sort
{
    public class MergeSortTests
    {
        [Fact]
        public void Should_Return_Sorted_Array()
        {
            Random r = new Random();
            int[] input = r.GenerateIntArray(123).ToArray();

            MergeSort sort = new MergeSort();
            int[] output = sort.Sort(input);

            Assert.True(output.IsSorted());
        }


        [Fact]
        public void Should_Be_Faster_Than_Shell()
        {
            Random r = new Random();
            int[] inputInsertions = r.GenerateIntArray(7000).ToArray();
            int[] inputShell = (int[])inputInsertions.Clone();

            ShellSort shell = new ShellSort();
            var actualShell = shell.Sort(inputShell);

            MergeSort merge = new MergeSort();
            var actualMerge = merge.Sort(inputInsertions);

            Assert.True(actualShell.IsSorted());
            Assert.True(actualMerge.IsSorted());

            Assert.True(shell.Counter > merge.Counter);
        }
    }
}
