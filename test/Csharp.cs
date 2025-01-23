using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using static System.Console;

namespace AllFeaturesExample
{
    // Delegate definition
    public delegate void MyDelegate(string message);

    // Enum definition
    public enum MyEnum
    {
        None,
        First,
        Second
    }

    // Struct definition
    public struct MyStruct
    {
        public int Value;
        public MyStruct(int value)
        {
            Value = value;
        }
    }

    // Interface definition
    public interface IExample
    {
        void InterfaceMethod();
    }

    // Record type (immutable reference type)
    public record MyRecord(string Name, int Age);

    // Class implementing an interface
    public class ExampleClass : IExample
    {
        // Event using the delegate
        public event MyDelegate OnNotify;

        // Auto-implemented property with a default value
        private string PrivateAutoProperty { get; init; } = "Default";
        protected string ProtectedAutoProperty { get; init; } = "Default";
        public string AutoProperty { get; set; } = "Default";
        public string InitAutoProperty { get; init; } = "Default";

        // Expression-bodied property
        public int Length => AutoProperty.Length;

        // Indexer with a backing List<int>
        private List<int> _numbers = new List<int>();
        public int this[int index]
        {
            get => _numbers[index];
            set => _numbers[index] = value;
        }

        // Constructor
        public ExampleClass()
        {
            _numbers.AddRange(new[] { 1, 2, 3 });
        }

        // Interface method implementation
        public void InterfaceMethod()
        {
            WriteLine("InterfaceMethod invoked");
        }

        // Static method
        public static string StaticMethod(string input) => $"StaticMethod: {input}";

        // Operator overloading
        public static ExampleClass operator +(ExampleClass a, ExampleClass b)
        {
            var result = new ExampleClass();
            result._numbers.Clear();
            result._numbers.AddRange(a._numbers);
            result._numbers.AddRange(b._numbers);
            return result;
        }

        // Local function example
        public void LocalFunctionExample()
        {
            int LocalAdd(int x, int y) => x + y;
            WriteLine($"LocalAdd(2, 3) returns: {LocalAdd(2, 3)}");
        }

        // Pattern matching example
        public string PatternMatchExample(object obj)
        {
            return obj switch
            {
                null => "Object is null",
                int i => $"Object is an int: {i}",
                string s when s.Length > 5 => $"Long string: {s}",
                string s => $"Short string: {s}",
                _ => "Unknown type"
            };
        }

        // Discard usage in a deconstruction
        public void Deconstruct(MyRecord record)
        {
            var (name, _) = record;
            WriteLine($"Name is {name}, ignoring age");
        }

        // Enum usage
        public string EnumExample(MyEnum e)
        {
            return e switch
            {
                MyEnum.None => "None selected",
                MyEnum.First => "First selected",
                MyEnum.Second => "Second selected",
                _ => "Unrecognized"
            };
        }

        // Generic method
        public T GenericMethod<T>(T parameter)
        {
            WriteLine($"GenericMethod called with type {typeof(T)}");
            return parameter;
        }

        // Async/await example
        public async Task<string> AsyncMethod()
        {
            await Task.Delay(500);
            return "Async result";
        }
    }

    // Partial class demonstration (splitting the class into two files)
    public partial class PartialExample
    {
        public void PartialMethodOne()
        {
            WriteLine("PartialMethodOne in PartialExample");
        }
    }

    public partial class PartialExample
    {
        public void PartialMethodTwo()
        {
            WriteLine("PartialMethodTwo in PartialExample");
        }
    }

    // Record struct (immutable value type)
    public record struct MyRecordStruct(int X, int Y);

    // Main program
    public class Program
    {
        // Attribute usage
        [Obsolete("This method is obsolete, use Main instead.")]
        public static void OldMain() { }

        public static async Task Main(string[] args)
        {
            var example = new ExampleClass();

            // Event usage
            example.OnNotify += (msg) => WriteLine($"Event triggered: {msg}");
            example.OnNotify?.Invoke("Hello from event!");

            // Property usage
            example.AutoProperty = "Hello World";
            WriteLine($"AutoProperty: {example.AutoProperty}, Length: {example.Length}");

            // Indexer usage
            example[1] = 42;
            WriteLine($"Indexer[1]: {example[1]}");

            // Interface method call
            example.InterfaceMethod();

            // Static method call
            WriteLine(ExampleClass.StaticMethod("Example"));

            // Operator overloading
            var example2 = new ExampleClass();
            var combined = example + example2;
            WriteLine($"Combined object index 0: {combined[0]}, " +
                      $"index 1: {combined[1]}, " +
                      $"index 2: {combined[2]}, " +
                      $"index 3: {combined[3]}");

            // Local function usage
            example.LocalFunctionExample();

            // Pattern matching
            WriteLine(example.PatternMatchExample(null));
            WriteLine(example.PatternMatchExample(123));
            WriteLine(example.PatternMatchExample("Hi"));
            WriteLine(example.PatternMatchExample("Hello World"));

            // Discard usage
            example.Deconstruct(new MyRecord("Alice", 30));

            // Enum usage
            WriteLine(example.EnumExample(MyEnum.Second));

            // Generics
            example.GenericMethod("generic string");
            example.GenericMethod(99);

            // Async/await
            string asyncResult = await example.AsyncMethod();
            WriteLine($"Async result: {asyncResult}");

            // Partial class usage
            var partial = new PartialExample();
            partial.PartialMethodOne();
            partial.PartialMethodTwo();

            // Record usage
            var rec = new MyRecord("Bob", 25);
            WriteLine($"Record: {rec}");

            // Record struct usage
            var recordStruct = new MyRecordStruct(10, 20);
            MyRecordStruct recordStruct2 = new(10, 20);
            WriteLine($"Record struct: X={recordStruct.X}, Y={recordStruct.Y}");

            // LINQ usage
            List<int> numbers = new() { 1, 2, 3, 4, 5 };
            var oddSquares = numbers
                .Where(n => n % 2 != 0)
                .Select(n => n * n);
            WriteLine($"Odd squares: {string.Join(", ", oddSquares)}");

            // Raw string literal (C# 11+)
            string rawString = """
                This is a raw string literal
                that preserves whitespace and
                doesn't require escaping "quotes"
                or backslashes.
            """;
            WriteLine(rawString);

            // Reflection example
            var type = example.GetType();
            WriteLine($"Reflection: Class name is {type.Name} in namespace {type.Namespace}");

            // Environment info
            WriteLine($".NET version: {Environment.Version}");
        }
    }
}