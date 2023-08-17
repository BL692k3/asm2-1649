namespace asm2_1649
{
    public class Program
    {
        public static void Main()
        {
            MessageTransferProgram messageTransferProgram = new();
            bool running = true; // Initialize running variable to true

            while (running)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Enqueue Message(s)");
                Console.WriteLine("2. Dequeue and Push Messages");
                Console.WriteLine("3. Pop and Print Messages");
                Console.WriteLine("4. Print Process Buffer");
                Console.WriteLine("5. Print Transport Buffer");
                Console.WriteLine("6. Filter Process Buffer");
                Console.WriteLine("7. Filter Transport Buffer");
                Console.WriteLine("8. Exit");

                Console.Write("Enter your choice: ");
                string input = Console.ReadLine();

                Console.Clear(); // Clear the screen after each case

                switch (input)
                {
                    case "1":
                        EnqueueMessages();                        
                        Console.ReadKey();
                        break;

                    case "2":
                        DequeueToPushMessages();
                        Console.ReadKey();
                        break;

                    case "3":
                        PopToPrintMessages();
                        Console.ReadKey();
                        break;

                    case "4":
                        messageTransferProgram.PrintProcessBuffer();
                        Console.ReadKey();
                        break;
                        
                    case "5":
                        messageTransferProgram.PrintTransportBuffer();
                        Console.ReadKey();
                        break;

                    case "6":
                        ProcessBufferFilter();
                        Console.ReadKey();
                        break;

                    case "7":
                        TransportBufferFilter();
                        Console.ReadKey();
                        break;

                    case "8":
                        running = false; // Set running to false to exit the loop
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Console.ReadKey();
                        break;
                }

                Console.Clear(); // Clear the screen after each case
                Thread.Sleep(200); // Add a small delay before proceeding
            }

            Console.WriteLine("Program ends.");
        }

        public static void EnqueueMessages()
        {
            MessageTransferProgram messageTransferProgram = new();
            Console.Write("Enter the number of messages to enqueue: ");
            if (int.TryParse(Console.ReadLine(), out int count))
            {
                for (int i = 0; i < count; i++)
                {
                    Console.Write($"Enter message {i + 1}: ");
                    string enqueueMessage = Console.ReadLine();
                    if (!string.IsNullOrEmpty(enqueueMessage))
                    {
                        messageTransferProgram.EnqueueMessage(enqueueMessage);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Message cannot be null or empty.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }

        public static void DequeueToPushMessages() 
        {
            MessageTransferProgram messageTransferProgram = new();
            if (messageTransferProgram.CountProcessBuffer == 0)
            {
                Console.WriteLine("No messages to be dequeued and pushed onto transport buffer");
            }
            else
            {
                while (messageTransferProgram.CountProcessBuffer > 0)
                {
                    string message = messageTransferProgram.DequeueMessage();
                    messageTransferProgram.PushMessage(message);
                }
                Console.WriteLine("Dequeued and pushed all messages from the process buffer to the transfer buffer.");
            }
        }

        public static void PopToPrintMessages()
        {
            MessageTransferProgram messageTransferProgram = new();
            while (messageTransferProgram.CountTransportBuffer > 0)
            {
                string message = messageTransferProgram.PopMessage();
                Console.WriteLine($"Popped message from process buffer: {message}");
            }
        }

        public static void ProcessBufferFilter()
        {
            MessageTransferProgram messageTransferProgram = new();
            Console.Write("Enter the search criteria: ");
            string searchProcess = Console.ReadLine();
            IEnumerable<string> filteredProcessMessages = messageTransferProgram.FilterProcessBuffer(searchProcess);
            Console.WriteLine("Filtered Messages in Process Buffer:");
            foreach (string filteredMessage in filteredProcessMessages)
            {
                Console.WriteLine(filteredMessage);
            }
        }

        public static void TransportBufferFilter()
        {
            MessageTransferProgram messageTransferProgram = new();
            Console.Write("Enter the search criteria: ");
            string searchTransport = Console.ReadLine();
            IEnumerable<string> filteredTransportMessages = messageTransferProgram.FilterTransportBuffer(searchTransport);
            Console.WriteLine("Filtered Messages in Transport Buffer:");
            foreach (string filteredMessage in filteredTransportMessages)
            {
                Console.WriteLine(filteredMessage);
            }
        }
    }
}