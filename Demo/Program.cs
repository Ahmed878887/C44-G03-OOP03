using System.Runtime.Intrinsics.X86;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part1 Q01

            //What is the primary purpose of an interface in C#?
            //a) To provide a way to implement multiple inheritance
            //b) To define a blueprint for a class
            //c) To declare abstract methods and properties
            //d) To create instances of objects

            b) To define a blueprint for a class
        #endregion
        #region Q02
          // Which of the following is NOT a valid access modifier for interface members in C#?
          //a) private
          //b) protected
          // c) internal
          //  d) public
          a) private
        #endregion
        #region Q03
          //  Can an interface contain fields in C#?
          // a) Yes
          // b) No
          // c) Only if they are static
          // d) Only if they are readonly
          b) No
        #endregion
        #region Q04
        // In C#, can an interface inherit from another interface?
        // a) No, interfaces cannot inherit from each other
        // b) Yes, interfaces can inherit from multiple interfaces
        //c) Yes, but only if they have the same methods
        // d) Only if the interfaces are in the same namespace
        b) Yes, interfaces can inherit from multiple interfaces
            #endregion
        #region Q05
        // Which keyword is used to implement an interface in a class in C#?
        // a) inherit
        // b) use
        // c) extends
        //  d) implements
       d) implements
        #endregion
        #region Q06
       // Can an interface contain static methods in C#?
       // a) Yes
       // b) No
       // c) Only if the interface is sealed
       // d) Only if the methods are private
       a) Yes
        #endregion
        #region Q07
       //In C#, can an interface have explicit access modifiers for its members?
       // a) Yes, for all members
       // b) No, all members are implicitly public
       //c) Yes, but only for abstract members
       // d) Only if the interface is sealed
       b) No, all members are implicitly public
        #endregion
        #region Q08
      // What is the purpose of an explicit interface implementation in C#?
      // a) To hide the interface members from outside access
      // b) To provide a clear separation between interface and class members
      //c) To allow multiple classes to implement the same interface
      // d) To speed up method resolution
      b) To provide a clear separation between interface and class members
              #endregion
        #region Q09
        // In C#, can an interface have a constructor?
        // a) Yes, but it must be private
        // b) No, interfaces cannot have constructors
        // c) Yes, but only if the interface is sealed
        // d) Only if the constructor is static
       b) No, interfaces cannot have constructors
          #endregion
        #region Q10
        // How can a C# class implement multiple interfaces?
        // a) By using the "implements" keyword
        // b) By using the "extends" keyword
        // c) By separating interface names with commas
        //d) A class cannot implement multiple interfaces

            c) By separating interface names with commas
            #endregion
        #region Part 02 Q01
        /*Define an interface named IShape with a property Area and a method DisplayShapeInfo. Create two interfaces,
         * ICircle and IRectangle, that inherit from IShape. Implement these interfaces in classes Circle and Rectangle.
         * Test your implementation by creating instances of both classes and displaying their shape information.
         */
        public interface IShape
        {
            double Area { get; }
            void DisplayShapeInfo();
        }

        public interface ICircle : IShape
        {
            double Radius { get; set; }
        }

        public interface IRectangle : IShape
        {
            double Length { get; set; }
            double Width { get; set; }
        }

        // Implement the classes
        public class Circle : ICircle
        {
            public double Radius { get; set; }

            public double Area => Math.PI * Radius * Radius;

            public void DisplayShapeInfo()
            {
                Console.WriteLine($"Circle - Radius: {Radius}, Area: {Area}");
            }
        }

        public class Rectangle : IRectangle
        {
            public double Length { get; set; }
            public double Width { get; set; }

            public double Area => Length * Width;

            public void DisplayShapeInfo()
            {
                Console.WriteLine($"Rectangle - Length: {Length}, Width: {Width}, Area: {Area}");
            }
        }

        
        class Program
        {
            static void Main()
            {
                ICircle circle = new Circle { Radius = 5 };
                circle.DisplayShapeInfo();

                IRectangle rectangle = new Rectangle { Length = 4, Width = 6 };
                rectangle.DisplayShapeInfo();
            }
        }
        #endregion
        #region  Q02
        public interface IAuthenticationService
        {
            bool AuthenticateUser(string username, string password);
            bool AuthorizeUser(string username, string role);
        }

        public class BasicAuthenticationService : IAuthenticationService
        {
            private Dictionary<string, string> _userCredentials = new()
    {
        { "admin", "admin123" },
        { "user", "user123" }
    };

            private Dictionary<string, string> _userRoles = new()
    {
        { "admin", "Administrator" },
        { "user", "User" }
    };

            public bool AuthenticateUser(string username, string password)
            {
                return _userCredentials.TryGetValue(username, out var storedPassword)
                       && storedPassword == password;
            }

            public bool AuthorizeUser(string username, string role)
            {
                return _userRoles.TryGetValue(username, out var userRole)
                       && userRole == role;
            }
        }

        class Program
        {
            static void Main()
            {
                IAuthenticationService authService = new BasicAuthenticationService();
                bool isAuthenticated = authService.AuthenticateUser("admin", "admin123");
                bool isAuthorized = authService.AuthorizeUser("admin", "Administrator");

                Console.WriteLine($"Authenticated: {isAuthenticated}, Authorized: {isAuthorized}");
            }
        }
        #endregion
        #region Q03
        public interface INotificationService
        {
            void SendNotification(string recipient, string message);
        }

        public class EmailNotificationService : INotificationService
        {
            public void SendNotification(string recipient, string message)
            {
                Console.WriteLine($"Email sent to {recipient}: {message}");
            }
        }

        public class SmsNotificationService : INotificationService
        {
            public void SendNotification(string recipient, string message)
            {
                Console.WriteLine($"SMS sent to {recipient}: {message}");
            }
        }

        public class PushNotificationService : INotificationService
        {
            public void SendNotification(string recipient, string message)
            {
                Console.WriteLine($"Push notification sent to {recipient}: {message}");
            }
        }

        class Program
        {
            static void Main()
            {
                INotificationService emailService = new EmailNotificationService();
                INotificationService smsService = new SmsNotificationService();
                INotificationService pushService = new PushNotificationService();

                emailService.SendNotification("user@example.com", "Hello via Email!");
                smsService.SendNotification("+123456789", "Hello via SMS!");
                pushService.SendNotification("DeviceID123", "Hello via Push!");
            }
        }
        #endregion





    }
}
}
