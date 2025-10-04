namespace Reflection
{
    internal class Program
    {
        private class SampleClass
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public void Display() => Console.WriteLine("SampleClass Display method called.");
        }
        static void Main(string[] args)
        {
            Type type = typeof(SampleClass);
            // Displaying class name
            Console.WriteLine($"Class Name: {type.Name}");
            Console.WriteLine($"NameSpace: {type.Namespace}");

            // Displaying properties
            Console.WriteLine("Properties:");
            foreach (var prop in type.GetProperties())
            {
                Console.WriteLine($"- {prop.Name} ({prop.PropertyType.Name})");
            }

            // Displaying methods
            Console.WriteLine("Methods:");
            foreach (var method in type.GetMethods())
            {
                if (method.DeclaringType == type) // để lấy các phương thức khai báo trong lớp này. Nếu không dùng if sẽ lấy luôn các phương thức kế thừa từ lớp cha như ToString, Equals, GetHashCode, v.v.
                {
                    Console.WriteLine($" {method.ReturnType}- {method.Name}");
                }
            }
        }
    }
}
