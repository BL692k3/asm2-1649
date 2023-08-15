namespace asm2_1649
{
    public class MessageTransferProgram
    {
        private readonly MyStack<string> transportBuffer;
        private readonly MyQueue<string> processBuffer;

        public MessageTransferProgram()
        {
            transportBuffer = new MyStack<string>();
            processBuffer = new MyQueue<string>();
        }
        public int CountTransportBuffer => transportBuffer.Count;
        public int CountProcessBuffer => processBuffer.Count;
        public void PushMessage(string message)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    throw new ArgumentException("Message cannot be null or empty.");
                }

                if (message.Length > 250)
                {
                    throw new ArgumentException("Message exceeds the maximum allowed length of 250 characters.");
                }

                transportBuffer.Push(message);
                Console.WriteLine("Message pushed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while pushing message: {ex.Message}");
            }
        }

        public string PopMessage()
        {
            try
            {
                if (transportBuffer.Count == 0)
                {
                    throw new InvalidOperationException("No messages available in the transport buffer.");
                }

                return transportBuffer.Pop();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error while popping message from transport buffer: {ex.Message}");
                return null; // Add a return statement here
            }
        }

        public string DequeueMessage()
        {
            try
            {
                if (processBuffer.Count == 0)
                {
                    throw new InvalidOperationException("No messages available for dequeueing.");
                }

                return processBuffer.Dequeue();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error while dequeuing message: {ex.Message}");
                return null; // Add a return statement here
            }
        }

        public void EnqueueMessage(string message)
        {
            try
            {
                if (message == null)
                {
                    throw new ArgumentNullException("Message cannot be null.");
                }

                if (message.Length > 250)
                {
                    throw new ArgumentException("Message exceeds the maximum allowed length of 250 characters.");
                }

                processBuffer.Enqueue(message);
                Console.WriteLine("Message enqueued successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while enqueuing message: {ex.Message}");
            }
        }


        public void PrintTransportBuffer()
        {
            Console.WriteLine("Transport Buffer:");
            foreach (string message in transportBuffer)
            {
                Console.WriteLine(message);
            }
        }

        public void PrintProcessBuffer()
        {
            Console.WriteLine("Process Buffer:");
            foreach (string message in processBuffer)
            {
                Console.WriteLine(message);
            }
        }

        public IEnumerable<string> FilterTransportBuffer(string searchCriteria)
        {
            List<string> filteredMessages = new();

            foreach (string message in transportBuffer)
            {
                if (message.Contains(searchCriteria) && message.Length <= 250)
                {
                    filteredMessages.Add(message);
                }
            }

            return filteredMessages;
        }

        public IEnumerable<string> FilterProcessBuffer(string searchCriteria)
        {
            List<string> filteredMessages = new();

            foreach (string message in processBuffer)
            {
                if (message.Contains(searchCriteria) && message.Length <= 250)
                {
                    filteredMessages.Add(message);
                }
            }

            return filteredMessages;
        }
    }
}