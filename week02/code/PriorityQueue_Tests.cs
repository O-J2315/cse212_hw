using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue 3 items with priorities 1, 2, 3 and dequeue them
    // Expected Result: Items come out in order C, B, A
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue(new PriorityItem("A", 1).Value, 1);
        priorityQueue.Enqueue(new PriorityItem("B", 2).Value, 2);
        priorityQueue.Enqueue(new PriorityItem("C", 3).Value, 3);

        var actual = new List<string>();

        while (true)
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
    // Scenario: Enqueue multiple items with the same highest priority
    // Expected Result: Items with same priority dequeued in FIFO order
    // Erros: The loop inside the dequeue was doing a comparison with >= instead of >
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("X", 5);
        priorityQueue.Enqueue("Y", 5);
        priorityQueue.Enqueue("Z", 3);

        var first = priorityQueue.Dequeue();
        var second = priorityQueue.Dequeue();
        var third = priorityQueue.Dequeue();

        Assert.AreEqual("X", first);
        Assert.AreEqual("Y", second);
        Assert.AreEqual("Z", third);
    }

    [TestMethod]
    // Scenario: Enqueue single item and dequeue it
    // Expected Result: Dequeue returns "X"
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("X", 5);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("X", result);
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue
    // Expected Result: Should throw InvalidOperationException with specific message
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        var ex = Assert.ThrowsException<InvalidOperationException>(() =>
        {
            priorityQueue.Dequeue();
        });

        Assert.AreEqual("The queue is empty.", ex.Message);
    }
}