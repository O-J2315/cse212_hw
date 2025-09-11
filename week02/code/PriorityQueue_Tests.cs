using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue 3 items with priorities 1, 2, 3 and dequeue them
    // Expected Result: Items come out in order C, B, A
    // Defect(s) Found: Queue will not erase the item that was dequeued. 
    // Loop through the dequeue process was ending too soon.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue(new PriorityItem("A", 1).Value, 1);
        priorityQueue.Enqueue(new PriorityItem("B", 2).Value, 2);
        priorityQueue.Enqueue(new PriorityItem("C", 3).Value, 3);

        var actual = new List<string>();

        for (; ; )
        {
            try
            {
                var item = priorityQueue.Dequeue();
                actual.Add(item);
            }
            catch (InvalidOperationException)
            {
                break;
            }
        }

        var expected = new List<string> { "C", "B", "A" };

        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    // Scenario: Enqueue single item and dequeue it
    // Expected Result: Dequeue returns "X"
    // Defect(s) Not Found
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("X", 5);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("X", result);
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue
    // Expected Result: Should throw InvalidOperationException
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        Assert.ThrowsException<InvalidOperationException>(() =>
        {
            priorityQueue.Dequeue();
        });
    }
}