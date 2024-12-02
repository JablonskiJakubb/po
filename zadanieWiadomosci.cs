using System;

namespace Delegaty
{
    internal class Program
    {
        // Define the delegate type
        public delegate void NotificationHandler(string message);

        // Email Notifier class
        public class EmailNotifier
        {
            public void SendEmail(string message)
            {
                Console.WriteLine($"Email wysłany: {message}");
            }
        }

        // SMS Notifier class
        public class SMSnotifier
        {
            public void SendSms(string message)
            {
                Console.WriteLine($"SMS wysłany: {message}");
            }
        }

        // Push Notifier class
        public class PushNotifier
        {
            public void SendPush(string message)
            {
                Console.WriteLine($"Push wysłany: {message}");
            }
        }

        // Notifications Manager class
        public class NotificationsManager
        {
            // Delegate to hold notification methods
            public NotificationHandler Notify;

            // Add a notification method to the delegate
            public void AddNotificationMethod(NotificationHandler handler)
            {
                Notify += handler;
            }

            // Remove a notification method from the delegate
            public void RemoveNotificationMethod(NotificationHandler handler)
            {
                Notify -= handler;
            }

            // Send notification through the added methods
            public void SendNotification(string message)
            {
                Notify?.Invoke(message);
            }
        }
        public static void ShowMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1. Dodaj powiadomienie Email");
            Console.WriteLine("2. Dodaj powiadomienie SMS");
            Console.WriteLine("3. Dodaj powiadomienie Push");
            Console.WriteLine("4. Usuń powiadomienie Email");
            Console.WriteLine("5. Usuń powiadomienie SMS");
            Console.WriteLine("6. Usuń powiadomienie Push");
            Console.WriteLine("7. Wyślij powiadomienie");
            Console.WriteLine("8. Wyjdz");
            Console.WriteLine("Wybierz opcję: ");
        }
        static void Main(string[] args)
        {

            
                var emailNotifier = new EmailNotifier();
                var smsNotifier = new SMSnotifier();
                var pushNotifier = new PushNotifier();


                var notificationManager = new NotificationsManager();

                Console.ReadLine();
            while (true)
            {
                try
                {
                    ShowMenu();
                    var Choice = Console.ReadLine();

                    switch (Choice)
                    {
                        case "1":
                            notificationManager.AddNotificationMethod(emailNotifier.SendEmail);
                            Console.WriteLine("dodano powiadomienie Email");
                            break;
                        case "2":
                            notificationManager.AddNotificationMethod(smsNotifier.SendSms);
                            Console.WriteLine("dodano powiadomienie SMS");
                            break;
                        case "3":
                            notificationManager.AddNotificationMethod(pushNotifier.SendPush);
                            Console.WriteLine("dodano powiadomienie Push");
                            break;
                        case "4":
                            notificationManager.RemoveNotificationMethod(emailNotifier.SendEmail);
                            Console.WriteLine("usunięto powiadomienie Email");
                            break;
                        case "5":
                            notificationManager.RemoveNotificationMethod(smsNotifier.SendSms);
                            Console.WriteLine("usunięto powiadomienie SMS");
                            break;
                        case "6":
                            notificationManager.AddNotificationMethod(pushNotifier.SendPush);
                            Console.WriteLine("usunięto powiadomienie Push");
                            break;
                        case "7":
                            Console.Write("Wpisz wiadomość do wysłania");
                            var message = Console.ReadLine();
                            notificationManager.SendNotification(message);
                            break;
                        case "8":
                            return;
                        default: Console.WriteLine("sprobuj ponownie"); break;

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Wystąpił błąd: {e.Message}");
                }
            }
        }
    }
}
