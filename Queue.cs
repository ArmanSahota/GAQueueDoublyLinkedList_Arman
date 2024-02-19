using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Arman Sahota 2/18/2024 
namespace GA_Queue
{
    class Queue<T>
    {
        class QueueNode<T>
        {
            public T Value { get; set; } // Node stored value
            public QueueNode<T> Next { get; set; } // next Node value
            public QueueNode<T> Previous { get; set; } // last node value

            public QueueNode(T value)
            {
                Value = value; // Value is node value
                Next = null; // next node starts Null
                Previous = null; // last node starts null
            }
        }


        private QueueNode<T> front; // first or front node
        private QueueNode<T> rear; // last of rear node
        private int count; //  count

        public int Count
        {
            get { return count; } // get count
        }

        public Queue()
        {
            front = null; // starts empty
            rear = null; // starts empty
            count = 0; // starts at 0/ starts empty
        }

        public void Enqueue(T value)
        {
            QueueNode<T> newNode = new QueueNode<T>(value); // New node value

            if (rear == null)
            {
                // If empty front and rear are new nodes
                front = newNode;
                rear = newNode;
            }
            else
            {
                // new node is after current rear node
                rear.Next = newNode;
                newNode.Previous = rear;
                // update the current node to be new node
                rear = newNode;
            }

            count++; // add to count
        }

        public T Dequeue()
        {
            if (front == null)
                throw new InvalidOperationException("Queue is empty."); // Check for an empty queue.

            T value = front.Value; // return value

            // move to next front node
            front = front.Next;

            if (front == null)
                rear = null; // if queue becomes empty change rear as well
            else
                front.Previous = null; // Remove the reference to the dequeued node.

            count--; // lose value 
            return value; // Return the dequeued value.
        }

        public T Peek()
        {
            if (front == null)
                throw new InvalidOperationException("Queue is empty."); // Check for an empty queue.

            return front.Value; // Return the value of the front node.
        }

        public void Clear()
        {
            front = null; // Reset the front to null.
            rear = null; // Reset the rear to null.
            count = 0; // Reset the count to 0.
        }
    }

}
