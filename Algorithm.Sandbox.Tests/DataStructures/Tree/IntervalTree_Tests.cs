﻿using Algorithm.Sandbox.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace Algorithm.Sandbox.Tests.DataStructures.Tree
{
    [TestClass]
    public class IntervalTree_Tests
    {
        /// </summary>
        [TestMethod]
        public void IntervalTree_Smoke_Test()
        {
            var intTree = new AsIntervalTree<int>();

            intTree.Insert(new AsInterval<int>(1, 2));
            intTree.Insert(new AsInterval<int>(2, 3));
            intTree.Insert(new AsInterval<int>(3, 4));
            intTree.Insert(new AsInterval<int>(4, 5));
            intTree.Insert(new AsInterval<int>(5, 6));
            intTree.Insert(new AsInterval<int>(6, 7));

            Assert.AreEqual(intTree.Count, 6);

            Assert.IsNotNull(intTree.GetOverlap(new AsInterval<int>(0, 1)));
            intTree.Delete(new AsInterval<int>(6, 7));
            Assert.IsNull(intTree.GetOverlap(new AsInterval<int>(7, 8)));

            intTree.Delete(new AsInterval<int>(1, 2));
            intTree.Delete(new AsInterval<int>(2, 3));
            intTree.Delete(new AsInterval<int>(3, 4));
            intTree.Delete(new AsInterval<int>(4, 5));

            Assert.IsNotNull(intTree.GetOverlap(new AsInterval<int>(6, 7)));
            intTree.Delete(new AsInterval<int>(5, 6));
            Assert.IsNull(intTree.GetOverlap(new AsInterval<int>(6, 7)));


            Assert.AreEqual(intTree.Count, 0);
        }

        /// </summary>
        [TestMethod]
        public void IntervalTreeD_Smoke_Test()
        {
            var intTree = new AsDIntervalTree<int>(1);

            intTree.Insert(new int[] { 1 }, new int[] { 2 });
            intTree.Insert(new int[] { 3 }, new int[] { 4 });
            intTree.Insert(new int[] { 5 }, new int[] { 6 });
            intTree.Insert(new int[] { 7 }, new int[] { 8 });
            intTree.Insert(new int[] { 9 }, new int[] { 10 });
            intTree.Insert(new int[] { 11 }, new int[] { 12 });

            //Assert.AreEqual(intTree.Count, 6);

            Assert.IsNotNull(intTree.DoOverlap(new int[] { 1 }, new int[] { 10 }));
            //intTree.Delete(new AsInterval<int>(6, 7));
            //Assert.IsNull(intTree.GetOverlap(new AsInterval<int>(7, 8)));

            //intTree.Delete(new AsInterval<int>(1, 2));
            //intTree.Delete(new AsInterval<int>(2, 3));
            //intTree.Delete(new AsInterval<int>(3, 4));
            //intTree.Delete(new AsInterval<int>(4, 5));

            //Assert.IsNotNull(intTree.GetOverlap(new AsInterval<int>(6, 7)));
            //intTree.Delete(new AsInterval<int>(5, 6));
            //Assert.IsNull(intTree.GetOverlap(new AsInterval<int>(6, 7)));


            //Assert.AreEqual(intTree.Count, 0);
        }

        /// </summary>
        [TestMethod]
        public void IntervalTree_Accuracy_Test()
        {
            var nodeCount = 1000;
            var intTree = new AsIntervalTree<int>();

            var rnd = new Random();
            var intervals = new List<AsInterval<int>>();

            for (int i = 0; i < nodeCount; i++)
            {
                var start = i + 10 + rnd.Next(1, 10);
                var interval = new AsInterval<int>(start, start + rnd.Next(1, 10));
                intervals.Add(interval);
                intTree.Insert(new AsInterval<int>(interval.Start, interval.End[0]));

                for (int j = i; j >= 0; j--)
                {
                    Assert.IsTrue(intTree.DoOverlap(new AsInterval<int>(intervals[j].Start,
                                                      intervals[j].End[0])));

                    Assert.IsTrue(intTree.DoOverlap(new AsInterval<int>(intervals[j].Start - rnd.Next(1, 5),
                            intervals[j].End[0] + rnd.Next(1, 5))));
                }
            }

            for (int i = 0; i < nodeCount; i++)
            {
                Assert.IsTrue(intTree.DoOverlap(new AsInterval<int>(intervals[i].Start,
                                                   intervals[i].End[0])));

                Assert.IsTrue(intTree.DoOverlap(new AsInterval<int>(intervals[i].Start - rnd.Next(1, 10),
                                                    intervals[i].End[0] + rnd.Next(1, 10))));
            }


            for (int i = 0; i < intervals.Count; i++)
            {
                intTree.Delete(new AsInterval<int>(intervals[i].Start, intervals[i].End[0]));

                for (int j = i + 1; j < nodeCount; j++)
                {
                    Assert.IsTrue(intTree.DoOverlap(new AsInterval<int>(intervals[j].Start,
                        intervals[j].End[0])));
                }

            }
        }

        /// </summary>
        [TestMethod]
        public void IntervalTreeD_Accuracy_Test()
        {
            var nodeCount = 1000;
            var intTree = new AsDIntervalTree<int>(1);

            var rnd = new Random();
            var intervals = new List<AsDInterval<int>>();

            for (int i = 0; i < nodeCount; i++)
            {
                var start = i + 10 + rnd.Next(1, 10);
                var interval = new AsDInterval<int>(new int[] { start }, new int[] { start + rnd.Next(1, 10) });
                intervals.Add(interval);
                intTree.Insert(interval.Start, interval.End);

                //for (int j = i; j >= 0; j--)
                //{
                //    Assert.IsTrue(intTree.DoOverlap(intervals[j].Start,
                //                                      intervals[j].End));

                //    //Assert.IsTrue(intTree.DoOverlap(intervals[j].Start - rnd.Next(1, 5),
                //    //        intervals[j].End[0] + rnd.Next(1, 5))));
                //}
            }

            //for (int i = 0; i < nodeCount; i++)
            //{
            //    Assert.IsTrue(intTree.DoOverlap(new AsInterval<int>(intervals[i].Start,
            //                                       intervals[i].End[0])));

            //    Assert.IsTrue(intTree.DoOverlap(new AsInterval<int>(intervals[i].Start - rnd.Next(1, 10),
            //                                        intervals[i].End[0] + rnd.Next(1, 10))));
            //}


            //for (int i = 0; i < intervals.Count; i++)
            //{
            //    intTree.Delete(intervals[i].Start, intervals[i].End);

            //    //for (int j = i + 1; j < nodeCount; j++)
            //    //{
            //    //    Assert.IsTrue(intTree.DoOverlap(new AsInterval<int>(intervals[j].Start,
            //    //        intervals[j].End[0])));
            //    //}

            //}
        }


        /// <summary>
        /// stress test
        /// </summary>
        [TestMethod]
        public void IntervalTree_Stress_Test()
        {
            var nodeCount = 1000 * 10;
            var rnd = new Random();
            var intTree = new AsIntervalTree<int>();

            for (int i = 0; i < nodeCount; i++)
            {
                intTree.Insert(new AsInterval<int>(i, i + 1));
            }

            for (int i = 0; i < nodeCount; i++)
            {
                Assert.IsTrue(intTree.DoOverlap(new AsInterval<int>(i - rnd.Next(1, 5), i + rnd.Next(1, 5))));
            }

            for (int i = 0; i < nodeCount; i++)
            {
                intTree.Delete(new AsInterval<int>(i, i + 1));
            }
        }

        /// </summary>
        [TestMethod]
        public void IntervalTreeD2_Accuracy_Test()
        {
            var nodeCount = 100;
            const int dimension = 2;

            var intTree = new AsDIntervalTree<int>(dimension);

            var rnd = new Random();
            var intervals = new List<AsDInterval<int>>();

            for (int i = 0; i < nodeCount; i++)
            {
                var startx = i + 10 + rnd.Next(1, 10);
                var starty = i + 15 + rnd.Next(1, 10);
                //(x1,y1) and (x2, y2)
                var interval = new AsDInterval<int>(new int[dimension] { startx, starty },
                    new int[dimension] { startx + rnd.Next(1, 10), starty + rnd.Next(1, 10) });

                intervals.Add(interval);
                intTree.Insert(interval.Start, interval.End);

                for (int j = i; j >= 0; j--)
                {
                    var newTestInterval = intervals[j];

                    newTestInterval.Start[0] = newTestInterval.Start[0] - rnd.Next(1, 5);
                    newTestInterval.Start[1] = newTestInterval.Start[1] - rnd.Next(1, 5);

                    newTestInterval.End[0] = newTestInterval.End[0] + rnd.Next(1, 5);
                    newTestInterval.End[1] = newTestInterval.End[1] + rnd.Next(1, 5);

                    Assert.IsTrue(intTree.DoOverlap(newTestInterval.Start,
                          newTestInterval.End));
                }
            }

            //for (int i = 0; i < nodeCount; i++)
            //{
            //    Assert.IsTrue(intTree.DoOverlap(new AsInterval<int>(intervals[i].Start,
            //                                       intervals[i].End[0])));

            //    Assert.IsTrue(intTree.DoOverlap(new AsInterval<int>(intervals[i].Start - rnd.Next(1, 10),
            //                                        intervals[i].End[0] + rnd.Next(1, 10))));
            //}


            //for (int i = 0; i < intervals.Count; i++)
            //{
            //    intTree.Delete(new AsInterval<int>(intervals[i].Start, intervals[i].End[0]));

            //    for (int j = i + 1; j < nodeCount; j++)
            //    {
            //        Assert.IsTrue(intTree.DoOverlap(new AsInterval<int>(intervals[j].Start,
            //            intervals[j].End[0])));
            //    }

            //}
        }

    }
}
