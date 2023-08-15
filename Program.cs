namespace asm2_1649
{
    public class MessageTransferProgram
    {
        private readonly Stack<string> transmissionBuffer;
        private readonly Queue<string> receptionBuffer;

        public MessageTransferProgram()
        {
            transmissionBuffer = new Stack<string>();
            receptionBuffer = new Queue<string>();
        }

        public void TransmitMessage(string message)
        {
            try
            {
                if (message.Length > 250)
                {
                    throw new ArgumentException("Message exceeds the maximum allowed length of 250 characters.");
                }

                transmissionBuffer.Push(message);
                Console.WriteLine("Message transmitted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while transmitting message: {ex.Message}");
            }
        }

        public void PopMessage()
        {
            try
            {
                if (transmissionBuffer.Count == 0)
                {
                    throw new InvalidOperationException("No messages available in the transmission buffer.");
                }

                string message = transmissionBuffer.Pop();
                Console.WriteLine($"Popped message from transmission buffer: {message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while popping message from transmission buffer: {ex.Message}");
            }
        }

        public void ReceiveMessage()
        {
            try
            {
                if (receptionBuffer.Count == 0)
                {
                    throw new InvalidOperationException("No messages available for reception.");
                }

                string message = receptionBuffer.Dequeue();
                Console.WriteLine($"Received message: {message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while receiving message: {ex.Message}");
            }
        }

        public void EnqueueMessage(string message)
        {
            try
            {
                if (message.Length > 250)
                {
                    throw new ArgumentException("Message exceeds the maximum allowed length of 250 characters.");
                }

                receptionBuffer.Enqueue(message);
                Console.WriteLine("Message enqueued successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while enqueuing message: {ex.Message}");
            }
        }

        public void PrintTransmissionBuffer()
        {
            Console.WriteLine("Transmission Buffer:");
            foreach (string message in transmissionBuffer)
            {
                Console.WriteLine(message);
            }
        }

        public void PrintReceptionBuffer()
        {
            Console.WriteLine("Reception Buffer:");
            foreach (string message in receptionBuffer)
            {
                Console.WriteLine(message);
            }
        }

        public IEnumerable<string> FilterTransmissionBuffer(string searchCriteria)
        {
            List<string> filteredMessages = new();

            foreach (string message in transmissionBuffer)
            {
                if (message.Contains(searchCriteria))
                {
                    filteredMessages.Add(message);
                }
            }

            return filteredMessages;
        }

        public IEnumerable<string> FilterReceptionBuffer(string searchCriteria)
        {
            List<string> filteredMessages = new();

            foreach (string message in receptionBuffer)
            {
                if (message.Contains(searchCriteria))
                {
                    filteredMessages.Add(message);
                }
            }

            return filteredMessages;
        }
    }

    public class Program
    {
        public static void Main()
        {
            MessageTransferProgram messageTransferProgram = new();

            bool choice = true; // Initialize choice variable to true

            while (choice)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Transmit Message");
                Console.WriteLine("2. Pop Message");
                Console.WriteLine("3. Receive Message");
                Console.WriteLine("4. Enqueue Message");
                Console.WriteLine("5. Print Transmission Buffer");
                Console.WriteLine("6. Print Reception Buffer");
                Console.WriteLine("7. Filter Transmission Buffer");
                Console.WriteLine("8. Filter Reception Buffer");
                Console.WriteLine("9. Exit");

                Console.Write("Enter your choice: ");
                string input = Console.ReadLine();

                Console.Clear(); // Clear the screen after each case

                switch (input)
                {
                    case "1":
                        Console.Write("Enter the message to transmit: ");
                        string message = Console.ReadLine();
                        messageTransferProgram.TransmitMessage(message);
                        Console.ReadKey();
                        break;

                    case "2":
                        messageTransferProgram.PopMessage();
                        Console.ReadKey();
                        break;

                    case "3":
                        messageTransferProgram.ReceiveMessage();
                        Console.ReadKey();
                        break;

                    case "4":
                        Console.Write("Enter the message to enqueue: ");
                        string enqueueMessage = Console.ReadLine();
                        messageTransferProgram.EnqueueMessage(enqueueMessage);
                        Console.ReadKey();
                        break;

                    case "5":
                        messageTransferProgram.PrintTransmissionBuffer();
                        Console.ReadKey();
                        break;

                    case "6":
                        messageTransferProgram.PrintReceptionBuffer();
                        Console.ReadKey();
                        break;

                    case "7":
                        Console.Write("Enter the search criteria: ");
                        string searchTransmission = Console.ReadLine();
                        IEnumerable<string> filteredTransmissionMessages = messageTransferProgram.FilterTransmissionBuffer(searchTransmission);
                        Console.WriteLine("Filtered Messages in Transmission Buffer:");
                        foreach (string filteredMessage in filteredTransmissionMessages)
                        {
                            Console.WriteLine(filteredMessage);
                        }
                        Console.ReadKey();
                        break;

                    case "8":
                        Console.Write("Enter the search criteria: ");
                        string searchReception = Console.ReadLine();
                        IEnumerable<string> filteredReceptionMessages = messageTransferProgram.FilterReceptionBuffer(searchReception);
                        Console.WriteLine("Filtered Messages in Reception Buffer:");
                        foreach (string filteredMessage in filteredReceptionMessages)
                        {
                            Console.WriteLine(filteredMessage);
                        }
                        Console.ReadKey();
                        break;

                    case "9":
                        choice = false; // Set choice to false to exit the loop
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Console.ReadKey();
                        break;
                }

                Console.Clear(); // Clear the screen after each case
            }

            Console.WriteLine("Program ends.");
        }
    }
}